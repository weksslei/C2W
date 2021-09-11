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
                item.Text = dr[0].ToString();
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
            dt = ta.FiltrarFornecedores("%" + txtPesquisar.Text + "%");
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
    }
}
