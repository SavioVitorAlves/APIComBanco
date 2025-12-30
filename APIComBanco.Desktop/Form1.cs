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
            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtEmail.Width, txtEmail.Height, 15, 15));
            txtSenha.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtSenha.Width, txtSenha.Height, 15, 15));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
