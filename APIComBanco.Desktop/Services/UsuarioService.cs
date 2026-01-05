using APIComBanco.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIComBanco.Desktop.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService() 
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7248/api/v1/usuarios/")
            };
        }

        public async Task<List<Usuario>> GetUsuarios(string Token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "usuarios");

            // 2. Adiciona o Token corretamente nos cabeçalhos
            request.Headers.Add("Authorization", $"Bearer {Token}");

            // 3. Envia a requisição
            var response = await _httpClient.SendAsync(request);
            MessageBox.Show($"Status Code: {(int)response.StatusCode} {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                
                if (resultado == null || resultado.Count == 0)
                {
                    return new List<Usuario>();
                }
                return resultado;
            }
            return new List<Usuario>();
        }

        public async Task<Usuario> GetUsuariosId(string Token, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"usuarios/{id}");

            request.Headers.Add("Authorization", $"Bearer {Token}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<Usuario>();
          
                return resultado;
            }
            return new Usuario();
        }

        public async Task<bool> CreateUsuario(Usuario usuario, string Token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "create");

            request.Headers.Add("Authorization", $"Bearer {Token}");

            string jsonUsuario = JsonSerializer.Serialize(usuario);
            request.Content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExcluirUsuario(int id, string Token) 
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"delete/{id}");

            request.Headers.Add("Authorization", $"Bearer {Token}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode) 
            {
                var resultado = response.Content.ReadAsStringAsync();
                return true;    
            }

            return false;
        }
        public string GerarHashSenha(string senha)
        {
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytesHash = sha256Hash.ComputeHash(bytesSenha);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytesHash.Length; i++)
                {
                    builder.Append(bytesHash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public async Task<bool> AtualizarUsuario(Usuario usuario, int id, string token)
        {
            var request1 = new HttpRequestMessage(HttpMethod.Get, $"usuarios/{id}");
            request1.Headers.Add("Authorization", $"Bearer {token}");
            var response1 = await _httpClient.SendAsync(request1);
            var resultado = await response1.Content.ReadFromJsonAsync<Usuario>();
            var senhaAntiga = resultado.Senha;

            var request = new HttpRequestMessage(HttpMethod.Put, $"update/{id}");

            request.Headers.Add("Authorization", $"Bearer {token}");

            if (usuario.Senha != senhaAntiga)
            {
                usuario.Senha = GerarHashSenha(usuario.Senha);
            }

            string jsonUsuario = JsonSerializer.Serialize(usuario);
            request.Content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var result2 = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }
    }
}
