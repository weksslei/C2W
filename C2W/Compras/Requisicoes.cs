using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C2W.c2wDataSetTableAdapters;

namespace C2W
{
    public partial class Requisicoes : C2W.Frm_Base
    {
        public int CodigoRequisicao;
        public string CodigoProduto = "0";

        public Requisicoes(string CodRequisicao)
        {
            InitializeComponent();
            CodigoRequisicao = int.Parse(CodRequisicao);
        }

        private void Requisicoes_Load(object sender, EventArgs e)
        {
            if (CodigoRequisicao > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                TipoRequisicao.Enabled = false;
                ListaProdutos.Enabled = false;
            }
            if (CodigoRequisicao == -1)
            {
                C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
                produtosTableAdapter ta = new produtosTableAdapter();
                dt = ta.ListarProdutos_ParaCompra();
                Carrega_Produtos(dt);
                txtDataRequisicao.Text = Convert.ToString(DateTime.Today);
                TipoRequisicao.Enabled = true;
                TipoRequisicao.Focus();
            }
            txtDataRequisicao.Enabled = false;
            txtQuantidade.Enabled = false;
            txtDescricao.Enabled = false;
            txtPesquisar.Enabled = false;
            btnPesquisar.Enabled = false;
        }

        public void Carrega_Produtos(DataTable dt)
        {
            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                //item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                item.SubItems.Add((String.Format("{0:f3}", dr[4]).ToString)());  //estoque com 3 casas decimais
                ListaProdutos.Items.Add(item);
            }
        }

        public override void CarregaValores() //da requisição  // teve um erro aqui analisar*
        {                                       // o erro era relacionado a idproduto = 0, pois quando se trata de uma requisicao onde o produto ainda nao esta cadastrado, seu id recebe 0            
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            // instanciar ofertas
            C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
            requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();
            dtRequisicao = taRequisicao.PesquisaRequisicaoId(CodigoRequisicao);
            if (dtRequisicao.Rows.Count > 0)
            {
                lblCodRequisicao.Text = dtRequisicao.Rows[0]["Id"].ToString();

                if (int.Parse(dtRequisicao.Rows[0]["idproduto"].ToString()) == 0)
                {
                    lblProduto.Text = " Novo produto solicitado.";
                    lblEstoqueAtual.Text = " Inexistente.";
                }
                else
                {
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(dtRequisicao.Rows[0]["idproduto"].ToString()));
                    lblProduto.Text = dtProduto.Rows[0]["Nome"].ToString();
                    lblEstoqueAtual.Text = dtProduto.Rows[0]["volume_estocado"].ToString();
                }
                txtDataRequisicao.Text = dtRequisicao.Rows[0]["data"].ToString();
                txtQuantidade.Text = dtRequisicao.Rows[0]["quantidade"].ToString();
                txtDescricao.Text = dtRequisicao.Rows[0]["descricao"].ToString();

            }
        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
                produtosTableAdapter ta = new produtosTableAdapter();
                dt = ta.PesquisaProdutoId(int.Parse(CodigoProduto));
                if (dt.Rows.Count > 0)
                {
                    lblProduto.Text = dt.Rows[0]["nome"].ToString();
                    lblEstoqueAtual.Text = dt.Rows[0]["volume_estocado"].ToString();
                }
                ListaProdutos.Enabled = false;
                txtQuantidade.Enabled = true;
                txtDescricao.Enabled = true;
                txtQuantidade.Focus();
            }
            catch
            {

            }
        }

        private void TipoRequisicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPesquisar.Text = "";
            txtQuantidade.Text = "";
            txtDescricao.Text = "";
            if (TipoRequisicao.Text == "Novo Produto")
            {
                txtPesquisar.Enabled = false;
                btnPesquisar.Enabled = false;
                ListaProdutos.Enabled = false;
                lblProduto.Text = "Sugestão de novo produto!";
                lblEstoqueAtual.Text = "Inexistente";
                txtQuantidade.Enabled = true;
                txtDescricao.Enabled = true;
                lblProdutoNovo.Text = "Descrever novo produto. ";
                txtQuantidade.Focus();
            }
            if (TipoRequisicao.Text == "Ver Lista Produtos")
            {
                lblProduto.Text = "";
                lblEstoqueAtual.Text = "";
                lblProdutoNovo.Text = ".";
                ListaProdutos.Enabled = true;
                txtPesquisar.Enabled = true;
                btnPesquisar.Enabled = true;
                txtPesquisar.Focus();
            }
        }

        private void ListaProdutos_MouseClick(object sender, MouseEventArgs e)
        {
            ListaProdutos.Enabled = true;
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if(e.KeyCode == Keys.Enter)
            {
                txtDescricao.Focus();
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        public override bool Salvar()
        {
            bool bsalvar = false;

            // instanciar requisições
            C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
            requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();

            if(txtQuantidade.Text=="")
            {
                txtQuantidade.Text = "0";
            }
            if(int.Parse(txtQuantidade.Text) < 1)
            {
                MessageBox.Show(" Quantidade informada Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                txtQuantidade.Focus();
                return bsalvar;

            }



            if (Status == StatusCadastro.scInserindo || lblCodRequisicao.Text == "-1")
            {
                bsalvar = (taRequisicao.Insert(int.Parse(CodigoProduto),DateTime.Today, Convert.ToInt32(txtQuantidade.Text),txtDescricao.Text,0) > 0);
            }
            if (Status == StatusCadastro.scEditando)
            {
                bsalvar = (taRequisicao.AlterarRequisicao(Convert.ToInt32(txtQuantidade.Text), txtDescricao.Text, CodigoRequisicao) > 0);
                // alterar requisicao
            }
            if (bsalvar)
            {
                lblCodRequisicao.Text = "-1";
                LimparControles();
                Close();
            }
            return bsalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // instanciar requisições
            C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
            requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();

            bExcluir = (taRequisicao.ExcluirRequisicao(CodigoRequisicao) > 0);

            lblCodRequisicao.Text = "-1";
            LimparControles();
            Close();
            return bExcluir;
        }

        public override bool Localizar() // editar
        {
            bool bLocalizar = false;
            TipoRequisicao.Enabled = false;
            ListaProdutos.Enabled = false;
            txtQuantidade.Enabled = true;
            txtDescricao.Enabled = true;
            txtQuantidade.Focus();
            
            return bLocalizar;
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar.Focus();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ListaProdutos.Enabled = true;
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.PesquisaNome("%" + txtPesquisar.Text + "%");
            if (dt.Rows.Count > 0)
            {
                Carrega_Produtos(dt);
            }
            else
            {
                MessageBox.Show(" Não há informações a serem exibidas para esta pesquisa...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
            }
        }


    }
}
