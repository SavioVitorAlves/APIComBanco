using APIComBanco.Desktop.Services;
using APIComBanco.Desktop.Views;
using System.Runtime.InteropServices;

namespace APIComBanco.Desktop
{
    public partial class Form1 : Form
    {
        // Importação da função do Windows para arredondar
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Form1()
        {
            InitializeComponent();

            // 1. Aplicar a Opacidade (Alpha)
            panel1.BackColor = Color.FromArgb(100, Color.Silver); // 150 é a transparência

            // 2. Aplicar o Arredondamento
            // Chamamos após o InitializeComponent para garantir que o panel1 já exista
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var authService = new AuthService();
                bool logado = await authService.Autenticar(txtEmail.Text, txtSenha.Text);

                if (logado)
                {
                    MessageBox.Show("Bem-vindo!");
                    this.Hide();
                    FormPrincipal principal = new FormPrincipal();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show($"Usuário ou senha incorretos ou Token expirado. {txtEmail.Text} {txtSenha.Text}");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ocorreu um erro técnico: {ex.Message}\n\nVerifique se a API está rodando no endereço correto.");
            }
            
        }

    }
}
