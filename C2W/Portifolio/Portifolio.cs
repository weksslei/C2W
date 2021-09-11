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
    public partial class Portifolio : Form
    {
        public string CodFornecedor, CodProduto;

        public Portifolio(string Cod1, string Cod2)
        {
            InitializeComponent();
            CodFornecedor = Cod1;
            CodProduto = Cod2;
        }

        private void Portifolio_Load(object sender, EventArgs e)
        {
            CarregaValores();
            txtEmpresa.Enabled = false;
            txtCnpj.Enabled = false;
            txtInscricao.Enabled = false;
            txtRepresentante.Enabled = false;
            txtEmail.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;
            txtCep.Enabled = false;
            txtEndereco.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtObservacao.Enabled = false;
            txtNome.Enabled = false;
        }

        private void Portifolio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        public void CarregaValores()
        {
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();

            dt = ta.PesquisaFornecedorId(int.Parse(CodFornecedor));

            if (dt.Rows.Count > 0)
            {
                lbCodUsuario.Text = dt.Rows[0]["Id"].ToString();
                txtEmpresa.Text = dt.Rows[0]["nome_Empresa"].ToString();
                txtCnpj.Text = dt.Rows[0]["cnpj"].ToString();
                txtInscricao.Text = dt.Rows[0]["inscricao_estadual"].ToString();
                txtRepresentante.Text = dt.Rows[0]["nome_vendedor"].ToString();
                txtEmail.Text = dt.Rows[0]["e_mail"].ToString();
                txtFone1.Text = dt.Rows[0]["fone1"].ToString();
                txtFone2.Text = dt.Rows[0]["fone2"].ToString();
                txtCep.Text = dt.Rows[0]["cep"].ToString();
                txtEndereco.Text = dt.Rows[0]["endereco"].ToString();
                txtComplemento.Text = dt.Rows[0]["complemento"].ToString();
                txtBairro.Text = dt.Rows[0]["bairro"].ToString();
                txtCidade.Text = dt.Rows[0]["cidade"].ToString();
                txtEstado.Text = dt.Rows[0]["estado"].ToString();
                txtObservacao.Text = dt.Rows[0]["observacao"].ToString();
            }

            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));
            if (dtProduto.Rows.Count > 0)
            {
                lbCodProduto.Text = dtProduto.Rows[0]["Id"].ToString();
                txtNome.Text = dtProduto.Rows[0]["Nome"].ToString();
            }
        }

        private void btnSalvarPortifolio_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.portifolioDataTable dt = new c2wDataSet.portifolioDataTable();
            portifolioTableAdapter ta = new portifolioTableAdapter();
            dt = ta.VerificarExistenciaPortifolio(int.Parse(CodFornecedor),int.Parse(CodProduto));
            if (dt.Rows.Count == 0)
            {
                ta.Insert(int.Parse(CodFornecedor), int.Parse(CodProduto));
                MessageBox.Show(" Portifólio Salvo com sucesso...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Close();
            }
            else
            {
                MessageBox.Show(" Portifólio já existente... Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
            //descomentar assim q tratados os dados
        }

    }
}
