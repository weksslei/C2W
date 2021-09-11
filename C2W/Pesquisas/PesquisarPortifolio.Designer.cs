namespace C2W
{
    partial class PesquisarPortifolio
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
            this.txtPesquisarFornecedores = new System.Windows.Forms.TextBox();
            this.btnFiltrarFornecedor = new System.Windows.Forms.Button();
            this.ListaFornecedores = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_vendedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaProdutos = new System.Windows.Forms.ListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovoPortifolio = new System.Windows.Forms.Button();
            this.txtPesquisarProdutos = new System.Windows.Forms.TextBox();
            this.btnFiltrarProdutos = new System.Windows.Forms.Button();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(12, 23);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(353, 23);
            this.lblPesquisar.TabIndex = 15;
            this.lblPesquisar.Text = "Selecione Fornecedor e Produto:";
            // 
            // txtPesquisarFornecedores
            // 
            this.txtPesquisarFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarFornecedores.Location = new System.Drawing.Point(378, 20);
            this.txtPesquisarFornecedores.Name = "txtPesquisarFornecedores";
            this.txtPesquisarFornecedores.Size = new System.Drawing.Size(347, 26);
            this.txtPesquisarFornecedores.TabIndex = 14;
            this.txtPesquisarFornecedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisarFornecedores_KeyDown);
            // 
            // btnFiltrarFornecedor
            // 
            this.btnFiltrarFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarFornecedor.Location = new System.Drawing.Point(729, 16);
            this.btnFiltrarFornecedor.Name = "btnFiltrarFornecedor";
            this.btnFiltrarFornecedor.Size = new System.Drawing.Size(107, 31);
            this.btnFiltrarFornecedor.TabIndex = 13;
            this.btnFiltrarFornecedor.Text = "FILTRAR";
            this.btnFiltrarFornecedor.UseVisualStyleBackColor = true;
            this.btnFiltrarFornecedor.Click += new System.EventHandler(this.btnFiltrarFornecedor_Click);
            // 
            // ListaFornecedores
            // 
            this.ListaFornecedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome_empresa,
            this.nome_vendedor,
            this.fone1});
            this.ListaFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaFornecedores.FullRowSelect = true;
            this.ListaFornecedores.GridLines = true;
            this.ListaFornecedores.Location = new System.Drawing.Point(16, 108);
            this.ListaFornecedores.MultiSelect = false;
            this.ListaFornecedores.Name = "ListaFornecedores";
            this.ListaFornecedores.Size = new System.Drawing.Size(823, 582);
            this.ListaFornecedores.TabIndex = 62;
            this.ListaFornecedores.UseCompatibleStateImageBehavior = false;
            this.ListaFornecedores.View = System.Windows.Forms.View.Details;
            this.ListaFornecedores.SelectedIndexChanged += new System.EventHandler(this.ListaFornecedores_SelectedIndexChanged);
            this.ListaFornecedores.DoubleClick += new System.EventHandler(this.ListaFornecedores_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 87;
            // 
            // nome_empresa
            // 
            this.nome_empresa.Text = "Empresa";
            this.nome_empresa.Width = 284;
            // 
            // nome_vendedor
            // 
            this.nome_vendedor.Text = "Vendedor";
            this.nome_vendedor.Width = 310;
            // 
            // fone1
            // 
            this.fone1.Text = "Telefone 1";
            this.fone1.Width = 126;
            // 
            // ListaProdutos
            // 
            this.ListaProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.Descricao});
            this.ListaProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaProdutos.FullRowSelect = true;
            this.ListaProdutos.GridLines = true;
            this.ListaProdutos.Location = new System.Drawing.Point(845, 108);
            this.ListaProdutos.MultiSelect = false;
            this.ListaProdutos.Name = "ListaProdutos";
            this.ListaProdutos.Size = new System.Drawing.Size(419, 582);
            this.ListaProdutos.TabIndex = 63;
            this.ListaProdutos.UseCompatibleStateImageBehavior = false;
            this.ListaProdutos.View = System.Windows.Forms.View.Details;
            this.ListaProdutos.SelectedIndexChanged += new System.EventHandler(this.ListaProdutos_SelectedIndexChanged);
            this.ListaProdutos.DoubleClick += new System.EventHandler(this.ListaProdutos_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.Text = "Código";
            this.Codigo.Width = 74;
            // 
            // Descricao
            // 
            this.Descricao.Text = "Descrição do Produto";
            this.Descricao.Width = 309;
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1154, 718);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 43);
            this.btnFechar.TabIndex = 65;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovoPortifolio
            // 
            this.btnNovoPortifolio.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovoPortifolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoPortifolio.Location = new System.Drawing.Point(16, 718);
            this.btnNovoPortifolio.Name = "btnNovoPortifolio";
            this.btnNovoPortifolio.Size = new System.Drawing.Size(161, 43);
            this.btnNovoPortifolio.TabIndex = 66;
            this.btnNovoPortifolio.Text = "Gravar Portifolio";
            this.btnNovoPortifolio.UseVisualStyleBackColor = true;
            this.btnNovoPortifolio.Click += new System.EventHandler(this.btnNovoPortifolio_Click);
            // 
            // txtPesquisarProdutos
            // 
            this.txtPesquisarProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarProdutos.Location = new System.Drawing.Point(845, 20);
            this.txtPesquisarProdutos.Name = "txtPesquisarProdutos";
            this.txtPesquisarProdutos.Size = new System.Drawing.Size(311, 26);
            this.txtPesquisarProdutos.TabIndex = 67;
            this.txtPesquisarProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisarProdutos_KeyDown);
            // 
            // btnFiltrarProdutos
            // 
            this.btnFiltrarProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarProdutos.Location = new System.Drawing.Point(1157, 15);
            this.btnFiltrarProdutos.Name = "btnFiltrarProdutos";
            this.btnFiltrarProdutos.Size = new System.Drawing.Size(107, 31);
            this.btnFiltrarProdutos.TabIndex = 68;
            this.btnFiltrarProdutos.Text = "FILTRAR";
            this.btnFiltrarProdutos.UseVisualStyleBackColor = true;
            this.btnFiltrarProdutos.Click += new System.EventHandler(this.btnFiltrarProdutos_Click);
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedor.Location = new System.Drawing.Point(502, 699);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(16, 24);
            this.lblFornecedor.TabIndex = 69;
            this.lblFornecedor.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 737);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 70;
            this.label1.Text = "Produto Selecionado: ";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(502, 737);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(16, 24);
            this.lblProduto.TabIndex = 71;
            this.lblProduto.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 699);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 24);
            this.label3.TabIndex = 72;
            this.label3.Text = "Fornecedor Selecionado: ";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(823, 49);
            this.button1.TabIndex = 96;
            this.button1.Text = "LISTA DE FORNECEDORES CADASTRADOS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(845, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(419, 49);
            this.button2.TabIndex = 97;
            this.button2.Text = "LISTA DE PRODUTOS CADASTRADOS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PesquisarPortifolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.btnFiltrarProdutos);
            this.Controls.Add(this.txtPesquisarProdutos);
            this.Controls.Add(this.btnNovoPortifolio);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.ListaProdutos);
            this.Controls.Add(this.ListaFornecedores);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisarFornecedores);
            this.Controls.Add(this.btnFiltrarFornecedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarPortifolio";
            this.Text = "MOVIMENTAÇÃO DE PORTIFOLIOS DE MEUS FORNECEDORES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarPortifolio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarPortifolio_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPesquisar;
        public System.Windows.Forms.TextBox txtPesquisarFornecedores;
        private System.Windows.Forms.Button btnFiltrarFornecedor;
        private System.Windows.Forms.ListView ListaFornecedores;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome_empresa;
        private System.Windows.Forms.ColumnHeader nome_vendedor;
        private System.Windows.Forms.ColumnHeader fone1;
        private System.Windows.Forms.ListView ListaProdutos;
        private System.Windows.Forms.ColumnHeader Codigo;
        private System.Windows.Forms.ColumnHeader Descricao;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnNovoPortifolio;
        public System.Windows.Forms.TextBox txtPesquisarProdutos;
        private System.Windows.Forms.Button btnFiltrarProdutos;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}