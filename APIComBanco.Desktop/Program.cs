using APIComBanco.Desktop.Services;
using APIComBanco.Desktop.Views;

namespace APIComBanco.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (AuthService.IsTokenValido())
            {
                // Se o token é válido, vai direto para a tela principal
                Application.Run(new FormPrincipal());
            }
            else
            {
                // Se expirou ou não existe, pede login
                Application.Run(new Form1());
            }
        }
    }
}