using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIComBanco.API.Domain.Model
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public int idade { get; private set; }

        public Usuarios(string nome, string email, string senha, int idade)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.idade = idade;
        }

        public void AlterarSenha(string novaSenha)
        {
            this.senha = novaSenha;
        }
        public void AtualizarDados(string nome, string email, int idade)
        {
            this.nome = nome;
            this.email = email;
            this.idade = idade;
        }
    }
}
