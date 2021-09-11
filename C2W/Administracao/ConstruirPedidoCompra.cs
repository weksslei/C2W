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
    public partial class ConstruirPedidoCompra : Form
    {
        public ConstruirPedidoCompra()
        {
            InitializeComponent();
        }

        private void rbSim_Click(object sender, EventArgs e)
        {
            ListaCotacoes.Enabled = true;
            btnPesquisar.Enabled = false;
            ListaFornecedores.Enabled = false;
            ListaFornecedores.Items.Clear();
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            dtCotacao = taCotacao.CotacoesNaoCompradas();
            Carrega_Cotacoes(dtCotacao);
        }

        public void Carrega_Cotacoes(DataTable dt)
        {
            //Fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            //dt = ta.PesquisaFornecedorId(CodFornecedor);

            ListaCotacoes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');

                dtEmpresa = taEmpresa.PesquisaFornecedorId(int.Parse(dr[1].ToString()));

                //item.Text = dtEmpresa.Rows[0]["nome_empresa"].ToString();
                item.SubItems.Add(dtEmpresa.Rows[0]["nome_empresa"].ToString()); //idforncedor
                                                                                //   item.SubItems.Add(dr[1].ToString()); //idforncedor
                item.SubItems.Add(String.Format("{0:d}", dr[2]).ToString());    // data sem time
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                ListaCotacoes.Items.Add(item);
            }
        }

        private void rbNao_Click(object sender, EventArgs e)
        {
            ListaCotacoes.Enabled = false;
            ListaCotacoes.Items.Clear();

            btnPesquisar.Enabled = true;
            txtPesquisar.Focus();
            ListaFornecedores.Enabled = true;
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.ListarFornecedores();
            CarregaFornecedores(dt);

        }

        public void CarregaFornecedores(DataTable dt)
        {
            ListaFornecedores.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[6].ToString());
                ListaFornecedores.Items.Add(item);
            }
        }

        private void ConstruirPedidoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ConstruirPedidoCompra_Load(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            btnNovaCompra.Enabled = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.FiltrarFornecedores("%" + txtPesquisar.Text + "%");
            CarregaFornecedores(dt);
        }

        public string CodigoCotacao, CodigoFornecedor;

        private void ListaCotacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnNovaCompra.Enabled = true;
                CodigoCotacao = ListaCotacoes.SelectedItems[0].Text;
                CodigoFornecedor = "0";
            }
            catch
            {

            }
        }

       
        private void ListaFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnNovaCompra.Enabled = true;
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                CodigoCotacao = "0";
            }
            catch
            {

            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            Compras Nova = new Compras(CodigoCotacao ,CodigoFornecedor, "0"); //compra nova manda 0 para indicar novo registro
            Nova.ShowDialog();

            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            dtCotacao = taCotacao.CotacoesNaoCompradas();
            Carrega_Cotacoes(dtCotacao);

        }
    }
}
