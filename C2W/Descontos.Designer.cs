namespace C2W
{
    partial class Descontos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Descontos));
            this.gbAcesso = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFigura = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtFone2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFone1 = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ListaVendas = new System.Windows.Forms.ListView();
            this.idProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valor_vend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.gbDesconto = new System.Windows.Forms.GroupBox();
            this.rbPercentual = new System.Windows.Forms.RadioButton();
            this.rbValor = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTotal_Com_Desconto = new System.Windows.Forms.Button();
            this.gbAcesso.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.gbDesconto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcesso
            // 
            this.gbAcesso.Controls.Add(this.label7);
            this.gbAcesso.Controls.Add(this.label6);
            this.gbAcesso.Controls.Add(this.btnFigura);
            this.gbAcesso.Controls.Add(this.txtSenha);
            this.gbAcesso.Controls.Add(this.txtUsuario);
            this.gbAcesso.Controls.Add(this.label2);
            this.gbAcesso.Controls.Add(this.label1);
            this.gbAcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAcesso.Location = new System.Drawing.Point(17, 39);
            this.gbAcesso.Name = "gbAcesso";
            this.gbAcesso.Size = new System.Drawing.Size(564, 117);
            this.gbAcesso.TabIndex = 2;
            this.gbAcesso.TabStop = false;
            this.gbAcesso.Text = "Autorizar desconto: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(86, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 152;
            this.label7.Text = "<<  Enter >>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(274, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 151;
            this.label6.Text = "<<  Enter >>";
            // 
            // btnFigura
            // 
            this.btnFigura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFigura.BackgroundImage")));
            this.btnFigura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFigura.Enabled = false;
            this.btnFigura.Location = new System.Drawing.Point(416, 15);
            this.btnFigura.Name = "btnFigura";
            this.btnFigura.Size = new System.Drawing.Size(112, 79);
            this.btnFigura.TabIndex = 13;
            this.btnFigura.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(251, 67);
            this.txtSenha.MaxLength = 8;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(111, 22);
            this.txtSenha.TabIndex = 12;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(63, 67);
            this.txtUsuario.MaxLength = 8;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(111, 22);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuário:";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.label10);
            this.gbCliente.Controls.Add(this.txtEmail);
            this.gbCliente.Controls.Add(this.txtNome);
            this.gbCliente.Controls.Add(this.txtFone2);
            this.gbCliente.Controls.Add(this.label5);
            this.gbCliente.Controls.Add(this.label15);
            this.gbCliente.Controls.Add(this.label14);
            this.gbCliente.Controls.Add(this.txtFone1);
            this.gbCliente.Controls.Add(this.txtCPF);
            this.gbCliente.Controls.Add(this.label9);
            this.gbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCliente.Location = new System.Drawing.Point(590, 28);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(674, 168);
            this.gbCliente.TabIndex = 137;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "CLIENTE : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 64;
            this.label10.Text = "E_Mail :";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(81, 52);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(584, 22);
            this.txtEmail.TabIndex = 63;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(81, 24);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(584, 22);
            this.txtNome.TabIndex = 53;
            // 
            // txtFone2
            // 
            this.txtFone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone2.Location = new System.Drawing.Point(118, 118);
            this.txtFone2.Mask = "(00) 00000-0000";
            this.txtFone2.Name = "txtFone2";
            this.txtFone2.Size = new System.Drawing.Size(128, 22);
            this.txtFone2.TabIndex = 62;
            this.txtFone2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "Nome :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 122);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 16);
            this.label15.TabIndex = 60;
            this.label15.Text = "Telefone 2 .:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(293, 93);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 16);
            this.label14.TabIndex = 57;
            this.label14.Text = "CPF :";
            // 
            // txtFone1
            // 
            this.txtFone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone1.Location = new System.Drawing.Point(118, 86);
            this.txtFone1.Mask = "(00) 00000-0000";
            this.txtFone1.Name = "txtFone1";
            this.txtFone1.Size = new System.Drawing.Size(128, 22);
            this.txtFone1.TabIndex = 61;
            this.txtFone1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(343, 89);
            this.txtCPF.MaxLength = 30;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(322, 22);
            this.txtCPF.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "Telefone 1 .:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(590, 663);
            this.txtObservacao.MaxLength = 200;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(674, 72);
            this.txtObservacao.TabIndex = 160;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(917, 590);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 53);
            this.button3.TabIndex = 159;
            this.button3.Text = "Total => ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnTotal
            // 
            this.btnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTotal.Location = new System.Drawing.Point(1063, 590);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(201, 53);
            this.btnTotal.TabIndex = 158;
            this.btnTotal.Text = "R$ 0,00";
            this.btnTotal.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(590, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(674, 49);
            this.button2.TabIndex = 157;
            this.button2.Text = "PEDIDO DO CLIENTE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ListaVendas
            // 
            this.ListaVendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idProduto,
            this.Produto,
            this.Quantidade,
            this.valor_vend});
            this.ListaVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaVendas.FullRowSelect = true;
            this.ListaVendas.GridLines = true;
            this.ListaVendas.Location = new System.Drawing.Point(590, 255);
            this.ListaVendas.MultiSelect = false;
            this.ListaVendas.Name = "ListaVendas";
            this.ListaVendas.Size = new System.Drawing.Size(674, 332);
            this.ListaVendas.TabIndex = 156;
            this.ListaVendas.UseCompatibleStateImageBehavior = false;
            this.ListaVendas.View = System.Windows.Forms.View.Details;
            // 
            // idProduto
            // 
            this.idProduto.Text = "Cód.";
            this.idProduto.Width = 82;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 362;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 111;
            // 
            // valor_vend
            // 
            this.valor_vend.Text = "Preço";
            this.valor_vend.Width = 113;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(587, 645);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 16);
            this.label13.TabIndex = 161;
            this.label13.Text = "Observações Gerais : ";
            // 
            // gbDesconto
            // 
            this.gbDesconto.Controls.Add(this.rbPercentual);
            this.gbDesconto.Controls.Add(this.rbValor);
            this.gbDesconto.Controls.Add(this.label3);
            this.gbDesconto.Controls.Add(this.txtPercentual);
            this.gbDesconto.Controls.Add(this.txtValor);
            this.gbDesconto.Controls.Add(this.label4);
            this.gbDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDesconto.Location = new System.Drawing.Point(17, 202);
            this.gbDesconto.Name = "gbDesconto";
            this.gbDesconto.Size = new System.Drawing.Size(564, 308);
            this.gbDesconto.TabIndex = 138;
            this.gbDesconto.TabStop = false;
            this.gbDesconto.Text = "CONCEDER DESCONTO : ";
            // 
            // rbPercentual
            // 
            this.rbPercentual.AutoSize = true;
            this.rbPercentual.Location = new System.Drawing.Point(282, 78);
            this.rbPercentual.Name = "rbPercentual";
            this.rbPercentual.Size = new System.Drawing.Size(128, 28);
            this.rbPercentual.TabIndex = 66;
            this.rbPercentual.Text = "Percentual";
            this.rbPercentual.UseVisualStyleBackColor = true;
            this.rbPercentual.CheckedChanged += new System.EventHandler(this.rbPercentual_CheckedChanged);
            // 
            // rbValor
            // 
            this.rbValor.AutoSize = true;
            this.rbValor.Checked = true;
            this.rbValor.Location = new System.Drawing.Point(134, 78);
            this.rbValor.Name = "rbValor";
            this.rbValor.Size = new System.Drawing.Size(115, 28);
            this.rbValor.TabIndex = 65;
            this.rbValor.TabStop = true;
            this.rbValor.Text = "Por Valor";
            this.rbValor.UseVisualStyleBackColor = true;
            this.rbValor.CheckedChanged += new System.EventHandler(this.rbValor_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(299, 147);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "Percentual :  %";
            // 
            // txtPercentual
            // 
            this.txtPercentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercentual.Location = new System.Drawing.Point(417, 137);
            this.txtPercentual.MaxLength = 50;
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(83, 26);
            this.txtPercentual.TabIndex = 63;
            this.txtPercentual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPercentual_KeyDown);
            this.txtPercentual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentual_KeyPress);
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(114, 137);
            this.txtValor.MaxLength = 50;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(135, 26);
            this.txtValor.TabIndex = 53;
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Valor :  R$";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 71);
            this.button1.TabIndex = 162;
            this.button1.Text = "Total do pedido com Desconto => ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnTotal_Com_Desconto
            // 
            this.btnTotal_Com_Desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotal_Com_Desconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTotal_Com_Desconto.Location = new System.Drawing.Point(321, 590);
            this.btnTotal_Com_Desconto.Name = "btnTotal_Com_Desconto";
            this.btnTotal_Com_Desconto.Size = new System.Drawing.Size(224, 71);
            this.btnTotal_Com_Desconto.TabIndex = 163;
            this.btnTotal_Com_Desconto.Text = "R$ 0,00";
            this.btnTotal_Com_Desconto.UseVisualStyleBackColor = true;
            // 
            // Descontos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.btnTotal_Com_Desconto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbDesconto);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ListaVendas);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbAcesso);
            this.Name = "Descontos";
            this.Text = "MOVIMENTAÇÃO DE DESCONTOS CONCEDIDOS";
            this.Load += new System.EventHandler(this.Descontos_Load);
            this.Controls.SetChildIndex(this.gbAcesso, 0);
            this.Controls.SetChildIndex(this.gbCliente, 0);
            this.Controls.SetChildIndex(this.ListaVendas, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.btnTotal, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.txtObservacao, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.gbDesconto, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnTotal_Com_Desconto, 0);
            this.gbAcesso.ResumeLayout(false);
            this.gbAcesso.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbDesconto.ResumeLayout(false);
            this.gbDesconto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAcesso;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFigura;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.MaskedTextBox txtFone2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtFone1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView ListaVendas;
        private System.Windows.Forms.ColumnHeader idProduto;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader valor_vend;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbDesconto;
        private System.Windows.Forms.RadioButton rbPercentual;
        private System.Windows.Forms.RadioButton rbValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTotal_Com_Desconto;
    }
}
