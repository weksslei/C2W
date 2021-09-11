namespace C2W
{
    partial class Usuarios
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.AutorizarUsuario = new System.Windows.Forms.GroupBox();
            this.rbSim = new System.Windows.Forms.RadioButton();
            this.rbNao = new System.Windows.Forms.RadioButton();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBackup = new System.Windows.Forms.CheckBox();
            this.cbDespesas = new System.Windows.Forms.CheckBox();
            this.cbRequisicoes = new System.Windows.Forms.CheckBox();
            this.cbEntregas = new System.Windows.Forms.CheckBox();
            this.cbPedidos = new System.Windows.Forms.CheckBox();
            this.cbOrcamentos = new System.Windows.Forms.CheckBox();
            this.cbProdutos = new System.Windows.Forms.CheckBox();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.cbAtividadesGerenciais = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCodUsuario = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.AutorizarUsuario.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtSenha);
            this.groupBox3.Controls.Add(this.AutorizarUsuario);
            this.groupBox3.Controls.Add(this.txtUsuario);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 207);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "||  Acesso ao Sistema  ||";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(6, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 20);
            this.label10.TabIndex = 59;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(6, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 20);
            this.label11.TabIndex = 60;
            this.label11.Text = "*";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(99, 87);
            this.txtSenha.MaxLength = 8;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 16;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // AutorizarUsuario
            // 
            this.AutorizarUsuario.Controls.Add(this.rbSim);
            this.AutorizarUsuario.Controls.Add(this.rbNao);
            this.AutorizarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutorizarUsuario.Location = new System.Drawing.Point(236, 99);
            this.AutorizarUsuario.Name = "AutorizarUsuario";
            this.AutorizarUsuario.Size = new System.Drawing.Size(190, 100);
            this.AutorizarUsuario.TabIndex = 12;
            this.AutorizarUsuario.TabStop = false;
            this.AutorizarUsuario.Text = "||   Autorizar Acesso   ||";
            // 
            // rbSim
            // 
            this.rbSim.AutoSize = true;
            this.rbSim.Location = new System.Drawing.Point(19, 52);
            this.rbSim.Margin = new System.Windows.Forms.Padding(4);
            this.rbSim.Name = "rbSim";
            this.rbSim.Size = new System.Drawing.Size(52, 20);
            this.rbSim.TabIndex = 0;
            this.rbSim.Text = "SIM";
            this.rbSim.UseVisualStyleBackColor = true;
            // 
            // rbNao
            // 
            this.rbNao.AutoSize = true;
            this.rbNao.Checked = true;
            this.rbNao.Location = new System.Drawing.Point(92, 52);
            this.rbNao.Margin = new System.Windows.Forms.Padding(4);
            this.rbNao.Name = "rbNao";
            this.rbNao.Size = new System.Drawing.Size(58, 20);
            this.rbNao.TabIndex = 8;
            this.rbNao.TabStop = true;
            this.rbNao.Text = "NÃO";
            this.rbNao.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(99, 45);
            this.txtUsuario.MaxLength = 8;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 15;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Usuario.: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Senha .: ";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(109, 75);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(268, 20);
            this.txtNome.TabIndex = 22;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Código .: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBackup);
            this.groupBox1.Controls.Add(this.cbDespesas);
            this.groupBox1.Controls.Add(this.cbRequisicoes);
            this.groupBox1.Controls.Add(this.cbEntregas);
            this.groupBox1.Controls.Add(this.cbPedidos);
            this.groupBox1.Controls.Add(this.cbOrcamentos);
            this.groupBox1.Controls.Add(this.cbProdutos);
            this.groupBox1.Controls.Add(this.cbClientes);
            this.groupBox1.Controls.Add(this.cbAtividadesGerenciais);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(486, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(361, 342);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "||   Permissões ao Usuário   ||";
            // 
            // cbBackup
            // 
            this.cbBackup.AutoSize = true;
            this.cbBackup.Location = new System.Drawing.Point(61, 292);
            this.cbBackup.Name = "cbBackup";
            this.cbBackup.Size = new System.Drawing.Size(104, 17);
            this.cbBackup.TabIndex = 19;
            this.cbBackup.Text = "Realizar Backup";
            this.cbBackup.UseVisualStyleBackColor = true;
            // 
            // cbDespesas
            // 
            this.cbDespesas.AutoSize = true;
            this.cbDespesas.Location = new System.Drawing.Point(61, 264);
            this.cbDespesas.Name = "cbDespesas";
            this.cbDespesas.Size = new System.Drawing.Size(73, 17);
            this.cbDespesas.TabIndex = 18;
            this.cbDespesas.Text = "Despesas";
            this.cbDespesas.UseVisualStyleBackColor = true;
            // 
            // cbRequisicoes
            // 
            this.cbRequisicoes.AutoSize = true;
            this.cbRequisicoes.Checked = true;
            this.cbRequisicoes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRequisicoes.Location = new System.Drawing.Point(61, 236);
            this.cbRequisicoes.Name = "cbRequisicoes";
            this.cbRequisicoes.Size = new System.Drawing.Size(151, 17);
            this.cbRequisicoes.TabIndex = 17;
            this.cbRequisicoes.Text = "Requisições para compras";
            this.cbRequisicoes.UseVisualStyleBackColor = true;
            // 
            // cbEntregas
            // 
            this.cbEntregas.AutoSize = true;
            this.cbEntregas.Checked = true;
            this.cbEntregas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEntregas.Location = new System.Drawing.Point(61, 209);
            this.cbEntregas.Name = "cbEntregas";
            this.cbEntregas.Size = new System.Drawing.Size(68, 17);
            this.cbEntregas.TabIndex = 16;
            this.cbEntregas.Text = "Entregas";
            this.cbEntregas.UseVisualStyleBackColor = true;
            // 
            // cbPedidos
            // 
            this.cbPedidos.AutoSize = true;
            this.cbPedidos.Checked = true;
            this.cbPedidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPedidos.Location = new System.Drawing.Point(61, 182);
            this.cbPedidos.Name = "cbPedidos";
            this.cbPedidos.Size = new System.Drawing.Size(119, 17);
            this.cbPedidos.TabIndex = 15;
            this.cbPedidos.Text = "Pedidos de Clientes";
            this.cbPedidos.UseVisualStyleBackColor = true;
            // 
            // cbOrcamentos
            // 
            this.cbOrcamentos.AutoSize = true;
            this.cbOrcamentos.Checked = true;
            this.cbOrcamentos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrcamentos.Location = new System.Drawing.Point(61, 152);
            this.cbOrcamentos.Name = "cbOrcamentos";
            this.cbOrcamentos.Size = new System.Drawing.Size(145, 17);
            this.cbOrcamentos.TabIndex = 14;
            this.cbOrcamentos.Text = "Orçamentos para vendas";
            this.cbOrcamentos.UseVisualStyleBackColor = true;
            // 
            // cbProdutos
            // 
            this.cbProdutos.AutoSize = true;
            this.cbProdutos.Location = new System.Drawing.Point(61, 125);
            this.cbProdutos.Name = "cbProdutos";
            this.cbProdutos.Size = new System.Drawing.Size(68, 17);
            this.cbProdutos.TabIndex = 12;
            this.cbProdutos.Text = "Produtos";
            this.cbProdutos.UseVisualStyleBackColor = true;
            // 
            // cbClientes
            // 
            this.cbClientes.AutoSize = true;
            this.cbClientes.Location = new System.Drawing.Point(61, 98);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(63, 17);
            this.cbClientes.TabIndex = 11;
            this.cbClientes.Text = "Clientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            // 
            // cbAtividadesGerenciais
            // 
            this.cbAtividadesGerenciais.AutoSize = true;
            this.cbAtividadesGerenciais.Location = new System.Drawing.Point(61, 71);
            this.cbAtividadesGerenciais.Name = "cbAtividadesGerenciais";
            this.cbAtividadesGerenciais.Size = new System.Drawing.Size(128, 17);
            this.cbAtividadesGerenciais.TabIndex = 10;
            this.cbAtividadesGerenciais.Text = "Atividades Gerenciais";
            this.cbAtividadesGerenciais.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Preencha os campos para liberar acesso ao usuário.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "CPF ......:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nome ...:";
            // 
            // lbCodUsuario
            // 
            this.lbCodUsuario.AutoSize = true;
            this.lbCodUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodUsuario.Location = new System.Drawing.Point(109, 39);
            this.lbCodUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCodUsuario.Name = "lbCodUsuario";
            this.lbCodUsuario.Size = new System.Drawing.Size(21, 16);
            this.lbCodUsuario.TabIndex = 16;
            this.lbCodUsuario.Text = "-1";
            // 
            // txtCpf
            // 
            this.txtCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpf.Location = new System.Drawing.Point(109, 119);
            this.txtCpf.Mask = "000.000.000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(100, 22);
            this.txtCpf.TabIndex = 47;
            this.txtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCpf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCpf_KeyDown);
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpf_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 57;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(28, 398);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(277, 16);
            this.label18.TabIndex = 59;
            this.label18.Text = "Campos de preenchimento obrigatório.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(16, 398);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 20);
            this.label12.TabIndex = 61;
            this.label12.Text = "*";
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(857, 420);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCodUsuario);
            this.Name = "Usuarios";
            this.Text = "MOVIMENTAÇÕES DE USUÁRIOS";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.Controls.SetChildIndex(this.lbCodUsuario, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.txtCpf, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.AutorizarUsuario.ResumeLayout(false);
            this.AutorizarUsuario.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.GroupBox AutorizarUsuario;
        private System.Windows.Forms.RadioButton rbSim;
        private System.Windows.Forms.RadioButton rbNao;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbBackup;
        private System.Windows.Forms.CheckBox cbDespesas;
        private System.Windows.Forms.CheckBox cbRequisicoes;
        private System.Windows.Forms.CheckBox cbEntregas;
        private System.Windows.Forms.CheckBox cbPedidos;
        private System.Windows.Forms.CheckBox cbOrcamentos;
        private System.Windows.Forms.CheckBox cbProdutos;
        private System.Windows.Forms.CheckBox cbClientes;
        private System.Windows.Forms.CheckBox cbAtividadesGerenciais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCodUsuario;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
    }
}
