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
    public partial class PesquisaCotacoes : Form
    {
        public PesquisaCotacoes()
        {
            InitializeComponent();
        }

        private void PesquisaCotacoes_Load(object sender, EventArgs e)
        {
            btnContinuar.Enabled = false;
            txtPesquisar.Focus();
        }

        private void PesquisaCotacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
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

        public void Carrega_Produtos(DataTable dt)
        {
            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                ListaProdutos.Items.Add(item);
            }
        }

      
        //Sao realizas  as pesquisas onde o usuario escolhe se a faz por produto ou por fornecedor
        private void rbFornecedor_Click(object sender, EventArgs e)
        {
            ListaProdutos.Items.Clear();
            lblPesquisar.Text = "Selecione um Fornecedor para realizar uma cotação: ";
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.ListarFornecedores();
            
            CarregaFornecedores(dt);
            txtPesquisar.Focus();
        }

        private void rbProduto_Click(object sender, EventArgs e)
        {
            btnContinuar.Enabled = false;
            ListaFornecedores.Items.Clear();
            lblPesquisar.Text = "Selecione um produto para realizar uma cotação:    ";
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.ListarProdutos_ParaCompra();
            
            Carrega_Produtos(dtProduto);
            txtPesquisar.Focus();
        }
        
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(rbFornecedor.Checked==true)
            {
                C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
                fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
                dt = ta.FiltrarFornecedores("%" + txtPesquisar.Text + "%");
                CarregaFornecedores(dt);
            }
            if(rbProduto.Checked==true)
            {
                C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
                produtosTableAdapter ta = new produtosTableAdapter();
                dt = ta.PesquisaNome("%" + txtPesquisar.Text + "%");
                Carrega_Produtos(dt);
                
            }
        }

        public string CodigoFornecedor = "0",CodigoProduto="0";

        private void ListaFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                if (int.Parse(CodigoFornecedor) > 0)
                {
                    btnContinuar.Enabled = true;
                    MostrarPortifolio();
                }
            }
            catch
            {

            }
        }

        private void ListaFornecedores_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                if (int.Parse(CodigoFornecedor) > 0)
                {
                    Cotacoes Nova = new Cotacoes(CodigoFornecedor, 0);
                    Nova.ShowDialog();
                }
            }
            catch
            {

            }
        }
            

        public void MostrarPortifolio()
        {
            C2W.c2wDataSet.portifolioDataTable dt = new c2wDataSet.portifolioDataTable();
            portifolioTableAdapter ta = new portifolioTableAdapter();
            dt = ta.PortifolioProdutos(int.Parse(CodigoFornecedor));  //todos os produtos de um fornecedor
                                                                      //seleciona os codigos dos produtos de uma empresa

            C2W.c2wDataSet.produtosDataTable dtp = new c2wDataSet.produtosDataTable();
            produtosTableAdapter tap = new produtosTableAdapter();

            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dt.Rows)  // rodar produto por produto chave estrangeira
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[1].ToString().PadLeft(5, '0');
                dtp = tap.PesquisaProdutoId(int.Parse(dr[1].ToString())); //pesquisa o produto
                if (dtp.Rows.Count > 0)
                {
                    item.SubItems.Add(dtp.Rows[0]["Nome"].ToString());
                }
                ListaProdutos.Items.Add(item);
            }
        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                if (int.Parse(CodigoProduto) > 0)
                {
                    MostrarFornecedores();
                }
            }
            catch
            {

            }
        }

        private void ListaProdutos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                if (int.Parse(CodigoProduto) > 0)
                {
                    MostrarFornecedores();
                }
            }
            catch
            {

            }
        }

        public void MostrarFornecedores()
        {
            btnContinuar.Enabled = false;
            C2W.c2wDataSet.portifolioDataTable dt = new c2wDataSet.portifolioDataTable();
            portifolioTableAdapter ta = new portifolioTableAdapter();
            dt = ta.PortifolioFornecedores(int.Parse(CodigoProduto));  //todos os fornecedores de um produto
                                                                       //seleciona os codigos dos fornecedores

            C2W.c2wDataSet.fornecedoresDataTable dtf = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taf = new fornecedoresTableAdapter();

            ListaFornecedores.Items.Clear();
            foreach (DataRow dr in dt.Rows)  // rodar empresa por empresa chave estrangeira
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');

                dtf = taf.PesquisaFornecedorId(int.Parse(dr[0].ToString())); //pesquisa o produto
                if (dtf.Rows.Count > 0)
                {
                    item.SubItems.Add(dtf.Rows[0]["Nome_empresa"].ToString());
                    item.SubItems.Add(dtf.Rows[0]["Nome_vendedor"].ToString());
                    item.SubItems.Add(dtf.Rows[0]["fone1"].ToString());
                }
                ListaFornecedores.Items.Add(item);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Cotacoes Nova = new Cotacoes(CodigoFornecedor,0);
            Nova.ShowDialog();
        }


    }
}
