namespace C2W
{
    partial class Relatorio_Pedido_Compras
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
            this.listaProdutosComprados = new System.Windows.Forms.ListView();
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFechar = new System.Windows.Forms.Button();
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1229, 49);
            this.button1.TabIndex = 95;
            this.button1.Text = "RELATÓRIO DE COMPRAS REALIZADAS NOS ÚLTIMOS 06 MESES";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listaProdutosComprados
            // 
            this.listaProdutosComprados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.Produto,
            this.Quantidade,
            this.Custo,
            this.data});
            this.listaProdutosComprados.Enabled = false;
            this.listaProdutosComprados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProdutosComprados.FullRowSelect = true;
            this.listaProdutosComprados.GridLines = true;
            this.listaProdutosComprados.Location = new System.Drawing.Point(25, 67);
            this.listaProdutosComprados.MultiSelect = false;
            this.listaProdutosComprados.Name = "listaProdutosComprados";
            this.listaProdutosComprados.Size = new System.Drawing.Size(1229, 599);
            this.listaProdutosComprados.TabIndex = 96;
            this.listaProdutosComprados.UseCompatibleStateImageBehavior = false;
            this.listaProdutosComprados.View = System.Windows.Forms.View.Details;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 413;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 120;
            // 
            // Custo
            // 
            this.Custo.Text = "Custo";
            this.Custo.Width = 151;
            // 
            // Codigo
            // 
            this.Codigo.Text = "Código Produto";
            this.Codigo.Width = 125;
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1117, 672);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(137, 73);
            this.btnFechar.TabIndex = 102;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // data
            // 
            this.data.Text = "Data da compra";
            this.data.Width = 154;
            // 
            // Relatorio_Pedido_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.listaProdutosComprados);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio_Pedido_Compras";
            this.Text = "Relatório de Pedido de Compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorio_Pedido_Compras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_Pedido_Compras_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listaProdutosComprados;
        private System.Windows.Forms.ColumnHeader Codigo;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Custo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ColumnHeader data;
    }
}