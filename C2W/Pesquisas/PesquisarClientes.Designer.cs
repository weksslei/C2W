namespace C2W
{
    partial class PesquisarClientes
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
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PesquisaMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.listaClientes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt_nasc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.e_mail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNovo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OpcaoPesquisa = new System.Windows.Forms.ComboBox();
            this.DataNiverCliente = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(12, 18);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(306, 23);
            this.lblPesquisar.TabIndex = 9;
            this.lblPesquisar.Text = "Localizar Informações por: ";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(637, 14);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(374, 27);
            this.txtPesquisar.TabIndex = 8;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1112, 11);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(135, 33);
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1151, 693);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 43);
            this.btnFechar.TabIndex = 12;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(998, 693);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(131, 43);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Visualizar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PesquisaMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 751);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1276, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PesquisaMessage
            // 
            this.PesquisaMessage.Name = "PesquisaMessage";
            this.PesquisaMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // listaClientes
            // 
            this.listaClientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome,
            this.dt_nasc,
            this.cpf,
            this.e_mail,
            this.fone1,
            this.fone2});
            this.listaClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaClientes.FullRowSelect = true;
            this.listaClientes.GridLines = true;
            this.listaClientes.Location = new System.Drawing.Point(16, 102);
            this.listaClientes.MultiSelect = false;
            this.listaClientes.Name = "listaClientes";
            this.listaClientes.Size = new System.Drawing.Size(1231, 585);
            this.listaClientes.TabIndex = 13;
            this.listaClientes.UseCompatibleStateImageBehavior = false;
            this.listaClientes.View = System.Windows.Forms.View.Details;
            this.listaClientes.SelectedIndexChanged += new System.EventHandler(this.listaClientes_SelectedIndexChanged);
            this.listaClientes.DoubleClick += new System.EventHandler(this.listaClientes_DoubleClick);
            this.listaClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaClientes_KeyDown);
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 77;
            // 
            // nome
            // 
            this.nome.Text = "Nome Do Cliente";
            this.nome.Width = 401;
            // 
            // dt_nasc
            // 
            this.dt_nasc.Text = "Nascimento";
            this.dt_nasc.Width = 99;
            // 
            // cpf
            // 
            this.cpf.Text = "CPF";
            this.cpf.Width = 128;
            // 
            // e_mail
            // 
            this.e_mail.Text = "E-Mail";
            this.e_mail.Width = 286;
            // 
            // fone1
            // 
            this.fone1.Text = "Telefone 1";
            this.fone1.Width = 116;
            // 
            // fone2
            // 
            this.fone2.Text = "Telefone 2";
            this.fone2.Width = 115;
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(16, 693);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(146, 43);
            this.btnNovo.TabIndex = 14;
            this.btnNovo.Text = "Novo Cliente";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1231, 49);
            this.button1.TabIndex = 96;
            this.button1.Text = "CLIENTES ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OpcaoPesquisa
            // 
            this.OpcaoPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OpcaoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpcaoPesquisa.FormattingEnabled = true;
            this.OpcaoPesquisa.Items.AddRange(new object[] {
            "Nome do Cliente",
            "CPF",
            "Telefone",
            "Data Nascimento"});
            this.OpcaoPesquisa.Location = new System.Drawing.Point(337, 13);
            this.OpcaoPesquisa.Name = "OpcaoPesquisa";
            this.OpcaoPesquisa.Size = new System.Drawing.Size(252, 28);
            this.OpcaoPesquisa.TabIndex = 97;
            this.OpcaoPesquisa.SelectedIndexChanged += new System.EventHandler(this.OpcaoPesquisa_SelectedIndexChanged);
            // 
            // DataNiverCliente
            // 
            this.DataNiverCliente.Enabled = false;
            this.DataNiverCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataNiverCliente.Location = new System.Drawing.Point(637, 15);
            this.DataNiverCliente.Mask = "00/00/0000";
            this.DataNiverCliente.Name = "DataNiverCliente";
            this.DataNiverCliente.Size = new System.Drawing.Size(100, 26);
            this.DataNiverCliente.TabIndex = 98;
            this.DataNiverCliente.Visible = false;
            this.DataNiverCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataNiverCliente_KeyDown);
            this.DataNiverCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataNiverCliente_KeyPress);
            // 
            // PesquisarClientes
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.DataNiverCliente);
            this.Controls.Add(this.OpcaoPesquisa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.listaClientes);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btnPesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DE CLIENTES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarClientes_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPesquisar;
        public System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PesquisaMessage;
        private System.Windows.Forms.ListView listaClientes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader dt_nasc;
        private System.Windows.Forms.ColumnHeader cpf;
        private System.Windows.Forms.ColumnHeader e_mail;
        private System.Windows.Forms.ColumnHeader fone1;
        private System.Windows.Forms.ColumnHeader fone2;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox OpcaoPesquisa;
        private System.Windows.Forms.MaskedTextBox DataNiverCliente;
    }
}