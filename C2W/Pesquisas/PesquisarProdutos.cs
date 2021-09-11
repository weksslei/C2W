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
    public partial class PesquisarProdutos : Form
    {
        public PesquisarProdutos()
        {
            InitializeComponent();
        }

        public string CopiaCodigo="0";

        public int Opcao = 1;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PesquisarProdutos_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.ListarProdutos();
            Carrega_Produtos(dt);
            PesquisaMessage.Text = " Existem " + ListaProdutos.Items.Count + " produtos cadastrados.";
            txtPesquisar.Focus();
        }

        public void Carrega_Produtos(DataTable dt)
        {
            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5,'0');
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                item.SubItems.Add((String.Format("{0:f3}", dr[4]).ToString)());  //estoque com 3 casas decimais
                                                                                 //idgrupo

                C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
                gruposTableAdapter taGrupos = new gruposTableAdapter();
                dtGrupos = taGrupos.PesquisaGrupoId(int.Parse(dr[5].ToString()));
                             
                item.SubItems.Add(dtGrupos.Rows[0]["nome"].ToString());

                //idum
                C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
                unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();
                dtUM = taUM.PesquisaUnidadeId(int.Parse(dr[6].ToString()));

                item.SubItems.Add(dtUM.Rows[0]["nome"].ToString());


                ListaProdutos.Items.Add(item);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            if (Opcao == 1)
            {
                dt = ta.PesquisaNome("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 2)
            {
                C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
                gruposTableAdapter taGrupos = new gruposTableAdapter();
                dtGrupos = taGrupos.GrupoEscolhido("%" + txtPesquisar.Text + "%");
                if (dtGrupos.Rows.Count > 0)
                {
                    dt = ta.PesquisaGrupo(int.Parse(dtGrupos.Rows[0]["id"].ToString()));
                }
            }
            Carrega_Produtos(dt);


            PesquisaMessage.Text = " Foram encontrados " + ListaProdutos.Items.Count + " registros com a palavra " + txtPesquisar.Text;
        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CopiaCodigo = ListaProdutos.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaProdutos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CopiaCodigo = ListaProdutos.SelectedItems[0].Text;
                Produtos exibir = new Produtos(CopiaCodigo);
                exibir.ShowDialog();
                PesquisarProdutos_Load(sender, e);
            }
            catch
            {

            }
        }
    
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaProdutos.Focused)
                {
                    CopiaCodigo = ListaProdutos.SelectedItems[0].Text;
                }
            }
            Produtos exibir = new Produtos(CopiaCodigo);
            exibir.ShowDialog();
            PesquisarProdutos Pp = new PesquisarProdutos();
            Pp.ShowDialog();

        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaProdutos.Focused)
                {
                    CopiaCodigo = ListaProdutos.SelectedItems[0].Text;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Produtos Novo = new Produtos("-1");
            Novo.ShowDialog();

            PesquisarProdutos Pp = new PesquisarProdutos();
            Pp.ShowDialog();
        }

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpcaoPesquisa.Text == "Nome do Produto")
            {
               
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 1;
            }
            if (OpcaoPesquisa.Text == "Grupo")
            {
              
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 2;
            }
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnPesquisar.Focus();
            }
        }
    }
}
