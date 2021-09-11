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
    public partial class PesquisarRequisicoes : Form
    {
        public PesquisarRequisicoes()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarRequisicoes_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
            requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();
            dtRequisicao = taRequisicao.RequisicoesNaoAtendidas();
            Carrega_Requisicoes(dtRequisicao);
        }

        public void Carrega_Requisicoes(DataTable dt)
        {
            string Teste;
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            if (dt.Rows.Count > 0)
            {
                ListaRequisicoes.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr[0].ToString().PadLeft(5, '0');

                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                    if (dtProduto.Rows.Count > 0)
                    {
                        item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString()); // nome do produto requerido
                    }
                    else
                    {
                        item.BackColor = Color.Aquamarine;
                        item.SubItems.Add("ANALISAR VIABILIDADE DE COMPRA");

                    }                                                               
                    item.SubItems.Add(string.Format("{0:d}", dr[2]).ToString());  // data
                    item.SubItems.Add(dr[3].ToString());   // quantidade
                    item.SubItems.Add(dr[4].ToString());   // descricao

                    if (int.Parse(dr[5].ToString()) == 1)
                    {
                        Teste = "Sim";
                    }
                    else
                    {
                        Teste = "Não";
                    }
                    item.SubItems.Add(Teste);
                    ListaRequisicoes.Items.Add(item);
                }
            }
        }

      
        public string CodigoRequisicao;

        private void ListaCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoRequisicao = ListaRequisicoes.SelectedItems[0].Text;
                btnOK.Enabled = true;
            }
            catch
            {

            }

        }

        private void ListaRequisicoes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoRequisicao = ListaRequisicoes.SelectedItems[0].Text;
                Requisicoes Nova = new Requisicoes(CodigoRequisicao);
                Nova.ShowDialog();
                PesquisarRequisicoes_Load(sender,e);
            }
            catch
            {

            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Requisicoes Nova = new Requisicoes("-1");
            Nova.ShowDialog();
            PesquisarRequisicoes Pr = new PesquisarRequisicoes();
            Pr.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Requisicoes Nova = new Requisicoes(CodigoRequisicao);
            Nova.ShowDialog();
            PesquisarRequisicoes Pr = new PesquisarRequisicoes();
            Pr.ShowDialog();
        }

        private void PesquisarRequisicoes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }
    }
}
