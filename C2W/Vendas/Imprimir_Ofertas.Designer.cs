namespace C2W
{
    partial class Imprimir_Ofertas
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
            this.ImpressoraComboBox = new System.Windows.Forms.ComboBox();
            this.Imprimir = new System.Windows.Forms.Button();
            this.TesteImpressaoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ImpressoraComboBox
            // 
            this.ImpressoraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImpressoraComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImpressoraComboBox.FormattingEnabled = true;
            this.ImpressoraComboBox.Location = new System.Drawing.Point(174, 59);
            this.ImpressoraComboBox.Name = "ImpressoraComboBox";
            this.ImpressoraComboBox.Size = new System.Drawing.Size(396, 32);
            this.ImpressoraComboBox.TabIndex = 0;
            // 
            // Imprimir
            // 
            this.Imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imprimir.Location = new System.Drawing.Point(647, 27);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(129, 64);
            this.Imprimir.TabIndex = 1;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // TesteImpressaoTextBox
            // 
            this.TesteImpressaoTextBox.Location = new System.Drawing.Point(174, 110);
            this.TesteImpressaoTextBox.Multiline = true;
            this.TesteImpressaoTextBox.Name = "TesteImpressaoTextBox";
            this.TesteImpressaoTextBox.Size = new System.Drawing.Size(602, 422);
            this.TesteImpressaoTextBox.TabIndex = 2;
            // 
            // Imprimir_Ofertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 554);
            this.Controls.Add(this.TesteImpressaoTextBox);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.ImpressoraComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Imprimir_Ofertas";
            this.Text = "Imprimir_Ofertas";
            this.Load += new System.EventHandler(this.Imprimir_Ofertas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ImpressoraComboBox;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.TextBox TesteImpressaoTextBox;
    }
}