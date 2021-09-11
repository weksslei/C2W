namespace C2W
{
    partial class PesquisarOfertas
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
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ListaOfertas = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataInicial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataFinal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.volume_estocado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor_venda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor_oferta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TipoPesquisa = new System.Windows.Forms.ComboBox();
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1278, 49);
            this.button1.TabIndex = 100;
            this.button1.Text = "LISTA DE OFERTAS CADASTRADAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(-2, 25);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(306, 23);
            this.lblPesquisar.TabIndex = 98;
            this.lblPesquisar.Text = "Localizar Informações por: ";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1135, 5);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(143, 54);
            this.btnPesquisar.TabIndex = 96;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(2, 697);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(184, 56);
            this.btnNovo.TabIndex = 101;
            this.btnNovo.Text = "Inserir Nova Oferta";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1152, 697);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 56);
            this.btnFechar.TabIndex = 103;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(977, 697);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(144, 56);
            this.btnOK.TabIndex = 102;
            this.btnOK.Text = "Visualizar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ListaOfertas
            // 
            this.ListaOfertas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Descricao,
            this.dataInicial,
            this.dataFinal,
            this.volume_estocado,
            this.Valor_venda,
            this.Valor_oferta,
            this.columnHeader1});
            this.ListaOfertas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaOfertas.FullRowSelect = true;
            this.ListaOfertas.GridLines = true;
            this.ListaOfertas.Location = new System.Drawing.Point(2, 112);
            this.ListaOfertas.MultiSelect = false;
            this.ListaOfertas.Name = "ListaOfertas";
            this.ListaOfertas.Size = new System.Drawing.Size(1276, 577);
            this.ListaOfertas.TabIndex = 104;
            this.ListaOfertas.UseCompatibleStateImageBehavior = false;
            this.ListaOfertas.View = System.Windows.Forms.View.Details;
            this.ListaOfertas.SelectedIndexChanged += new System.EventHandler(this.ListaOfertas_SelectedIndexChanged);
            this.ListaOfertas.DoubleClick += new System.EventHandler(this.ListaOfertas_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Oferta";
            this.id.Width = 66;
            // 
            // Descricao
            // 
            this.Descricao.Text = "Produto Ofertado";
            this.Descricao.Width = 368;
            // 
            // dataInicial
            // 
            this.dataInicial.Text = "Início da Oferta";
            this.dataInicial.Width = 142;
            // 
            // dataFinal
            // 
            this.dataFinal.Text = "Término da Oferta";
            this.dataFinal.Width = 150;
            // 
            // volume_estocado
            // 
            this.volume_estocado.Text = "Estoque Atual";
            this.volume_estocado.Width = 120;
            // 
            // Valor_venda
            // 
            this.Valor_venda.Text = "Preço Atual";
            this.Valor_venda.Width = 127;
            // 
            // Valor_oferta
            // 
            this.Valor_oferta.Text = "Preço Ofertado";
            this.Valor_oferta.Width = 135;
            // 
            // TipoPesquisa
            // 
            this.TipoPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoPesquisa.FormattingEnabled = true;
            this.TipoPesquisa.Items.AddRange(new object[] {
            "Ofertas de um período",
            "Ofertas Válidas",
            "Ofertas Encerradas"});
            this.TipoPesquisa.Location = new System.Drawing.Point(310, 19);
            this.TipoPesquisa.Name = "TipoPesquisa";
            this.TipoPesquisa.Size = new System.Drawing.Size(279, 28);
            this.TipoPesquisa.TabIndex = 105;
            this.TipoPesquisa.SelectedIndexChanged += new System.EventHandler(this.TipoPesquisa_SelectedIndexChanged);
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataFinal.Location = new System.Drawing.Point(997, 25);
            this.mtbDataFinal.Mask = "00/00/0000";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 26);
            this.mtbDataFinal.TabIndex = 109;
            this.mtbDataFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataFinal_KeyDown);
            this.mtbDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataFinal_KeyPress);
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataInicial.Location = new System.Drawing.Point(739, 25);
            this.mtbDataInicial.Mask = "00/00/0000";
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.Size = new System.Drawing.Size(100, 26);
            this.mtbDataInicial.TabIndex = 108;
            this.mtbDataInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDataInicial_KeyDown);
            this.mtbDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDataInicial_KeyPress);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.Location = new System.Drawing.Point(865, 28);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(126, 23);
            this.lblDataFinal.TabIndex = 107;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicial.Location = new System.Drawing.Point(595, 25);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(138, 23);
            this.lblDataInicial.TabIndex = 106;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Status da Oferta";
            this.columnHeader1.Width = 165;
            // 
            // btnImprimir
            // 
            this.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(515, 697);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(184, 56);
            this.btnImprimir.TabIndex = 110;
            this.btnImprimir.Text = "Imprimir Folheto";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // PesquisarOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 765);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.TipoPesquisa);
            this.Controls.Add(this.ListaOfertas);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.btnPesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarOfertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DE OFERTAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarOfertas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarOfertas_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView ListaOfertas;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader Descricao;
        private System.Windows.Forms.ColumnHeader dataInicial;
        private System.Windows.Forms.ColumnHeader dataFinal;
        private System.Windows.Forms.ColumnHeader volume_estocado;
        private System.Windows.Forms.ColumnHeader Valor_venda;
        private System.Windows.Forms.ColumnHeader Valor_oferta;
        private System.Windows.Forms.ComboBox TipoPesquisa;
        private System.Windows.Forms.MaskedTextBox mtbDataFinal;
        private System.Windows.Forms.MaskedTextBox mtbDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnImprimir;
    }
}