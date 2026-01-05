namespace APIComBanco.Desktop.Views
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LbEmail = new Label();
            LbUsuario = new Label();
            tbUsuarios = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Idade = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            txtSenha = new TextBox();
            btnSalvar = new Button();
            btnSair = new Button();
            btnAdicionar = new Button();
            btnExcluir = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtIdade = new TextBox();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tbUsuarios).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // LbEmail
            // 
            LbEmail.AutoSize = true;
            LbEmail.BackColor = Color.DarkSlateGray;
            LbEmail.ForeColor = Color.White;
            LbEmail.Location = new Point(11, 498);
            LbEmail.Name = "LbEmail";
            LbEmail.Size = new Size(36, 15);
            LbEmail.TabIndex = 1;
            LbEmail.Text = "Email";
            // 
            // LbUsuario
            // 
            LbUsuario.AutoSize = true;
            LbUsuario.BackColor = Color.DarkSlateGray;
            LbUsuario.ForeColor = Color.White;
            LbUsuario.Location = new Point(11, 483);
            LbUsuario.Name = "LbUsuario";
            LbUsuario.Size = new Size(47, 15);
            LbUsuario.TabIndex = 1;
            LbUsuario.Text = "Usuario";
            // 
            // tbUsuarios
            // 
            tbUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tbUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tbUsuarios.Columns.AddRange(new DataGridViewColumn[] { Id, Nome, Email, Idade });
            tbUsuarios.Location = new Point(207, 49);
            tbUsuarios.Name = "tbUsuarios";
            tbUsuarios.Size = new Size(688, 504);
            tbUsuarios.TabIndex = 4;
            tbUsuarios.CellClick += tbUsuarios_CellClick;
            // 
            // Id
            // 
            Id.FillWeight = 81.21828F;
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // Nome
            // 
            Nome.FillWeight = 106.260582F;
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // Email
            // 
            Email.FillWeight = 106.260582F;
            Email.HeaderText = "Email";
            Email.Name = "Email";
            // 
            // Idade
            // 
            Idade.FillWeight = 106.260582F;
            Idade.HeaderText = "Idade";
            Idade.Name = "Idade";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(208, 0);
            panel2.Name = "panel2";
            panel2.RightToLeft = RightToLeft.Yes;
            panel2.Size = new Size(687, 49);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Gothic", 13F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 16);
            label1.Name = "label1";
            label1.Size = new Size(178, 18);
            label1.TabIndex = 0;
            label1.Text = "Lista de Usuarios";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkSlateGray;
            panel3.Controls.Add(txtSenha);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnSalvar);
            panel3.Controls.Add(btnSair);
            panel3.Controls.Add(btnAdicionar);
            panel3.Controls.Add(btnExcluir);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(LbUsuario);
            panel3.Controls.Add(txtIdade);
            panel3.Controls.Add(LbEmail);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(txtNome);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 553);
            panel3.TabIndex = 6;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(11, 256);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(183, 23);
            txtSenha.TabIndex = 3;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(12, 293);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 23);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(12, 519);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(182, 23);
            btnSair.TabIndex = 2;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 333);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(182, 23);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar Novo";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(104, 293);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(90, 23);
            btnExcluir.TabIndex = 4;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MS Gothic", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 243);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 0;
            label6.Text = "Senha";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MS Gothic", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 196);
            label5.Name = "label5";
            label5.Size = new Size(40, 12);
            label5.TabIndex = 0;
            label5.Text = "Idade";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS Gothic", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 149);
            label4.Name = "label4";
            label4.Size = new Size(40, 12);
            label4.TabIndex = 0;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Gothic", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(33, 12);
            label3.TabIndex = 0;
            label3.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Gothic", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 65);
            label2.Name = "label2";
            label2.Size = new Size(178, 16);
            label2.TabIndex = 0;
            label2.Text = "Usuario Selecionado";
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(12, 209);
            txtIdade.Name = "txtIdade";
            txtIdade.Size = new Size(182, 23);
            txtIdade.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 164);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 117);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(182, 23);
            txtNome.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 553);
            Controls.Add(panel2);
            Controls.Add(tbUsuarios);
            Controls.Add(panel3);
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            Load += FormPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)tbUsuarios).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label LbEmail;
        private Label LbUsuario;
        private DataGridView tbUsuarios;
        private Panel panel2;
        private Label label1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Idade;
        private Panel panel3;
        private Label label2;
        private TextBox txtIdade;
        private TextBox txtEmail;
        private TextBox txtNome;
        private Button btnSair;
        private Button button1;
        private Button button2;
        private Button btnEditar;
        private Button btnAdicionar;
        private Button btnExcluir;
        private Button btnSalvar;
        private TextBox txtSenha;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
    }
}