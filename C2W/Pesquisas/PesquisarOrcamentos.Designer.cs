namespace C2W
{
    partial class PesquisarOrcamentos
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.OpcaoPesquisa = new System.Windows.Forms.ComboBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.ListaOrcamentos = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aceito = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.btnGerarPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1227, 49);
            this.button1.TabIndex = 85;
            this.button1.Text = "ORÇAMENTOS REALIZADOS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(12, 715);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(236, 49);
            this.btnNovo.TabIndex = 86;
            this.btnNovo.Text = "Realizar Novo Orçamento";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1143, 718);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 43);
            this.btnFechar.TabIndex = 88;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Location = new System.Drawing.Point(998, 718);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(139, 43);
            this.btnVisualizar.TabIndex = 87;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // OpcaoPesquisa
            // 
            this.OpcaoPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OpcaoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpcaoPesquisa.FormattingEnabled = true;
            this.OpcaoPesquisa.Items.AddRange(new object[] {
            "Nome do Cliente",
            "Vendas não efetuadas",
            "Período"});
            this.OpcaoPesquisa.Location = new System.Drawing.Point(320, 11);
            this.OpcaoPesquisa.Name = "OpcaoPesquisa";
            this.OpcaoPesquisa.Size = new System.Drawing.Size(252, 28);
            this.OpcaoPesquisa.TabIndex = 101;
            this.OpcaoPesquisa.SelectedIndexChanged += new System.EventHandler(this.OpcaoPesquisa_SelectedIndexChanged);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(8, 16);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(306, 23);
            this.lblPesquisar.TabIndex = 100;
            this.lblPesquisar.Text = "Localizar Informações por: ";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(585, 11);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(374, 27);
            this.txtPesquisar.TabIndex = 99;
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataFinal.Location = new System.Drawing.Point(983, 11);
            this.mtbDataFinal.Mask = "00/00/0000";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 26);
            this.mtbDataFinal.TabIndex = 105;
            this.mtbDataFinal.Visible = false;
            this.mtbDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataFinal_KeyDown);
            this.mtbDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataFinal_KeyPress);
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataInicial.Location = new System.Drawing.Point(725, 11);
            this.mtbDataInicial.Mask = "00/00/0000";
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.Size = new System.Drawing.Size(100, 26);
            this.mtbDataInicial.TabIndex = 104;
            this.mtbDataInicial.Visible = false;
            this.mtbDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataInicial_KeyDown);
            this.mtbDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataInicial_KeyPress);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.Location = new System.Drawing.Point(851, 14);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(126, 23);
            this.lblDataFinal.TabIndex = 103;
            this.lblDataFinal.Text = "Data Final:";
            this.lblDataFinal.Visible = false;
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicial.Location = new System.Drawing.Point(581, 11);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(138, 23);
            this.lblDataInicial.TabIndex = 102;
            this.lblDataInicial.Text = "Data Inicial:";
            this.lblDataInicial.Visible = false;
            // 
            // ListaOrcamentos
            // 
            this.ListaOrcamentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.idCliente,
            this.data,
            this.total,
            this.aceito});
            this.ListaOrcamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaOrcamentos.FullRowSelect = true;
            this.ListaOrcamentos.GridLines = true;
            this.ListaOrcamentos.Location = new System.Drawing.Point(12, 124);
            this.ListaOrcamentos.MultiSelect = false;
            this.ListaOrcamentos.Name = "ListaOrcamentos";
            this.ListaOrcamentos.Size = new System.Drawing.Size(1227, 591);
            this.ListaOrcamentos.TabIndex = 106;
            this.ListaOrcamentos.UseCompatibleStateImageBehavior = false;
            this.ListaOrcamentos.View = System.Windows.Forms.View.Details;
            this.ListaOrcamentos.SelectedIndexChanged += new System.EventHandler(this.ListaOrcamentos_SelectedIndexChanged);
            this.ListaOrcamentos.DoubleClick += new System.EventHandler(this.ListaOrcamentos_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Código";
            this.id.Width = 94;
            // 
            // idCliente
            // 
            this.idCliente.Text = "Nome do Cliente";
            this.idCliente.Width = 525;
            // 
            // data
            // 
            this.data.Text = "Data do Orçamento";
            this.data.Width = 163;
            // 
            // total
            // 
            this.total.Text = "Total do Orçamento";
            this.total.Width = 191;
            // 
            // aceito
            // 
            this.aceito.Text = "Venda Efetuada?";
            this.aceito.Width = 185;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1103, 13);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(135, 52);
            this.btnPesquisar.TabIndex = 107;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(585, 11);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(512, 28);
            this.cbClientes.TabIndex = 108;
            this.cbClientes.Visible = false;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            // 
            // btnGerarPedido
            // 
            this.btnGerarPedido.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGerarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarPedido.Location = new System.Drawing.Point(483, 715);
            this.btnGerarPedido.Name = "btnGerarPedido";
            this.btnGerarPedido.Size = new System.Drawing.Size(236, 49);
            this.btnGerarPedido.TabIndex = 109;
            this.btnGerarPedido.Text = "Gerar Pedido/Venda";
            this.btnGerarPedido.UseVisualStyleBackColor = true;
            this.btnGerarPedido.Click += new System.EventHandler(this.btnGerarPedido_Click);
            // 
            // PesquisarOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnGerarPedido);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.ListaOrcamentos);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.OpcaoPesquisa);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarOrcamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DE ORÇAMENTOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarOrcamentos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarOrcamentos_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.ComboBox OpcaoPesquisa;
        private System.Windows.Forms.Label lblPesquisar;
        public System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.MaskedTextBox mtbDataFinal;
        private System.Windows.Forms.MaskedTextBox mtbDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.ListView ListaOrcamentos;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader idCliente;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader aceito;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.Button btnGerarPedido;
    }
}