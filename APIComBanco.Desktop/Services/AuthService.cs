using APIComBanco.Desktop.Model;
using APIComBanco.Desktop.Properties;
using APIComBanco.Desktop.Views;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace APIComBanco.Desktop.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            // Configura o handler para ignorar erros de certificado SSL em localhost
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            // Inicializa o HttpClient usando o handler acima
            _httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://localhost:7248") };

            // Configuração do Token...
            var token = Properties.Settings.Default.UserToken;
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Classe auxiliar para receber o Token da API
        public class LoginResponse { public string Token { get; set; } }

        public async Task<bool> Autenticar(string usuario, string senha)
        {
            var loginData = new { email = usuario, senha = senha };

            var response = await _httpClient.PostAsJsonAsync("/api/v1/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (resultado != null && !string.IsNullOrEmpty(resultado.Token))
                {
                    // 1. Salva no Storage do Windows
                    Properties.Settings.Default.UserToken = resultado.Token;
                    Properties.Settings.Default.Save();

                    // 2. Atualiza o HttpClient atual com o novo token
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", resultado.Token);

                    return true;
                }
            }
            return false;
        }

        // MÉTODO ESTÁTICO PARA VALIDAR EXPIRAÇÃO (O "GUARD")
        public static bool IsTokenValido()
        {
            var token = Properties.Settings.Default.UserToken;
            if (string.IsNullOrEmpty(token)) return false;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Retorna true se a expiração for maior que a hora atual (com margem de 1min)
                return jwtToken.ValidTo > DateTime.UtcNow.AddMinutes(1);
            }
            catch
            {
                return false;
            }
        }

        public static void Logout(Form formularioAtual)
        {
            Properties.Settings.Default.UserToken = string.Empty;
            Properties.Settings.Default.Save();

            formularioAtual.Close();

            Form1 login = new Form1();
            login.Show();
        }

        public static UsuarioLogado ObterDadosDoUsuario()
        {
            var token = Settings.Default.UserToken;
            if (string.IsNullOrEmpty(token)) return null;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                return new UsuarioLogado
                {
                    // Buscando exatamente as chaves que apareceram no seu print do JWT.io
                    Id = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "0",
                    Nome = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value ?? "Usuário",
                    Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? "Sem e-mail"
                };
            }
            catch
            {
                return null;
            }
        }
    }
}