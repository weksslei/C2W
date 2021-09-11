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
    public partial class PesquisarPortifolio : Form
    {
        public PesquisarPortifolio()
        {
            InitializeComponent();
        }

        private void PesquisarPortifolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarPortifolio_Load(object sender, EventArgs e)
        {
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.ListarFornecedores();
            CarregaFornecedores(dt);

            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.ListarProdutos();
            Carrega_Produtos(dtProduto);

            txtPesquisarFornecedores.Focus();
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

        private void btnFiltrarFornecedor_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.FiltrarFornecedores("%" + txtPesquisarFornecedores.Text + "%");
            CarregaFornecedores(dt);
            txtPesquisarProdutos.Focus();
        }

        private void btnFiltrarProdutos_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.PesquisaNome("%" + txtPesquisarProdutos.Text + "%");
            Carrega_Produtos(dt);
        }

        public string CodigoFornecedor="0",CodigoProduto="0";

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                if(int.Parse(CodigoProduto)>0)
                {
                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodigoProduto));
                    lblProduto.Text= dtProduto.Rows[0]["Nome"].ToString();
                }
            }
            catch
            {

            }

        }

        private void ListaFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                if (int.Parse(CodigoFornecedor) > 0)
                {
                    C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
                    fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
                    dt = ta.PesquisaFornecedorId(int.Parse(CodigoFornecedor));
                    lblFornecedor.Text = dt.Rows[0]["nome_empresa"].ToString();
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
                    C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
                    fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
                    dt = ta.PesquisaFornecedorId(int.Parse(CodigoFornecedor));
                    lblFornecedor.Text = dt.Rows[0]["nome_empresa"].ToString();
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
                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodigoProduto));
                    lblProduto.Text = dtProduto.Rows[0]["Nome"].ToString();
                }
            }
            catch
            {

            }
        }

        private void txtPesquisarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnFiltrarProdutos.Focus();
            }
        }

        private void txtPesquisarFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFiltrarFornecedor.Focus();
            }
        }

        private void btnNovoPortifolio_Click(object sender, EventArgs e)
        {
            if (int.Parse(CodigoFornecedor) > 0 && int.Parse(CodigoProduto) > 0)
            {
                Portifolio Novo = new Portifolio(CodigoFornecedor,CodigoProduto);
                Novo.ShowDialog();
            }
            else
            {
                MessageBox.Show(" Gentileza selecionar Fornecedor e Produto...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListaFornecedores.Focus();
            }
            PesquisarPortifolio Pp = new PesquisarPortifolio();
            Pp.ShowDialog();
        }


    }
}
