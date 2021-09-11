namespace C2W
{
    partial class Relatorio_Contas_A_Pagar
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
            this.ListaDespesas = new System.Windows.Forms.ListView();
            this.NumeroNF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Serie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt_emissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt_vencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.situacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.Meses = new System.Windows.Forms.ComboBox();
            this.Anos = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1260, 49);
            this.button1.TabIndex = 98;
            this.button1.Text = "DEMONSTRATIVO DE CONTAS A PAGAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListaDespesas
            // 
            this.ListaDespesas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumeroNF,
            this.Serie,
            this.IdFornecedor,
            this.Parcela,
            this.valor,
            this.dt_emissao,
            this.dt_vencimento,
            this.situacao,
            this.columnHeader1});
            this.ListaDespesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaDespesas.FullRowSelect = true;
            this.ListaDespesas.GridLines = true;
            this.ListaDespesas.Location = new System.Drawing.Point(8, 127);
            this.ListaDespesas.MultiSelect = false;
            this.ListaDespesas.Name = "ListaDespesas";
            this.ListaDespesas.Size = new System.Drawing.Size(1260, 568);
            this.ListaDespesas.TabIndex = 97;
            this.ListaDespesas.UseCompatibleStateImageBehavior = false;
            this.ListaDespesas.View = System.Windows.Forms.View.Details;
            // 
            // NumeroNF
            // 
            this.NumeroNF.Text = "Nota Fiscal";
            this.NumeroNF.Width = 225;
            // 
            // Serie
            // 
            this.Serie.Text = "Série";
            this.Serie.Width = 82;
            // 
            // IdFornecedor
            // 
            this.IdFornecedor.Text = "Beneficiário";
            this.IdFornecedor.Width = 346;
            // 
            // Parcela
            // 
            this.Parcela.Text = "Parcela";
            this.Parcela.Width = 75;
            // 
            // valor
            // 
            this.valor.Text = "Valor";
            this.valor.Width = 122;
            // 
            // dt_emissao
            // 
            this.dt_emissao.Text = "Emissão";
            this.dt_emissao.Width = 113;
            // 
            // dt_vencimento
            // 
            this.dt_vencimento.Text = "Vencimento";
            this.dt_vencimento.Width = 113;
            // 
            // situacao
            // 
            this.situacao.Text = "Status";
            this.situacao.Width = 183;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código Fornecedor";
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1127, 701);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 52);
            this.btnFechar.TabIndex = 99;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnEmitir
            // 
            this.btnEmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmitir.Location = new System.Drawing.Point(1070, 12);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(198, 57);
            this.btnEmitir.TabIndex = 130;
            this.btnEmitir.Text = "Emitir Relatório";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(26, 27);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(424, 23);
            this.lblPesquisar.TabIndex = 129;
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
            this.Meses.Location = new System.Drawing.Point(476, 22);
            this.Meses.Name = "Meses";
            this.Meses.Size = new System.Drawing.Size(167, 28);
            this.Meses.TabIndex = 128;
            this.Meses.SelectedIndexChanged += new System.EventHandler(this.Meses_SelectedIndexChanged);
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
            this.Anos.Location = new System.Drawing.Point(683, 22);
            this.Anos.Name = "Anos";
            this.Anos.Size = new System.Drawing.Size(121, 28);
            this.Anos.TabIndex = 131;
            this.Anos.SelectedIndexChanged += new System.EventHandler(this.Anos_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Peru;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(8, 701);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(334, 52);
            this.button2.TabIndex = 132;
            this.button2.Text = "Contas com atraso de pagamento.";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Relatorio_Contas_A_Pagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Anos);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.Meses);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaDespesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio_Contas_A_Pagar";
            this.Text = "Relatorio Contas a Pagar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorio_Contas_A_Pagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_Contas_A_Pagar_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaDespesas;
        private System.Windows.Forms.ColumnHeader NumeroNF;
        private System.Windows.Forms.ColumnHeader Serie;
        private System.Windows.Forms.ColumnHeader IdFornecedor;
        private System.Windows.Forms.ColumnHeader Parcela;
        private System.Windows.Forms.ColumnHeader valor;
        private System.Windows.Forms.ColumnHeader dt_emissao;
        private System.Windows.Forms.ColumnHeader dt_vencimento;
        private System.Windows.Forms.ColumnHeader situacao;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.ComboBox Meses;
        private System.Windows.Forms.ComboBox Anos;
        private System.Windows.Forms.Button button2;
    }
}