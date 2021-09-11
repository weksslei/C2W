namespace C2W
{
    partial class ConstruirPedidoCompra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNao = new System.Windows.Forms.RadioButton();
            this.rbSim = new System.Windows.Forms.RadioButton();
            this.ListaCotacoes = new System.Windows.Forms.ListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.ListaFornecedores = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.empresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nome_vendedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fone1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovaCompra = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNao);
            this.groupBox1.Controls.Add(this.rbSim);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerar Pedido de Compras através de uma Cotação ?";
            // 
            // rbNao
            // 
            this.rbNao.AutoSize = true;
            this.rbNao.Location = new System.Drawing.Point(240, 44);
            this.rbNao.Name = "rbNao";
            this.rbNao.Size = new System.Drawing.Size(59, 24);
            this.rbNao.TabIndex = 1;
            this.rbNao.Text = "Não";
            this.rbNao.UseVisualStyleBackColor = true;
            this.rbNao.Click += new System.EventHandler(this.rbNao_Click);
            // 
            // rbSim
            // 
            this.rbSim.AutoSize = true;
            this.rbSim.Checked = true;
            this.rbSim.Location = new System.Drawing.Point(117, 44);
            this.rbSim.Name = "rbSim";
            this.rbSim.Size = new System.Drawing.Size(57, 24);
            this.rbSim.TabIndex = 0;
            this.rbSim.TabStop = true;
            this.rbSim.Text = "Sim";
            this.rbSim.UseVisualStyleBackColor = true;
            this.rbSim.Click += new System.EventHandler(this.rbSim_Click);
            // 
            // ListaCotacoes
            // 
            this.ListaCotacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.nome_empresa,
            this.data,
            this.total});
            this.ListaCotacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaCotacoes.FullRowSelect = true;
            this.ListaCotacoes.GridLines = true;
            this.ListaCotacoes.Location = new System.Drawing.Point(12, 168);
            this.ListaCotacoes.MultiSelect = false;
            this.ListaCotacoes.Name = "ListaCotacoes";
            this.ListaCotacoes.Size = new System.Drawing.Size(516, 519);
            this.ListaCotacoes.TabIndex = 84;
            this.ListaCotacoes.UseCompatibleStateImageBehavior = false;
            this.ListaCotacoes.View = System.Windows.Forms.View.Details;
            this.ListaCotacoes.SelectedIndexChanged += new System.EventHandler(this.ListaCotacoes_SelectedIndexChanged);
            // 
            // Codigo
            // 
            this.Codigo.Text = "Código";
            this.Codigo.Width = 8;
            // 
            // nome_empresa
            // 
            this.nome_empresa.Text = "Fornecedor";
            this.nome_empresa.Width = 266;
            // 
            // data
            // 
            this.data.Text = "Data";
            this.data.Width = 106;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.Width = 100;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(516, 49);
            this.button1.TabIndex = 85;
            this.button1.Text = "COTAÇÕES REALIZADAS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListaFornecedores
            // 
            this.ListaFornecedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.empresa,
            this.nome_vendedor,
            this.fone1});
            this.ListaFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaFornecedores.FullRowSelect = true;
            this.ListaFornecedores.GridLines = true;
            this.ListaFornecedores.Location = new System.Drawing.Point(534, 168);
            this.ListaFornecedores.MultiSelect = false;
            this.ListaFornecedores.Name = "ListaFornecedores";
            this.ListaFornecedores.Size = new System.Drawing.Size(733, 519);
            this.ListaFornecedores.TabIndex = 86;
            this.ListaFornecedores.UseCompatibleStateImageBehavior = false;
            this.ListaFornecedores.View = System.Windows.Forms.View.Details;
            this.ListaFornecedores.SelectedIndexChanged += new System.EventHandler(this.ListaFornecedores_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Código";
            this.Id.Width = 7;
            // 
            // empresa
            // 
            this.empresa.Text = "Empresa";
            this.empresa.Width = 284;
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
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(534, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(733, 49);
            this.button2.TabIndex = 87;
            this.button2.Text = "FORNECEDORES DISPONÍVEIS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Lucida Sans", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(699, 26);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(275, 23);
            this.lblPesquisar.TabIndex = 90;
            this.lblPesquisar.Text = "Selecionar fornecedores:";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(703, 62);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(374, 26);
            this.txtPesquisar.TabIndex = 89;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1132, 57);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(135, 37);
            this.btnPesquisar.TabIndex = 88;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaCompra.Location = new System.Drawing.Point(12, 703);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(211, 58);
            this.btnNovaCompra.TabIndex = 91;
            this.btnNovaCompra.Text = "Continuar Compra";
            this.btnNovaCompra.UseVisualStyleBackColor = true;
            this.btnNovaCompra.Click += new System.EventHandler(this.btnNovaCompra_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(1171, 709);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 49);
            this.btnFechar.TabIndex = 102;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // ConstruirPedidoCompra
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnNovaCompra);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ListaFornecedores);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaCotacoes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConstruirPedidoCompra";
            this.Text = "MOVIMENTAÇÃO DOS PEDIDOS DE COMPRAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConstruirPedidoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConstruirPedidoCompra_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNao;
        private System.Windows.Forms.RadioButton rbSim;
        private System.Windows.Forms.ListView ListaCotacoes;
        private System.Windows.Forms.ColumnHeader nome_empresa;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListaFornecedores;
        private System.Windows.Forms.ColumnHeader empresa;
        private System.Windows.Forms.ColumnHeader nome_vendedor;
        private System.Windows.Forms.ColumnHeader fone1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblPesquisar;
        public System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovaCompra;
        private System.Windows.Forms.ColumnHeader Codigo;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.Button btnFechar;
    }
}