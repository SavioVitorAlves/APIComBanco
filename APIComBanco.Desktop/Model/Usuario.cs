using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIComBanco.Desktop.Model
{
    public class Usuario
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("idade")]
        public int Idade { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
