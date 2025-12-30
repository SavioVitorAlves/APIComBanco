using APIComBanco.API.Domain.Model;

namespace APIComBanco.API.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Inserir(Usuarios usuaario);
        void Alterar(Usuarios usuario, int id);
        bool Excluir(int id);

        Task<Usuarios> SelecionarByPk(int id);

        Task<IEnumerable<Usuarios>> SelecionarAll();

        Task<bool> SaveAllAsync();
        Task<Usuarios?> GetByEmail(string email);

    }
}
