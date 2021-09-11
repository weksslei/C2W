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
    public partial class PesquisarFornecedores : Form
    {
        public int Opcao = 1;

        public PesquisarFornecedores()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PesquisarFornecedores_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.ListarFornecedores();
            CarregaFornecedores(dt);
            PesquisaMessage.Text = " Existem " + ListaFornecedores.Items.Count + " Fornecedores cadastrados.";
            txtPesquisar.Focus();
        }

        public void CarregaFornecedores(DataTable dt)
        {
            ListaFornecedores.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5,'0');
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                item.SubItems.Add(dr[7].ToString());
               
                ListaFornecedores.Items.Add(item);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();

            if (Opcao == 1) //Nome da Empresa
            {
                dt = ta.FiltrarFornecedores("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 2) //Representante
            {
                dt = ta.PesquisaPorVendedor("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 3) //CNPJ
            {
                dt = ta.PesquisaEmpresaPorCnpj("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 4) //Telefone
            {
                dt = ta.PesquisaEmpresaPorTelefone("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 5)  //E - Mail
            {
                dt = ta.PesquisaPorEmail("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 6) //Cidade
            {
                dt = ta.PesquisaFornecedoresPorCidade("%" + txtPesquisar.Text + "%");
            }


            if (dt.Rows.Count < 1)
            {
                ListaFornecedores.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            CarregaFornecedores(dt);
            PesquisaMessage.Text = " Foram encontrados " + ListaFornecedores.Items.Count + " registros com a palavra " + txtPesquisar.Text;
        }

        public string CodigoFornecedor;

        private void ListaFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaFornecedores_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                Fornecedores Novo = new Fornecedores(CodigoFornecedor);
                Novo.ShowDialog();
                PesquisarFornecedores_Load(sender, e);
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CodigoFornecedor == "")
            {
                if (ListaFornecedores.Focused)
                {
                    CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                }
            }
            Fornecedores Novo = new Fornecedores(CodigoFornecedor);
            Novo.ShowDialog();
            PesquisarFornecedores Pf = new PesquisarFornecedores();
            Pf.ShowDialog();
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (CodigoFornecedor == "")
            {
                if (ListaFornecedores.Focused)
                {
                    CodigoFornecedor = ListaFornecedores.SelectedItems[0].Text;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Fornecedores Novo = new Fornecedores("-1");
            Novo.ShowDialog();
            PesquisarFornecedores Pf = new PesquisarFornecedores();
            Pf.ShowDialog();
        }

       
        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpcaoPesquisa.Text == "Nome da Empresa")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 1;
            }
            if (OpcaoPesquisa.Text == "Representante")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 2;
            }
            if (OpcaoPesquisa.Text == "CNPJ")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 3;
            }
            if (OpcaoPesquisa.Text == "Telefone")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 4;
            }
            if (OpcaoPesquisa.Text == "E-Mail")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 5;
            }
            if (OpcaoPesquisa.Text == "Cidade")
            {
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 6;
            }
        }

    }
}
