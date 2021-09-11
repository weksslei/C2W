namespace C2W
{
    partial class AnaliseDeCotacoes
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
            this.ListaAnaliseCotacoes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor_Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEliminarResíduos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListaAnaliseCotacoes
            // 
            this.ListaAnaliseCotacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.idProduto,
            this.Quantidade,
            this.Valor_Custo,
            this.idFornecedor,
            this.columnHeader1});
            this.ListaAnaliseCotacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaAnaliseCotacoes.FullRowSelect = true;
            this.ListaAnaliseCotacoes.GridLines = true;
            this.ListaAnaliseCotacoes.Location = new System.Drawing.Point(7, 91);
            this.ListaAnaliseCotacoes.MultiSelect = false;
            this.ListaAnaliseCotacoes.Name = "ListaAnaliseCotacoes";
            this.ListaAnaliseCotacoes.Size = new System.Drawing.Size(1266, 542);
            this.ListaAnaliseCotacoes.TabIndex = 84;
            this.ListaAnaliseCotacoes.UseCompatibleStateImageBehavior = false;
            this.ListaAnaliseCotacoes.View = System.Windows.Forms.View.Details;
            this.ListaAnaliseCotacoes.SelectedIndexChanged += new System.EventHandler(this.ListaAnaliseCotacoes_SelectedIndexChanged);
            this.ListaAnaliseCotacoes.DoubleClick += new System.EventHandler(this.ListaAnaliseCotacoes_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Cotação";
            this.id.Width = 95;
            // 
            // idProduto
            // 
            this.idProduto.Text = "Descrição Produto";
            this.idProduto.Width = 330;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 108;
            // 
            // Valor_Custo
            // 
            this.Valor_Custo.Text = "Custo";
            this.Valor_Custo.Width = 130;
            // 
            // idFornecedor
            // 
            this.idFornecedor.Text = "Fornecedor";
            this.idFornecedor.Width = 370;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Status da Análise";
            this.columnHeader1.Width = 224;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1266, 59);
            this.button1.TabIndex = 85;
            this.button1.Text = "RESUMO DA ANÁLISE DAS COTAÇÕES SELECIONADAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(7, 700);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(244, 61);
            this.btnNovo.TabIndex = 103;
            this.btnNovo.Text = "Inserir Nova Compra";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1061, 700);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(212, 61);
            this.btnFechar.TabIndex = 104;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Aquamarine;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(589, 700);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(405, 61);
            this.button3.TabIndex = 106;
            this.button3.Text = "Status da melhor opção de compra";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnEliminarResíduos
            // 
            this.btnEliminarResíduos.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEliminarResíduos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarResíduos.Location = new System.Drawing.Point(280, 700);
            this.btnEliminarResíduos.Name = "btnEliminarResíduos";
            this.btnEliminarResíduos.Size = new System.Drawing.Size(244, 61);
            this.btnEliminarResíduos.TabIndex = 107;
            this.btnEliminarResíduos.Text = "Eliminar Resíduos";
            this.btnEliminarResíduos.UseVisualStyleBackColor = true;
            this.btnEliminarResíduos.Click += new System.EventHandler(this.btnEliminarResíduos_Click);
            // 
            // AnaliseDeCotacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnEliminarResíduos);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaAnaliseCotacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaliseDeCotacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANALISANDO MELHOR OPÇÃO DO MERCADO PARA COMPRAR.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaliseDeCotacoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnaliseDeCotacoes_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListaAnaliseCotacoes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader idProduto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Valor_Custo;
        private System.Windows.Forms.ColumnHeader idFornecedor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnEliminarResíduos;
    }
}