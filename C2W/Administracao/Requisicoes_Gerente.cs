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
    public partial class Requisicoes_Gerente : Form
    {
        public int CodigoRequisicao;

        public Requisicoes_Gerente(string CodRequisicao)
        {
            InitializeComponent();
            CodigoRequisicao = int.Parse(CodRequisicao);
        }

        private void Requisicoes_Gerente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Requisicoes_Gerente_Load(object sender, EventArgs e)
        {
            CarregaValores();
            gbRequisicao.Enabled = false;
        }

        public void CarregaValores() //da requisição  do gerente
        {         
            
               
           
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
                    cbFornecedor.Checked = true;
                    cbProduto.Checked = true;
                    cbPortifolio.Checked = true;
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(dtRequisicao.Rows[0]["idproduto"].ToString()));
                    lblProduto.Text = dtProduto.Rows[0]["Nome"].ToString();
                    lblEstoqueAtual.Text = dtProduto.Rows[0]["volume_estocado"].ToString();
                }
                txtDataRequisicao.Text = dtRequisicao.Rows[0]["data"].ToString();
                txtQuantidade.Text = dtRequisicao.Rows[0]["quantidade"].ToString();
                txtDescricao.Text = dtRequisicao.Rows[0]["descricao"].ToString();

            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedores Novo = new Fornecedores("-1");
            Novo.ShowDialog();
            cbFornecedor.Checked = true;
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Produtos Novo = new Produtos("-1");
            Novo.ShowDialog();
            cbProduto.Checked = true;
        }

        private void btnPortifolio_Click(object sender, EventArgs e)
        {
            PesquisarPortifolio Criar = new PesquisarPortifolio();
            Criar.ShowDialog();
            cbPortifolio.Checked = true;
        }

        private void btnPedidoCompras_Click(object sender, EventArgs e)
        {
            ConstruirPedidoCompra Comprar = new ConstruirPedidoCompra();
            Comprar.ShowDialog();
            cbPedidoCompras.Checked = true;
        }

        private void btnCotacao_Click(object sender, EventArgs e)
        {
            PesquisaCotacoes Cotar = new PesquisaCotacoes();
            Cotar.ShowDialog();
            cbCotacoes.Checked = true;
        }

        private void rbSim_CheckedChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Confirma atendimento de requisição ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // instanciar ofertas
                C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
                requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();
                dtRequisicao = taRequisicao.PesquisaRequisicaoId(CodigoRequisicao);
                if (dtRequisicao.Rows[0]["atendida"].ToString() == "0")
                {
                    taRequisicao.MarcarRequisicaoAtendida(txtDescricao.Text, CodigoRequisicao);
                    MessageBox.Show(" Requisição atendida com sucesso...", "Aviso do sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
