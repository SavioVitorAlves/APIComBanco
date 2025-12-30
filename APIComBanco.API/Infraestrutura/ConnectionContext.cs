using APIComBanco.API.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace APIComBanco.API.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;

        // Mantenha este construtor para que o .NET injete as configurações
        public ConnectionContext(DbContextOptions<ConnectionContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Busca a string de conexão do appsettings.json ou variáveis de ambiente
                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("A ConnectionString 'DefaultConnection' não foi encontrada.");
                }

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}