namespace C2W
{
    partial class PesquisarCotacoesGeral
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
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listaProdutosCotados = new System.Windows.Forms.ListView();
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.ListaCotacoes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aceita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbComprasNaoEfetuadas = new System.Windows.Forms.RadioButton();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.mtbDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.btnAnalisarCotacoes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicial.Location = new System.Drawing.Point(346, 31);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(138, 23);
            this.lblDataInicial.TabIndex = 12;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1128, 16);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(135, 38);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(3, 718);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(236, 49);
            this.btnNovo.TabIndex = 55;
            this.btnNovo.Text = "Inserir Nova Cotação";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1168, 718);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 49);
            this.btnFechar.TabIndex = 54;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(1024, 718);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 49);
            this.btnOK.TabIndex = 53;
            this.btnOK.Text = "Visualizar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(748, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(515, 49);
            this.button2.TabIndex = 82;
            this.button2.Text = "PRODUTOS  COTADOS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listaProdutosCotados
            // 
            this.listaProdutosCotados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Produto,
            this.Quantidade,
            this.Custo});
            this.listaProdutosCotados.Enabled = false;
            this.listaProdutosCotados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProdutosCotados.FullRowSelect = true;
            this.listaProdutosCotados.GridLines = true;
            this.listaProdutosCotados.Location = new System.Drawing.Point(749, 158);
            this.listaProdutosCotados.MultiSelect = false;
            this.listaProdutosCotados.Name = "listaProdutosCotados";
            this.listaProdutosCotados.Size = new System.Drawing.Size(515, 554);
            this.listaProdutosCotados.TabIndex = 81;
            this.listaProdutosCotados.UseCompatibleStateImageBehavior = false;
            this.listaProdutosCotados.View = System.Windows.Forms.View.Details;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 275;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 111;
            // 
            // Custo
            // 
            this.Custo.Text = "Custo";
            this.Custo.Width = 113;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(740, 49);
            this.button1.TabIndex = 84;
            this.button1.Text = "COTAÇÕES REALIZADAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListaCotacoes
            // 
            this.ListaCotacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome_empresa,
            this.data,
            this.total,
            this.aceita});
            this.ListaCotacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaCotacoes.FullRowSelect = true;
            this.ListaCotacoes.GridLines = true;
            this.ListaCotacoes.Location = new System.Drawing.Point(3, 158);
            this.ListaCotacoes.Name = "ListaCotacoes";
            this.ListaCotacoes.Size = new System.Drawing.Size(740, 554);
            this.ListaCotacoes.TabIndex = 83;
            this.ListaCotacoes.UseCompatibleStateImageBehavior = false;
            this.ListaCotacoes.View = System.Windows.Forms.View.Details;
            this.ListaCotacoes.SelectedIndexChanged += new System.EventHandler(this.ListaCotacoes_SelectedIndexChanged);
            this.ListaCotacoes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaCotacoes_MouseDoubleClick);
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
            this.aceita.Text = "Compra Efetuada?";
            this.aceita.Width = 151;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbComprasNaoEfetuadas);
            this.groupBox1.Controls.Add(this.rbPeriodo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 85);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exibir Cotações por:";
            // 
            // rbComprasNaoEfetuadas
            // 
            this.rbComprasNaoEfetuadas.AutoSize = true;
            this.rbComprasNaoEfetuadas.Location = new System.Drawing.Point(26, 52);
            this.rbComprasNaoEfetuadas.Name = "rbComprasNaoEfetuadas";
            this.rbComprasNaoEfetuadas.Size = new System.Drawing.Size(191, 20);
            this.rbComprasNaoEfetuadas.TabIndex = 70;
            this.rbComprasNaoEfetuadas.Text = "Compras não efetuadas";
            this.rbComprasNaoEfetuadas.UseVisualStyleBackColor = true;
            this.rbComprasNaoEfetuadas.Click += new System.EventHandler(this.rbComprasNaoEfetuadas_Click);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Checked = true;
            this.rbPeriodo.Location = new System.Drawing.Point(26, 23);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(81, 20);
            this.rbPeriodo.TabIndex = 69;
            this.rbPeriodo.TabStop = true;
            this.rbPeriodo.Text = "Período";
            this.rbPeriodo.UseVisualStyleBackColor = true;
            this.rbPeriodo.Click += new System.EventHandler(this.rbPeriodo_Click);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.Location = new System.Drawing.Point(616, 34);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(126, 23);
            this.lblDataFinal.TabIndex = 86;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataInicial.Location = new System.Drawing.Point(490, 31);
            this.mtbDataInicial.Mask = "00/00/0000";
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.Size = new System.Drawing.Size(100, 26);
            this.mtbDataInicial.TabIndex = 88;
            this.mtbDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataInicial_KeyDown);
            this.mtbDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataInicial_KeyPress);
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataFinal.Location = new System.Drawing.Point(748, 31);
            this.mtbDataFinal.Mask = "00/00/0000";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 26);
            this.mtbDataFinal.TabIndex = 89;
            this.mtbDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataFinal_KeyDown);
            this.mtbDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataFinal_KeyPress);
            // 
            // btnAnalisarCotacoes
            // 
            this.btnAnalisarCotacoes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAnalisarCotacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalisarCotacoes.Location = new System.Drawing.Point(507, 718);
            this.btnAnalisarCotacoes.Name = "btnAnalisarCotacoes";
            this.btnAnalisarCotacoes.Size = new System.Drawing.Size(236, 49);
            this.btnAnalisarCotacoes.TabIndex = 90;
            this.btnAnalisarCotacoes.Text = "Analisar Cotações";
            this.btnAnalisarCotacoes.UseVisualStyleBackColor = true;
            this.btnAnalisarCotacoes.Click += new System.EventHandler(this.btnAnalisarCotacoes_Click);
            // 
            // PesquisarCotacoesGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnAnalisarCotacoes);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaCotacoes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listaProdutosCotados);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.btnPesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarCotacoesGeral";
            this.Text = "MOVIMENTAÇÃO DE COTAÇÕES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarCotacoesGeral_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarCotacoesGeral_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listaProdutosCotados;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Custo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaCotacoes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome_empresa;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader aceita;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbComprasNaoEfetuadas;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.MaskedTextBox mtbDataInicial;
        private System.Windows.Forms.MaskedTextBox mtbDataFinal;
        private System.Windows.Forms.Button btnAnalisarCotacoes;
    }
}