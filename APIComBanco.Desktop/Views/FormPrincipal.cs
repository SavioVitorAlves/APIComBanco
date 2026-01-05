using APIComBanco.Desktop.Model;
using APIComBanco.Desktop.Properties;
using APIComBanco.Desktop.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIComBanco.Desktop.Views
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        int _idLinhaSelecionada;
        string _senhaLinhaSelecionada;

        // Alterado de Task para void para seguir o padrão de eventos WinForms
        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Iniciando busca...");
            try
            {
                var usuarioService = new UsuarioService();
                var token = Settings.Default.UserToken;

                var dados = AuthService.ObterDadosDoUsuario();
                if (dados != null)
                {
                    LbUsuario.Text = dados.Nome;
                    LbEmail.Text = dados.Email;
                    Console.WriteLine($"ID do usuário logado: {dados.Id}");
                }

                var usuarios = await usuarioService.GetUsuarios(token);
                if (usuarios != null && usuarios.Count > 0)
                {
                    tbUsuarios.DataSource = null;
                    tbUsuarios.Columns.Clear();
                    tbUsuarios.AutoGenerateColumns = false;

                    var colId = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Id",
                        HeaderText = "Id",
                        Name = "Id"
                    };
                    colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Fica pequeno
                    tbUsuarios.Columns.Add(colId);

                    // 2. NOME: Definimos para preencher o espaço (Peso 2)
                    var colNome = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Nome",
                        HeaderText = "Nome",
                        Name = "Nome"
                    };
                    colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    colNome.FillWeight = 200; // Ocupa o dobro de espaço proporcionalmente
                    tbUsuarios.Columns.Add(colNome);

                    // 3. EMAIL: Definimos para preencher o espaço (Peso 1)
                    var colEmail = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        HeaderText = "Email",
                        Name = "Email"
                    };
                    colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    colEmail.FillWeight = 150;
                    tbUsuarios.Columns.Add(colEmail);

                    // 4. IDADE: Pequeno também
                    var colIdade = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Idade",
                        HeaderText = "Idade",
                        Name = "Idade"
                    };
                    colIdade.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    tbUsuarios.Columns.Add(colIdade);

                    tbUsuarios.DataSource = usuarios;
                }
                else
                {
                    MessageBox.Show("Nenhum usuário encontrado.");
                    tbUsuarios.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            AuthService.Logout(this);
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            var token = Settings.Default.UserToken;

            UsuarioService usuarioService = new UsuarioService();

            var user = new Usuario
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Idade = int.Parse(txtIdade.Text),
                Senha = txtSenha.Text
            };

            var result = await usuarioService.CreateUsuario(user, token);

            if (result == true)
            {
                MessageBox.Show("Usuario criado com sucesso!");
                txtNome.Clear();
                txtEmail.Clear();
                txtIdade.Clear();
                txtSenha.Clear();

                await CarregarUsuarios();
            }
            else
            {
                MessageBox.Show("Erro ao cria novo usuario!");
            }

        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var token = Settings.Default.UserToken;

            UsuarioService usuarioService = new UsuarioService();

            var result = await usuarioService.ExcluirUsuario(_idLinhaSelecionada, token);

            if (result == true)
            {
                MessageBox.Show("Usuario criado com sucesso!");
                txtNome.Clear();
                txtEmail.Clear();
                txtIdade.Clear();

                await CarregarUsuarios();
            }
            else
            {
                MessageBox.Show("Erro ao cria novo usuario!");
            }
        }

        private async void tbUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var token = Settings.Default.UserToken;
                UsuarioService usuarioService = new UsuarioService();


                DataGridViewRow linha = tbUsuarios.Rows[e.RowIndex];
                _idLinhaSelecionada = int.Parse(linha.Cells["Id"].Value.ToString());
                var usuario = await usuarioService.GetUsuariosId(token, _idLinhaSelecionada);
                _senhaLinhaSelecionada = usuario.Senha;
                txtNome.Text = linha.Cells["Nome"].Value.ToString();
                txtEmail.Text = linha.Cells["Email"].Value.ToString();
                txtIdade.Text = linha.Cells["Idade"].Value.ToString();

            }
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                var usuarioService = new UsuarioService();
                var token = Settings.Default.UserToken;

                // Faz a chamada à API para pegar a lista atualizada
                var usuarios = await usuarioService.GetUsuarios(token);

                if (usuarios != null)
                {
                    // Limpa o vínculo antigo e as colunas para evitar duplicidade
                    tbUsuarios.DataSource = null;
                    tbUsuarios.Columns.Clear();
                    tbUsuarios.AutoGenerateColumns = false;

                    // Reconstroi as colunas (Exatamente como você fez antes)
                    tbUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Name = "Id", Width = 50 });
                    tbUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                    tbUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email", Width = 150 });
                    tbUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Idade", HeaderText = "Idade", Name = "Idade", Width = 80 });

                    // Atribui a nova lista vinda da API
                    tbUsuarios.DataSource = usuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar lista: {ex.Message}");
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var token = Settings.Default.UserToken;

            var usuario = new Usuario
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Idade = int.Parse(txtIdade.Text),
                Senha = !string.IsNullOrWhiteSpace(txtSenha.Text) ? txtSenha.Text : _senhaLinhaSelecionada,
            };

            UsuarioService usuarioService = new UsuarioService();

            var result = await usuarioService.AtualizarUsuario(usuario, _idLinhaSelecionada, token);

            if (result == true)
            {
                MessageBox.Show("Usuario Atualizado com Sucesso!");
                txtEmail.Clear();
                txtIdade.Clear();
                txtNome.Clear();

                await CarregarUsuarios();
            }
            else
            {
                MessageBox.Show("Erro ao Autalizar o usuario!");
            }
        }

       
    }
}
