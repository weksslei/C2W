namespace C2W
{
    partial class Relatorio_Aniversariantes
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
            this.Meses = new System.Windows.Forms.ComboBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listaClientes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt_nasc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.e_mail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.Meses.Location = new System.Drawing.Point(533, 34);
            this.Meses.Name = "Meses";
            this.Meses.Size = new System.Drawing.Size(167, 28);
            this.Meses.TabIndex = 123;
            this.Meses.SelectedIndexChanged += new System.EventHandler(this.Meses_SelectedIndexChanged);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(82, 39);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(431, 23);
            this.lblPesquisar.TabIndex = 126;
            this.lblPesquisar.Text = "Selecionar mês dos aniversariantes => ";
            // 
            // btnEmitir
            // 
            this.btnEmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmitir.Location = new System.Drawing.Point(1066, 6);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(198, 57);
            this.btnEmitir.TabIndex = 127;
            this.btnEmitir.Text = "Emitir Relatório";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1252, 49);
            this.button1.TabIndex = 129;
            this.button1.Text = "CLIENTES ANIVERSARIANTES ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listaClientes
            // 
            this.listaClientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nome,
            this.dt_nasc,
            this.cpf,
            this.e_mail,
            this.fone1,
            this.fone2});
            this.listaClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaClientes.FullRowSelect = true;
            this.listaClientes.GridLines = true;
            this.listaClientes.Location = new System.Drawing.Point(12, 137);
            this.listaClientes.MultiSelect = false;
            this.listaClientes.Name = "listaClientes";
            this.listaClientes.Size = new System.Drawing.Size(1252, 544);
            this.listaClientes.TabIndex = 128;
            this.listaClientes.UseCompatibleStateImageBehavior = false;
            this.listaClientes.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 77;
            // 
            // nome
            // 
            this.nome.Text = "Nome Do Cliente";
            this.nome.Width = 401;
            // 
            // dt_nasc
            // 
            this.dt_nasc.Text = "Nascimento";
            this.dt_nasc.Width = 99;
            // 
            // cpf
            // 
            this.cpf.Text = "CPF";
            this.cpf.Width = 128;
            // 
            // e_mail
            // 
            this.e_mail.Text = "E-Mail";
            this.e_mail.Width = 286;
            // 
            // fone1
            // 
            this.fone1.Text = "Telefone 1";
            this.fone1.Width = 116;
            // 
            // fone2
            // 
            this.fone2.Text = "Telefone 2";
            this.fone2.Width = 115;
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1121, 687);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(143, 62);
            this.btnFechar.TabIndex = 130;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // Relatorio_Aniversariantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listaClientes);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.Meses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio_Aniversariantes";
            this.Text = "Relatorio de Aniversariantes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Relatorio_Aniversariantes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_Aniversariantes_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox Meses;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listaClientes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader dt_nasc;
        private System.Windows.Forms.ColumnHeader cpf;
        private System.Windows.Forms.ColumnHeader e_mail;
        private System.Windows.Forms.ColumnHeader fone1;
        private System.Windows.Forms.ColumnHeader fone2;
        private System.Windows.Forms.Button btnFechar;
    }
}