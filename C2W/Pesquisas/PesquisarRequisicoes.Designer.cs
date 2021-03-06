namespace C2W
{
    partial class PesquisarRequisicoes
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
            this.ListaRequisicoes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idproduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.atendida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListaRequisicoes
            // 
            this.ListaRequisicoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.idproduto,
            this.data,
            this.quantidade,
            this.descricao,
            this.atendida});
            this.ListaRequisicoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaRequisicoes.FullRowSelect = true;
            this.ListaRequisicoes.GridLines = true;
            this.ListaRequisicoes.Location = new System.Drawing.Point(5, 53);
            this.ListaRequisicoes.MultiSelect = false;
            this.ListaRequisicoes.Name = "ListaRequisicoes";
            this.ListaRequisicoes.Size = new System.Drawing.Size(1259, 662);
            this.ListaRequisicoes.TabIndex = 94;
            this.ListaRequisicoes.UseCompatibleStateImageBehavior = false;
            this.ListaRequisicoes.View = System.Windows.Forms.View.Details;
            this.ListaRequisicoes.SelectedIndexChanged += new System.EventHandler(this.ListaCompras_SelectedIndexChanged);
            this.ListaRequisicoes.DoubleClick += new System.EventHandler(this.ListaRequisicoes_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 65;
            // 
            // idproduto
            // 
            this.idproduto.Text = "Produto Requisitado";
            this.idproduto.Width = 275;
            // 
            // data
            // 
            this.data.Text = "Data da Requisição";
            this.data.Width = 150;
            // 
            // quantidade
            // 
            this.quantidade.Text = "Quantidade";
            this.quantidade.Width = 99;
            // 
            // descricao
            // 
            this.descricao.Text = "Observação sobre a Requisição";
            this.descricao.Width = 496;
            // 
            // atendida
            // 
            this.atendida.Text = "Requisição Atendida?";
            this.atendida.Width = 166;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1259, 49);
            this.button1.TabIndex = 95;
            this.button1.Text = "REQUISIÇÕES REALIZADAS A SEREM ATENDIDAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(4, 717);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(236, 49);
            this.btnNovo.TabIndex = 103;
            this.btnNovo.Text = "Inserir Nova Requisição";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1168, 717);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 49);
            this.btnFechar.TabIndex = 105;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(1052, 717);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 49);
            this.btnOK.TabIndex = 104;
            this.btnOK.Text = "Visualizar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PesquisarRequisicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaRequisicoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisarRequisicoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DE REQUISIÇÕES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PesquisarRequisicoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarRequisicoes_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListaRequisicoes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader idproduto;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader quantidade;
        private System.Windows.Forms.ColumnHeader atendida;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ColumnHeader descricao;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnOK;
    }
}