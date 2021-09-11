namespace C2W
{
    partial class PesquisarPedidosVendas
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
            this.ListaVendas = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.concluido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entregar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.OpcaoPesquisa = new System.Windows.Forms.ComboBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.cbNovoPedido = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDesconto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListaVendas
            // 
            this.ListaVendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome,
            this.data,
            this.total,
            this.observacao,
            this.concluido,
            this.entregar});
            this.ListaVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaVendas.FullRowSelect = true;
            this.ListaVendas.GridLines = true;
            this.ListaVendas.Location = new System.Drawing.Point(2, 140);
            this.ListaVendas.MultiSelect = false;
            this.ListaVendas.Name = "ListaVendas";
            this.ListaVendas.Size = new System.Drawing.Size(1269, 554);
            this.ListaVendas.TabIndex = 94;
            this.ListaVendas.UseCompatibleStateImageBehavior = false;
            this.ListaVendas.View = System.Windows.Forms.View.Details;
            this.ListaVendas.SelectedIndexChanged += new System.EventHandler(this.ListaCompras_SelectedIndexChanged);
            this.ListaVendas.DoubleClick += new System.EventHandler(this.ListaCompras_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Código";
            this.id.Width = 72;
            // 
            // nome
            // 
            this.nome.Text = "Cliente";
            this.nome.Width = 309;
            // 
            // data
            // 
            this.data.Text = "Data";
            this.data.Width = 106;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.Width = 105;
            // 
            // observacao
            // 
            this.observacao.Text = "Observação";
            this.observacao.Width = 385;
            // 
            // concluido
            // 
            this.concluido.Text = "Concluído ?";
            this.concluido.Width = 98;
            // 
            // entregar
            // 
            this.entregar.Text = "Status de Entregas";
            this.entregar.Width = 188;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(2, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1269, 49);
            this.button1.TabIndex = 97;
            this.button1.Text = "TABELA DOS PEDIDOS DE CLIENTES ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1122, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(149, 57);
            this.btnPesquisar.TabIndex = 100;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataFinal.Location = new System.Drawing.Point(969, 27);
            this.mtbDataFinal.Mask = "00/00/0000";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 26);
            this.mtbDataFinal.TabIndex = 104;
            this.mtbDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataFinal_KeyDown);
            this.mtbDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataFinal_KeyPress);
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataInicial.Location = new System.Drawing.Point(731, 27);
            this.mtbDataInicial.Mask = "00/00/0000";
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.Size = new System.Drawing.Size(100, 26);
            this.mtbDataInicial.TabIndex = 103;
            this.mtbDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataInicial_KeyDown);
            this.mtbDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataInicial_KeyPress);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.Location = new System.Drawing.Point(837, 30);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(126, 23);
            this.lblDataFinal.TabIndex = 102;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicial.Location = new System.Drawing.Point(587, 30);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(138, 23);
            this.lblDataInicial.TabIndex = 101;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1175, 712);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 49);
            this.btnFechar.TabIndex = 107;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Location = new System.Drawing.Point(1027, 712);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(141, 49);
            this.btnVisualizar.TabIndex = 106;
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
            "Pedidos não finalizados",
            "Pedidos a entregar",
            "Pedidos de um Cliente",
            "Cliente a finalizar",
            "Período"});
            this.OpcaoPesquisa.Location = new System.Drawing.Point(324, 22);
            this.OpcaoPesquisa.Name = "OpcaoPesquisa";
            this.OpcaoPesquisa.Size = new System.Drawing.Size(252, 28);
            this.OpcaoPesquisa.TabIndex = 110;
            this.OpcaoPesquisa.SelectedIndexChanged += new System.EventHandler(this.OpcaoPesquisa_SelectedIndexChanged);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(12, 27);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(306, 23);
            this.lblPesquisar.TabIndex = 109;
            this.lblPesquisar.Text = "Localizar Informações por: ";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(671, 26);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(374, 27);
            this.txtPesquisar.TabIndex = 111;
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(591, 25);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(512, 28);
            this.cbClientes.TabIndex = 112;
            this.cbClientes.Visible = false;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            // 
            // cbNovoPedido
            // 
            this.cbNovoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNovoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNovoPedido.FormattingEnabled = true;
            this.cbNovoPedido.Items.AddRange(new object[] {
            "Escolher Orçamento",
            "Sem Orçamento"});
            this.cbNovoPedido.Location = new System.Drawing.Point(296, 705);
            this.cbNovoPedido.Name = "cbNovoPedido";
            this.cbNovoPedido.Size = new System.Drawing.Size(381, 28);
            this.cbNovoPedido.TabIndex = 113;
            this.cbNovoPedido.SelectedIndexChanged += new System.EventHandler(this.cbNovoPedido_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 710);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 23);
            this.label1.TabIndex = 114;
            this.label1.Text = "Inserir Novo Pedido por ->";
            // 
            // btnDesconto
            // 
            this.btnDesconto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesconto.Location = new System.Drawing.Point(781, 712);
            this.btnDesconto.Name = "btnDesconto";
            this.btnDesconto.Size = new System.Drawing.Size(201, 49);
            this.btnDesconto.TabIndex = 115;
            this.btnDesconto.Text = "Conceder Desconto";
            this.btnDesconto.UseVisualStyleBackColor = true;
            this.btnDesconto.Click += new System.EventHandler(this.btnDesconto_Click);
            // 
            // PesquisarPedidosVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnDesconto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNovoPedido);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.OpcaoPesquisa);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaVendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarPedidosVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DOS PEDIDOS DE VENDAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarPedidosVendas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarPedidosVendas_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListaVendas;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader concluido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.MaskedTextBox mtbDataFinal;
        private System.Windows.Forms.MaskedTextBox mtbDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.ComboBox OpcaoPesquisa;
        private System.Windows.Forms.Label lblPesquisar;
        public System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.ColumnHeader observacao;
        private System.Windows.Forms.ColumnHeader entregar;
        private System.Windows.Forms.ComboBox cbNovoPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDesconto;
    }
}