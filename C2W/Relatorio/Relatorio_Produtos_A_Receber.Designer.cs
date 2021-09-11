namespace C2W
{
    partial class Relatorio_Produtos_A_Receber
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ListaCompras = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aceita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listaProdutosComprados = new System.Windows.Forms.ListView();
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Anos = new System.Windows.Forms.ComboBox();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.Meses = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1157, 712);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(112, 49);
            this.btnFechar.TabIndex = 106;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(740, 49);
            this.button1.TabIndex = 104;
            this.button1.Text = "COMPRAS REALIZADAS NO PERÍODO";
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
            this.ListaCompras.Location = new System.Drawing.Point(5, 152);
            this.ListaCompras.MultiSelect = false;
            this.ListaCompras.Name = "ListaCompras";
            this.ListaCompras.Size = new System.Drawing.Size(740, 554);
            this.ListaCompras.TabIndex = 103;
            this.ListaCompras.UseCompatibleStateImageBehavior = false;
            this.ListaCompras.View = System.Windows.Forms.View.Details;
            this.ListaCompras.SelectedIndexChanged += new System.EventHandler(this.ListaCompras_SelectedIndexChanged);
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
            this.listaProdutosComprados.Location = new System.Drawing.Point(747, 152);
            this.listaProdutosComprados.MultiSelect = false;
            this.listaProdutosComprados.Name = "listaProdutosComprados";
            this.listaProdutosComprados.Size = new System.Drawing.Size(522, 554);
            this.listaProdutosComprados.TabIndex = 102;
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
            // Anos
            // 
            this.Anos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Anos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Anos.FormattingEnabled = true;
            this.Anos.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.Anos.Location = new System.Drawing.Point(658, 12);
            this.Anos.Name = "Anos";
            this.Anos.Size = new System.Drawing.Size(121, 28);
            this.Anos.TabIndex = 135;
            this.Anos.SelectedIndexChanged += new System.EventHandler(this.Anos_SelectedIndexChanged);
            // 
            // btnEmitir
            // 
            this.btnEmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmitir.Location = new System.Drawing.Point(1071, 12);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(198, 57);
            this.btnEmitir.TabIndex = 134;
            this.btnEmitir.Text = "Emitir Relatório";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(1, 17);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(424, 23);
            this.lblPesquisar.TabIndex = 133;
            this.lblPesquisar.Text = "Selecionar mês e ano de referência => ";
            // 
            // Meses
            // 
            this.Meses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Meses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Meses.FormattingEnabled = true;
            this.Meses.Items.AddRange(new object[] {
            "JANEIRO",
            "FEVEREIRO",
            "MARÇO",
            "ABRIL",
            "MAIO",
            "JUNHO",
            "JULHO",
            "AGOSTO",
            "SETEMBRO",
            "OUTUBRO",
            "NOVEMBRO",
            "DEZEMBRO"});
            this.Meses.Location = new System.Drawing.Point(451, 12);
            this.Meses.Name = "Meses";
            this.Meses.Size = new System.Drawing.Size(167, 28);
            this.Meses.TabIndex = 132;
            this.Meses.SelectedIndexChanged += new System.EventHandler(this.Meses_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(746, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(523, 49);
            this.button2.TabIndex = 136;
            this.button2.Text = "PRODUTOS  SOLICITADOS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Peru;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(4, 712);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(294, 49);
            this.button3.TabIndex = 137;
            this.button3.Text = "Produtos não recebidos";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Relatorio_Produtos_A_Receber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Anos);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.Meses);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaCompras);
            this.Controls.Add(this.listaProdutosComprados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio_Produtos_A_Receber";
            this.Text = "Relatorio de Compras Realizadas em um período";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorio_Produtos_A_Receber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_Produtos_A_Receber_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaCompras;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome_empresa;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader aceita;
        private System.Windows.Forms.ListView listaProdutosComprados;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Custo;
        private System.Windows.Forms.ComboBox Anos;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.ComboBox Meses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}