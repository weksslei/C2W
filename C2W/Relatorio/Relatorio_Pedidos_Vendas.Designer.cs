namespace C2W
{
    partial class Relatorio_Pedidos_Vendas
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
            this.Anos = new System.Windows.Forms.ComboBox();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.Meses = new System.Windows.Forms.ComboBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ListaVendas = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.concluido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entregar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.Anos.Location = new System.Drawing.Point(685, 22);
            this.Anos.Name = "Anos";
            this.Anos.Size = new System.Drawing.Size(121, 28);
            this.Anos.TabIndex = 139;
            this.Anos.SelectedIndexChanged += new System.EventHandler(this.Anos_SelectedIndexChanged);
            // 
            // btnEmitir
            // 
            this.btnEmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmitir.Location = new System.Drawing.Point(1075, 9);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(198, 57);
            this.btnEmitir.TabIndex = 138;
            this.btnEmitir.Text = "Emitir Relatório";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(28, 27);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(424, 23);
            this.lblPesquisar.TabIndex = 137;
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
            this.Meses.Location = new System.Drawing.Point(478, 22);
            this.Meses.Name = "Meses";
            this.Meses.Size = new System.Drawing.Size(167, 28);
            this.Meses.TabIndex = 136;
            this.Meses.SelectedIndexChanged += new System.EventHandler(this.Meses_SelectedIndexChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1162, 694);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(111, 49);
            this.btnFechar.TabIndex = 142;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1269, 49);
            this.button1.TabIndex = 141;
            this.button1.Text = "PEDIDOS DE CLIENTES EM UM PERÍODO";
            this.button1.UseVisualStyleBackColor = true;
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
            this.ListaVendas.Location = new System.Drawing.Point(4, 122);
            this.ListaVendas.MultiSelect = false;
            this.ListaVendas.Name = "ListaVendas";
            this.ListaVendas.Size = new System.Drawing.Size(1269, 554);
            this.ListaVendas.TabIndex = 140;
            this.ListaVendas.UseCompatibleStateImageBehavior = false;
            this.ListaVendas.View = System.Windows.Forms.View.Details;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Peru;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(4, 694);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(333, 49);
            this.button2.TabIndex = 143;
            this.button2.Text = "Pedidos não concluídos";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Relatorio_Pedidos_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaVendas);
            this.Controls.Add(this.Anos);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.Meses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio_Pedidos_Vendas";
            this.Text = "Relatorio dos Pedidos de Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorio_Pedidos_Vendas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_Pedidos_Vendas_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Anos;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.ComboBox Meses;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaVendas;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader observacao;
        private System.Windows.Forms.ColumnHeader concluido;
        private System.Windows.Forms.ColumnHeader entregar;
        private System.Windows.Forms.Button button2;
    }
}