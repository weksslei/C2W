using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2W
{
    public partial class Imprimir_Ofertas : Form
    {
        public ListView Oferta;

        public Imprimir_Ofertas(ListView X_Oferta)
        {
            InitializeComponent();
            Oferta = X_Oferta;
        }

        private void Imprimir_Ofertas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Oferta.Items.Count; i++)
            {

                TesteImpressaoTextBox.Text = TesteImpressaoTextBox.Text + " \n" + Oferta.Items[i].Text;
            }
            CarregarListaDeImpressoras();
        }

        private void CarregarListaDeImpressoras()
        {
            ImpressoraComboBox.Items.Clear();

            foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ImpressoraComboBox.Items.Add(printer);
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            using (var printDocument = new System.Drawing.Printing.PrintDocument())
            {
                printDocument.PrintPage += printDocument_PrintPage;
                printDocument.PrinterSettings.PrinterName = ImpressoraComboBox.SelectedItem.ToString();
                printDocument.Print();
            }

        }

        //void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    var printDocument = sender as System.Drawing.Printing.PrintDocument;

        //    if (printDocument != null)
        //    {
        //        using (var font = new Font("Times New Roman", 14))
        //        using (var brush = new SolidBrush(Color.Black))
        //        {
        //            e.Graphics.DrawString(
        //                TesteImpressaoTextBox.Text,
        //                font,
        //                brush,
        //                new RectangleF(0, 0, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));
        //        }
        //    }
        //}



        private string _texto;



        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var printDocument = sender as System.Drawing.Printing.PrintDocument;

            if (printDocument != null)
            {
                using (var fonte = new Font("Times New Roman", 14))
                using (var brush = new SolidBrush(Color.Black))
                {
                    int caracteresNaPagina = 0;
                    int linhasPorPagina = 0;

                    e.Graphics.MeasureString(
                        _texto, fonte, e.MarginBounds.Size, StringFormat.GenericTypographic,
                        out caracteresNaPagina, out linhasPorPagina);

                    e.Graphics.DrawString(
                        _texto.Substring(0, caracteresNaPagina),
                        fonte,
                        brush,
                        e.MarginBounds);

                    _texto = _texto.Substring(caracteresNaPagina);

                    e.HasMorePages = _texto.Length > 0;
                }
            }
        }

        //Como você pode ver, agora temos uma “variável” no nível do formulário chamada “_texto“. 
        //Essa variável guardará sempre o texto que está faltando imprimir.Portanto, quando clicamos
        //no botão “Imprimir“, nós guardamos o texto completo da caixa de texto nessa variável.
        //Depois, conforme formos imprimindo o texto de cada página, iremos ajustando o valor dessa
        //variável para que ela guarde somente o texto que está faltando. 

        //E como é que medimos a quantidade de texto que cabe em uma página? Fácil!
        //É só utilizarmos o método MeasureString da classe Graphics.Esse método recebe o texto,
        //a fonte e as dimensões da área disponível para impressão, retornando a quantidade de 
        //caracteres e linhas que conseguimos imprimir nessa área:


        //int caracteresNaPagina = 0;
        //        int linhasPorPagina = 0;

        //        e.Graphics.MeasureString(
        //    _texto, fonte, e.MarginBounds.Size, StringFormat.GenericTypographic,
        //    out caracteresNaPagina, out linhasPorPagina);



        //Por fim, a outra alteração importante na implementação do evento PrintPage foi
        //feita na última linha, onde indicamos se ainda temos outra página para imprimir 
        //ou não(propriedade HasMorePages). Devemos configurar essa propriedade como “true”
        //caso ainda tenhamos texto para ser impresso(Length maior que zero). 

    }
}
