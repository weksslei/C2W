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
    public partial class AtividadesGerenciais : Form
    {
        
        public AtividadesGerenciais()
        {
            InitializeComponent();
           
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AtividadesGerenciais_Load(object sender, EventArgs e)
        {
            C2W.c2wDataSet.requisicoesDataTable dtRequisicao = new c2wDataSet.requisicoesDataTable();
            requisicoesTableAdapter taRequisicao = new requisicoesTableAdapter();
            dtRequisicao = taRequisicao.RequisicoesNaoAtendidas();
            btnNumeroRequisicoes.Text = (dtRequisicao.Rows.Count).ToString();
        }

        private void AtividadesGerenciais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnGerarRelatorios_Click(object sender, EventArgs e)
        {
            GerarRelatorios gr = new GerarRelatorios();
            gr.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // chamar formulario que herda menu CRUD ( inserir, alterar, excluir, localizar)
            PesquisarUsuarios Pu = new PesquisarUsuarios();
            Pu.ShowDialog();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            PesquisarFornecedores Pf = new PesquisarFornecedores();
            Pf.ShowDialog();
        }

   
        private void btnPortifolio_Click(object sender, EventArgs e)
        {
            PesquisarPortifolio Pp = new PesquisarPortifolio();
            Pp.ShowDialog();
        }

        private void btnCotacoes_Click(object sender, EventArgs e)
        {
            PesquisarCotacoesGeral Pc = new PesquisarCotacoesGeral();
            Pc.ShowDialog();
        }

        private void btnPedidosCompras_Click(object sender, EventArgs e)
        {
            PesquisarPedidoCompras Ppc = new PesquisarPedidoCompras();
            Ppc.ShowDialog();
        }

        private void btnOfertas_Click(object sender, EventArgs e)
        {
            PesquisarOfertas Po = new PesquisarOfertas();
            Po.ShowDialog();
        }

        private void btnDescontos_Click(object sender, EventArgs e)
        {
            PesquisarDescontos Pd = new PesquisarDescontos();
            Pd.ShowDialog();
        }

        private void btnAtenderRequisicoes_Click(object sender, EventArgs e)
        {
            Pesquisar_Requisicoes_Gerente Prg = new Pesquisar_Requisicoes_Gerente();
            Prg.ShowDialog();
            AtividadesGerenciais_Load(sender, e);
        }

        private void btnNumeroRequisicoes_Click(object sender, EventArgs e)
        {
            Pesquisar_Requisicoes_Gerente Prg = new Pesquisar_Requisicoes_Gerente();
            Prg.ShowDialog();
            AtividadesGerenciais_Load(sender, e);
        }
    }
}
