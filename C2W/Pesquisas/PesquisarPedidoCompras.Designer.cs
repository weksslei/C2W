namespace C2W
{
    partial class PesquisarPedidoCompras
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
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbComprasReceber = new System.Windows.Forms.RadioButton();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.ListaCompras = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aceita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.listaProdutosComprados = new System.Windows.Forms.ListView();
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnReceberPedido = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataFinal.Location = new System.Drawing.Point(901, 35);
            this.mtbDataFinal.Mask = "00/00/0000";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 26);
            this.mtbDataFinal.TabIndex = 98;
            this.mtbDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataFinal_KeyDown);
            this.mtbDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataFinal_KeyPress);
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataInicial.Location = new System.Drawing.Point(643, 35);
            this.mtbDataInicial.Mask = "00/00/0000";
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.Size = new System.Drawing.Size(100, 26);
            this.mtbDataInicial.TabIndex = 97;
            this.mtbDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataInicial_KeyDown);
            this.mtbDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataInicial_KeyPress);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.Location = new System.Drawing.Point(769, 38);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(126, 23);
            this.lblDataFinal.TabIndex = 96;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbComprasReceber);
            this.groupBox1.Controls.Add(this.rbPeriodo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 85);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exibir Compras por:";
            // 
            // rbComprasReceber
            // 
            this.rbComprasReceber.AutoSize = true;
            this.rbComprasReceber.Checked = true;
            this.rbComprasReceber.Location = new System.Drawing.Point(34, 30);
            this.rbComprasReceber.Name = "rbComprasReceber";
            this.rbComprasReceber.Size = new System.Drawing.Size(159, 20);
            this.rbComprasReceber.TabIndex = 70;
            this.rbComprasReceber.TabStop = true;
            this.rbComprasReceber.Text = "Compras a receber";
            this.rbComprasReceber.UseVisualStyleBackColor = true;
            this.rbComprasReceber.Click += new System.EventHandler(this.rbComprasReceber_Click);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Location = new System.Drawing.Point(236, 30);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(81, 20);
            this.rbPeriodo.TabIndex = 69;
            this.rbPeriodo.Text = "Período";
            this.rbPeriodo.UseVisualStyleBackColor = true;
            this.rbPeriodo.Click += new System.EventHandler(this.rbPeriodo_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(2, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(740, 49);
            this.button1.TabIndex = 94;
            this.button1.Text = "COMPRAS REALIZADAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListaCompras
            // 
            this.ListaCompras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome_empresa,
            this.data,
            this.total,
            this.aceita});
            this.ListaCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaCompras.FullRowSelect = true;
            this.ListaCompras.GridLines = true;
            this.ListaCompras.Location = new System.Drawing.Point(3, 158);
            this.ListaCompras.MultiSelect = false;
            this.ListaCompras.Name = "ListaCompras";
            this.ListaCompras.Size = new System.Drawing.Size(740, 554);
            this.ListaCompras.TabIndex = 93;
            this.ListaCompras.UseCompatibleStateImageBehavior = false;
            this.ListaCompras.View = System.Windows.Forms.View.Details;
            this.ListaCompras.SelectedIndexChanged += new System.EventHandler(this.ListaCompras_SelectedIndexChanged);
            this.ListaCompras.DoubleClick += new System.EventHandler(this.ListaCompras_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 72;
            // 
            // nome_empresa
            // 
            this.nome_empresa.Text = "Fornecedor";
            this.nome_empresa.Width = 284;
            // 
            // data
            // 
            this.data.Text = "Data";
            this.data.Width = 106;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.Width = 116;
            // 
            // aceita
            // 
            this.aceita.Text = "Compra Recebida?";
            this.aceita.Width = 151;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(748, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(523, 49);
            this.button2.TabIndex = 92;
            this.button2.Text = "PRODUTOS  SOLICITADOS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listaProdutosComprados
            // 
            this.listaProdutosComprados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Produto,
            this.Quantidade,
            this.Custo});
            this.listaProdutosComprados.Enabled = false;
            this.listaProdutosComprados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProdutosComprados.FullRowSelect = true;
            this.listaProdutosComprados.GridLines = true;
            this.listaProdutosComprados.Location = new System.Drawing.Point(749, 158);
            this.listaProdutosComprados.MultiSelect = false;
            this.listaProdutosComprados.Name = "listaProdutosComprados";
            this.listaProdutosComprados.Size = new System.Drawing.Size(522, 554);
            this.listaProdutosComprados.TabIndex = 91;
            this.listaProdutosComprados.UseCompatibleStateImageBehavior = false;
            this.listaProdutosComprados.View = System.Windows.Forms.View.Details;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 275;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 106;
            // 
            // Custo
            // 
            this.Custo.Text = "Custo";
            this.Custo.Width = 113;
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicial.Location = new System.Drawing.Point(499, 35);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(138, 23);
            this.lblDataInicial.TabIndex = 90;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1128, 17);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(135, 38);
            this.btnPesquisar.TabIndex = 99;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1168, 718);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 49);
            this.btnFechar.TabIndex = 101;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(1020, 718);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(141, 49);
            this.btnOK.TabIndex = 100;
            this.btnOK.Text = "Visualizar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(3, 718);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(236, 49);
            this.btnNovo.TabIndex = 102;
            this.btnNovo.Text = "Inserir Nova Compra";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnReceberPedido
            // 
            this.btnReceberPedido.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReceberPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceberPedido.Location = new System.Drawing.Point(507, 718);
            this.btnReceberPedido.Name = "btnReceberPedido";
            this.btnReceberPedido.Size = new System.Drawing.Size(236, 49);
            this.btnReceberPedido.TabIndex = 103;
            this.btnReceberPedido.Text = "Receber Pedido de Compra";
            this.btnReceberPedido.UseVisualStyleBackColor = true;
            this.btnReceberPedido.Click += new System.EventHandler(this.btnReceberPedido_Click);
            // 
            // PesquisarPedidoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnReceberPedido);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaCompras);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listaProdutosComprados);
            this.Controls.Add(this.lblDataInicial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarPedidoCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DOS PEDIDOS DE COMPRAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarPedidoCompras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarPedidoCompras_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbDataFinal;
        private System.Windows.Forms.MaskedTextBox mtbDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbComprasReceber;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaCompras;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome_empresa;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader aceita;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listaProdutosComprados;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Custo;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnReceberPedido;
    }
}