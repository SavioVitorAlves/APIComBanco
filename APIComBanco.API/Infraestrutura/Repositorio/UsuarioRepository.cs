using APIComBanco.API.Domain.Interfaces;
using APIComBanco.API.Domain.Model;
using APIComBanco.API.Infraestrutura;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIComBanco.API.Infraestrutura.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ConnectionContext _context;

        public UsuarioRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Alterar(Usuarios usuarioAlterado, int id)
        {
            // 1. Busca o usuário atual no banco para ver a senha antiga
            var usuarioOriginal = _context.Usuarios.Find(id);

            if (usuarioOriginal == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // 2. Lógica da Senha (BCrypt)
            // Verifica se a senha enviada é diferente do hash atual
            bool aSenhaNaoMudou = BCrypt.Net.BCrypt.Verify(usuarioAlterado.senha, usuarioOriginal.senha);

            if (!aSenhaNaoMudou)
            {
                // Criptografa a nova senha
                usuarioOriginal.AlterarSenha(BCrypt.Net.BCrypt.HashPassword(usuarioAlterado.senha));
            }

            // 3. Atualiza os outros campos manualmente no objeto ORIGINAL
            usuarioOriginal.AtualizarDados(
                usuarioAlterado.nome,
                usuarioAlterado.email,
                usuarioAlterado.idade
            );

            // 4. Salva as mudanças no objeto que já estava sendo rastreado
            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }

        public void Inserir(Usuarios usuario)
        {

            string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(usuario.senha);
            usuario.AlterarSenha(senhaCriptografada);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Usuarios>> SelecionarAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios?> SelecionarByPk(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Usuarios?> GetByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.email == email);
        }
    }
}
