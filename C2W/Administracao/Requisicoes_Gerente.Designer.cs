namespace C2W
{
    partial class Requisicoes_Gerente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Requisicoes_Gerente));
            this.gbRequisicao = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblEstoqueAtual = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtDataRequisicao = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.lblCodRequisicao = new System.Windows.Forms.Label();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnPortifolio = new System.Windows.Forms.Button();
            this.btnCotacao = new System.Windows.Forms.Button();
            this.btnPedidoCompras = new System.Windows.Forms.Button();
            this.cbFornecedor = new System.Windows.Forms.CheckBox();
            this.cbProduto = new System.Windows.Forms.CheckBox();
            this.cbPortifolio = new System.Windows.Forms.CheckBox();
            this.cbCotacoes = new System.Windows.Forms.CheckBox();
            this.cbPedidoCompras = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbLegenda = new System.Windows.Forms.CheckBox();
            this.gbStatusRequisicao = new System.Windows.Forms.GroupBox();
            this.rbNao = new System.Windows.Forms.RadioButton();
            this.rbSim = new System.Windows.Forms.RadioButton();
            this.gbRequisicao.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbStatusRequisicao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRequisicao
            // 
            this.gbRequisicao.Controls.Add(this.lblEstoqueAtual);
            this.gbRequisicao.Controls.Add(this.lblProduto);
            this.gbRequisicao.Controls.Add(this.txtQuantidade);
            this.gbRequisicao.Controls.Add(this.txtDataRequisicao);
            this.gbRequisicao.Controls.Add(this.label16);
            this.gbRequisicao.Controls.Add(this.label12);
            this.gbRequisicao.Controls.Add(this.label5);
            this.gbRequisicao.Controls.Add(this.label6);
            this.gbRequisicao.Controls.Add(this.lblDescricaoProduto);
            this.gbRequisicao.Controls.Add(this.lblCodRequisicao);
            this.gbRequisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRequisicao.Location = new System.Drawing.Point(12, 21);
            this.gbRequisicao.Name = "gbRequisicao";
            this.gbRequisicao.Size = new System.Drawing.Size(540, 273);
            this.gbRequisicao.TabIndex = 103;
            this.gbRequisicao.TabStop = false;
            this.gbRequisicao.Text = "Informações da Requisição: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(590, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 261);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OBSERVAÇÃO SOBRE A REQUISIÇÃO: ";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(19, 54);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(525, 156);
            this.txtDescricao.TabIndex = 0;
            // 
            // lblEstoqueAtual
            // 
            this.lblEstoqueAtual.AutoSize = true;
            this.lblEstoqueAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueAtual.Location = new System.Drawing.Point(209, 120);
            this.lblEstoqueAtual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstoqueAtual.Name = "lblEstoqueAtual";
            this.lblEstoqueAtual.Size = new System.Drawing.Size(12, 16);
            this.lblEstoqueAtual.TabIndex = 107;
            this.lblEstoqueAtual.Text = ".";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(209, 93);
            this.lblProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(12, 16);
            this.lblProduto.TabIndex = 105;
            this.lblProduto.Text = ".";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(210, 185);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(100, 22);
            this.txtQuantidade.TabIndex = 103;
            // 
            // txtDataRequisicao
            // 
            this.txtDataRequisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataRequisicao.Location = new System.Drawing.Point(210, 151);
            this.txtDataRequisicao.Mask = "00/00/0000";
            this.txtDataRequisicao.Name = "txtDataRequisicao";
            this.txtDataRequisicao.Size = new System.Drawing.Size(100, 22);
            this.txtDataRequisicao.TabIndex = 100;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 154);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(174, 16);
            this.label16.TabIndex = 99;
            this.label16.Text = "Data da Requisição......:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 189);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 16);
            this.label12.TabIndex = 90;
            this.label12.Text = "Quantidade Requerida..:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 16);
            this.label5.TabIndex = 87;
            this.label5.Text = "Estoque Atual.................:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 80;
            this.label6.Text = "Código da Requisição..: ";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoProduto.Location = new System.Drawing.Point(24, 93);
            this.lblDescricaoProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(175, 16);
            this.lblDescricaoProduto.TabIndex = 78;
            this.lblDescricaoProduto.Text = "Produto Requerido........:";
            // 
            // lblCodRequisicao
            // 
            this.lblCodRequisicao.AutoSize = true;
            this.lblCodRequisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodRequisicao.Location = new System.Drawing.Point(208, 62);
            this.lblCodRequisicao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodRequisicao.Name = "lblCodRequisicao";
            this.lblCodRequisicao.Size = new System.Drawing.Size(21, 16);
            this.lblCodRequisicao.TabIndex = 77;
            this.lblCodRequisicao.Text = "-1";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFornecedor.BackgroundImage")));
            this.btnFornecedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFornecedor.Location = new System.Drawing.Point(69, 388);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(120, 89);
            this.btnFornecedor.TabIndex = 104;
            this.toolTip1.SetToolTip(this.btnFornecedor, "Inserir novo fornecedor para produto requisitado");
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProduto.BackgroundImage")));
            this.btnProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduto.Location = new System.Drawing.Point(256, 388);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(121, 89);
            this.btnProduto.TabIndex = 105;
            this.toolTip1.SetToolTip(this.btnProduto, "Cadastrar novo produto requisitado caso queira comercializá-lo.");
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnPortifolio
            // 
            this.btnPortifolio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPortifolio.BackgroundImage")));
            this.btnPortifolio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPortifolio.Location = new System.Drawing.Point(454, 388);
            this.btnPortifolio.Name = "btnPortifolio";
            this.btnPortifolio.Size = new System.Drawing.Size(126, 89);
            this.btnPortifolio.TabIndex = 106;
            this.toolTip1.SetToolTip(this.btnPortifolio, "Ligar o novo fornecedor ao novo produto, criando ou incrementando o portifólio .");
            this.btnPortifolio.UseVisualStyleBackColor = true;
            this.btnPortifolio.Click += new System.EventHandler(this.btnPortifolio_Click);
            // 
            // btnCotacao
            // 
            this.btnCotacao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCotacao.BackgroundImage")));
            this.btnCotacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCotacao.Location = new System.Drawing.Point(667, 388);
            this.btnCotacao.Name = "btnCotacao";
            this.btnCotacao.Size = new System.Drawing.Size(125, 89);
            this.btnCotacao.TabIndex = 107;
            this.toolTip1.SetToolTip(this.btnCotacao, "Realizar cotações para atender esta requisição.");
            this.btnCotacao.UseVisualStyleBackColor = true;
            this.btnCotacao.Click += new System.EventHandler(this.btnCotacao_Click);
            // 
            // btnPedidoCompras
            // 
            this.btnPedidoCompras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPedidoCompras.BackgroundImage")));
            this.btnPedidoCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPedidoCompras.Location = new System.Drawing.Point(871, 388);
            this.btnPedidoCompras.Name = "btnPedidoCompras";
            this.btnPedidoCompras.Size = new System.Drawing.Size(122, 89);
            this.btnPedidoCompras.TabIndex = 108;
            this.toolTip1.SetToolTip(this.btnPedidoCompras, "Realizar compra de produtos para atender esta requisição.");
            this.btnPedidoCompras.UseVisualStyleBackColor = true;
            this.btnPedidoCompras.Click += new System.EventHandler(this.btnPedidoCompras_Click);
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.AutoSize = true;
            this.cbFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFornecedor.ForeColor = System.Drawing.Color.Green;
            this.cbFornecedor.Location = new System.Drawing.Point(111, 497);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(15, 14);
            this.cbFornecedor.TabIndex = 114;
            this.cbFornecedor.UseVisualStyleBackColor = true;
            // 
            // cbProduto
            // 
            this.cbProduto.AutoSize = true;
            this.cbProduto.Location = new System.Drawing.Point(316, 497);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(15, 14);
            this.cbProduto.TabIndex = 115;
            this.cbProduto.UseVisualStyleBackColor = true;
            // 
            // cbPortifolio
            // 
            this.cbPortifolio.AutoSize = true;
            this.cbPortifolio.Location = new System.Drawing.Point(515, 497);
            this.cbPortifolio.Name = "cbPortifolio";
            this.cbPortifolio.Size = new System.Drawing.Size(15, 14);
            this.cbPortifolio.TabIndex = 116;
            this.cbPortifolio.UseVisualStyleBackColor = true;
            // 
            // cbCotacoes
            // 
            this.cbCotacoes.AutoSize = true;
            this.cbCotacoes.Location = new System.Drawing.Point(727, 497);
            this.cbCotacoes.Name = "cbCotacoes";
            this.cbCotacoes.Size = new System.Drawing.Size(15, 14);
            this.cbCotacoes.TabIndex = 117;
            this.cbCotacoes.UseVisualStyleBackColor = true;
            // 
            // cbPedidoCompras
            // 
            this.cbPedidoCompras.AutoSize = true;
            this.cbPedidoCompras.Location = new System.Drawing.Point(931, 497);
            this.cbPedidoCompras.Name = "cbPedidoCompras";
            this.cbPedidoCompras.Size = new System.Drawing.Size(15, 14);
            this.cbPedidoCompras.TabIndex = 118;
            this.cbPedidoCompras.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // cbLegenda
            // 
            this.cbLegenda.AutoSize = true;
            this.cbLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLegenda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbLegenda.Location = new System.Drawing.Point(111, 707);
            this.cbLegenda.Name = "cbLegenda";
            this.cbLegenda.Size = new System.Drawing.Size(734, 20);
            this.cbLegenda.TabIndex = 119;
            this.cbLegenda.Text = "Caixas em branco demonstram as rotinas que precisam ser executadas para atender e" +
    "sta Requisição.";
            this.cbLegenda.UseVisualStyleBackColor = true;
            // 
            // gbStatusRequisicao
            // 
            this.gbStatusRequisicao.Controls.Add(this.rbSim);
            this.gbStatusRequisicao.Controls.Add(this.rbNao);
            this.gbStatusRequisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatusRequisicao.Location = new System.Drawing.Point(703, 564);
            this.gbStatusRequisicao.Name = "gbStatusRequisicao";
            this.gbStatusRequisicao.Size = new System.Drawing.Size(403, 106);
            this.gbStatusRequisicao.TabIndex = 109;
            this.gbStatusRequisicao.TabStop = false;
            this.gbStatusRequisicao.Text = "REQUISIÇÃO ATENDIDA ? ";
            // 
            // rbNao
            // 
            this.rbNao.AutoSize = true;
            this.rbNao.Checked = true;
            this.rbNao.Location = new System.Drawing.Point(65, 53);
            this.rbNao.Name = "rbNao";
            this.rbNao.Size = new System.Drawing.Size(58, 20);
            this.rbNao.TabIndex = 0;
            this.rbNao.TabStop = true;
            this.rbNao.Text = "NÃO";
            this.rbNao.UseVisualStyleBackColor = true;
            // 
            // rbSim
            // 
            this.rbSim.AutoSize = true;
            this.rbSim.Location = new System.Drawing.Point(235, 53);
            this.rbSim.Name = "rbSim";
            this.rbSim.Size = new System.Drawing.Size(52, 20);
            this.rbSim.TabIndex = 1;
            this.rbSim.Text = "SIM";
            this.rbSim.UseVisualStyleBackColor = true;
            this.rbSim.CheckedChanged += new System.EventHandler(this.rbSim_CheckedChanged);
            // 
            // Requisicoes_Gerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbStatusRequisicao);
            this.Controls.Add(this.cbLegenda);
            this.Controls.Add(this.cbPedidoCompras);
            this.Controls.Add(this.cbCotacoes);
            this.Controls.Add(this.cbPortifolio);
            this.Controls.Add(this.cbProduto);
            this.Controls.Add(this.cbFornecedor);
            this.Controls.Add(this.btnPedidoCompras);
            this.Controls.Add(this.btnCotacao);
            this.Controls.Add(this.btnPortifolio);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.gbRequisicao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Requisicoes_Gerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMENTAÇÃO DE REQUISIÇÕES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Requisicoes_Gerente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Requisicoes_Gerente_KeyDown);
            this.gbRequisicao.ResumeLayout(false);
            this.gbRequisicao.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbStatusRequisicao.ResumeLayout(false);
            this.gbStatusRequisicao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRequisicao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblEstoqueAtual;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.MaskedTextBox txtDataRequisicao;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Label lblCodRequisicao;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnPortifolio;
        private System.Windows.Forms.Button btnCotacao;
        private System.Windows.Forms.Button btnPedidoCompras;
        private System.Windows.Forms.CheckBox cbFornecedor;
        private System.Windows.Forms.CheckBox cbProduto;
        private System.Windows.Forms.CheckBox cbPortifolio;
        private System.Windows.Forms.CheckBox cbCotacoes;
        private System.Windows.Forms.CheckBox cbPedidoCompras;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbLegenda;
        private System.Windows.Forms.GroupBox gbStatusRequisicao;
        private System.Windows.Forms.RadioButton rbSim;
        private System.Windows.Forms.RadioButton rbNao;
    }
}