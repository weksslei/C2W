using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C2W.c2wDataSetTableAdapters;


namespace C2W
{
    public partial class PesquisarOfertas : Form
    {
        public DateTime DataAtual;
        public int Opcao = 2;
        public string DataI, DataF;

        public Frm_Base Funcao = new Frm_Base();

        public PesquisarOfertas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarOfertas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PesquisarOfertas_Load(object sender, EventArgs e)
        {
          
            btnPesquisar.Enabled = false;
            btnOK.Enabled = false;
            mtbDataInicial.Enabled = false;
            mtbDataFinal.Enabled = false;
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();
            DataAtual = DateTime.Today;
            if (Opcao == 2)
            {
                dtOferta = taOferta.ListarOfertas((DataAtual));
            }
            if (Opcao == 3)
            {
                dtOferta = taOferta.ListarOfertasEncerradas(DateTime.Now);
            }
            Carrega_Ofertas(dtOferta);
            TipoPesquisa.Focus();
        }

        public void Carrega_Ofertas(DataTable dt)
        {
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            ListaOfertas.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');


                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));

                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString()); 

                item.SubItems.Add(String.Format("{0:d}", dr[2]).ToString()); //data inicio
                item.SubItems.Add(String.Format("{0:d}", dr[3]).ToString());  // data fim

                item.SubItems.Add((String.Format("{0:f3}", dtProduto.Rows[0]["volume_estocado"]).ToString()));

                item.SubItems.Add(String.Format("{0:C}", dr[4]).ToString());  //"valor_venda

                item.SubItems.Add((String.Format("{0:C}", dr[5]).ToString)());   // preço formato moeda


                if(Convert.ToDateTime(dr[3].ToString()) < DateTime.Now)
                {
                    item.BackColor = Color.Aquamarine;

                    item.SubItems.Add(" Encerrada ");
                }
                else
                {
                    item.SubItems.Add(" Válida ");
                }

                ListaOfertas.Items.Add(item);
            }
        }

        private void TipoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaOfertas.Items.Clear();
            if (TipoPesquisa.Text == "Ofertas de um período")
            {
                Opcao = 1;
                btnPesquisar.Enabled = true;
                mtbDataInicial.Enabled = true;
                mtbDataFinal.Enabled = true;
                mtbDataInicial.Focus();
                //MessageBox.Show(" Buscar período");
            }
            if (TipoPesquisa.Text == "Ofertas Válidas")
            {
                Opcao = 2;
                btnPesquisar.Enabled = false;
                mtbDataInicial.Enabled = false;
                mtbDataFinal.Enabled = false;
                mtbDataFinal.Text = "";
                mtbDataInicial.Text = "";
                //MessageBox.Show(" Buscar ofertas válidas");
                PesquisarOfertas_Load(sender,e);
            }
            if (TipoPesquisa.Text == "Ofertas Encerradas")
            {
                Opcao = 3;
                btnPesquisar.Enabled = false;
                mtbDataInicial.Enabled = false;
                mtbDataFinal.Enabled = false;
                mtbDataFinal.Text = "";
                mtbDataInicial.Text = "";
                //MessageBox.Show(" Buscar ofertas nao válidas");
                PesquisarOfertas_Load(sender, e);
            }
        }

        private void mtbDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = mtbDataInicial.Text;
                if (!Funcao.ValidarData(data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataInicial.Focus();
                }
                else
                {
                    mtbDataFinal.Focus();
                }
            }
        }

        private void mtbDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void mtbDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            //BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                DataF = mtbDataFinal.Text;
                if (!Funcao.ValidarData(DataF))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataFinal.Focus();
                }
                else
                {
                    mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // devolve a formatação
                    mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //              string DataI, DataF;
                    DataI = mtbDataInicial.Text;
                    DataF = mtbDataFinal.Text;

                    // MessageBox.Show(DataI + "   " + DataF);


                    if (Convert.ToDateTime(DataF) > Convert.ToDateTime(DataI))
                    {
                        //btnPesquisar.Enabled = true;
                        btnPesquisar.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" Data Inválida...A data FINAL deverá ser superior a data INICIAL...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbDataFinal.Text = "";
                        mtbDataFinal.Focus();
                    }
                }
            }
        }

        private void mtbDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            mtbDataInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // devolve a formatação
            mtbDataFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            DataI = mtbDataInicial.Text;
            DataF = mtbDataFinal.Text;
            if (!Funcao.ValidarData(DataI) || !Funcao.ValidarData(DataF))     // chama a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbDataInicial.Focus();
            }
            else
            {
                ListaOfertas.Items.Clear();
                // Pesquisa será por período onde será informada data inicial e final...
                // instânciar ofertas
                C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
                ofertasTableAdapter taOferta = new ofertasTableAdapter();

                string DtInicial, DtFinal;
                mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação


                DtInicial = mtbDataInicial.Text;
                DtFinal = mtbDataFinal.Text;

                // MessageBox.Show(DtInicial + "   " + DtFinal);

                dtOferta = taOferta.OfertasDeUmPeriodo(Convert.ToDateTime(DtInicial), Convert.ToDateTime(DtFinal));

                if (dtOferta.Rows.Count > 0)
                {
                    Carrega_Ofertas(dtOferta);
                }
                else
                {
                    MessageBox.Show(" Não existem informações a apresentar para este período...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public string CodigoOferta, CodigoProduto;

        private void ListaOfertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoOferta = ListaOfertas.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaOfertas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoOferta = ListaOfertas.SelectedItems[0].Text;
                ExibeOferta();
                PesquisarOfertas_Load(sender,e);
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ExibeOferta();
        }

      

        public void ExibeOferta()
        {
            if (int.Parse(CodigoOferta) > 0)
            {
                // instânciar ofertas
                C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
                ofertasTableAdapter taOferta = new ofertasTableAdapter();

                //dtOferta = taOferta.PesquisaOfertaId(int.Parse(CodigoOferta));

                Ofertas Editar = new Ofertas(CodigoOferta);
                Editar.ShowDialog();


                dtOferta = taOferta.ListarOfertas(DataAtual);
                Carrega_Ofertas(dtOferta);

            }
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Ofertas Nova = new Ofertas("-1");
            Nova.ShowDialog();

            PesquisarOfertas Po = new PesquisarOfertas();
            Po.ShowDialog();

            //// instânciar ofertas
            //C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            //ofertasTableAdapter taOferta = new ofertasTableAdapter();

            //dtOferta = taOferta.ListarOfertas(DataAtual);
            //Carrega_Ofertas(dtOferta);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir_Ofertas Io = new Imprimir_Ofertas(ListaOfertas);
            Io.ShowDialog();
        }

    }
}
