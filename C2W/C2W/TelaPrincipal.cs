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
    public partial class TelaPrincipal : Form
    {
        public int Cod_Usuario;

        public TelaPrincipal(int copia)
        {
            InitializeComponent();
            Cod_Usuario = copia;
        }

        private void TelaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAtividadesGerenciais_Click(object sender, EventArgs e)
        {
            AtividadesGerenciais ag = new AtividadesGerenciais();
            ag.ShowDialog();
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            PesquisarClientes Pc = new PesquisarClientes();
            Pc.ShowDialog();
        }


        private void btnProdutos_Click(object sender, EventArgs e)
        {
            PesquisarProdutos Pp = new PesquisarProdutos();
            Pp.ShowDialog();
        }

        private void btnDespesas_Click(object sender, EventArgs e)
        {
            PesquisarDespesas Pd = new PesquisarDespesas();
            Pd.ShowDialog();
        }



        public int f2, f3, f4, f5, f6, f7, f8, f9, f10;
        
        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            // verifificar permissoes de usuario
            C2W.c2wDataSet.permissoesDataTable dt_permite = new c2wDataSet.permissoesDataTable();
            permissoesTableAdapter ta = new permissoesTableAdapter();
            dt_permite = ta.PermitidoOperar(Cod_Usuario);

            f2 = int.Parse(dt_permite.Rows[0]["at_gerenciais"].ToString());
            f3 = int.Parse(dt_permite.Rows[0]["clientes"].ToString());
            f4 = int.Parse(dt_permite.Rows[0]["produtos"].ToString());
            f5 = int.Parse(dt_permite.Rows[0]["orcamentos"].ToString());
            f6 = int.Parse(dt_permite.Rows[0]["pedidos"].ToString());
            f7 = int.Parse(dt_permite.Rows[0]["entregas"].ToString());
            f8 = int.Parse(dt_permite.Rows[0]["requisicoes"].ToString());
            f9 = int.Parse(dt_permite.Rows[0]["despesas"].ToString());
            f10 = int.Parse(dt_permite.Rows[0]["backup"].ToString());
            if (f2 == 0)
            {
                btnAtividadesGerenciais.Text = " ACESSO RESTRITO ";
                btnAtividadesGerenciais.Enabled = false;
                btnAtividadesGerenciais.BackColor = Color.LightSlateGray;  //mudar cor para botao desativado
            }
            if (f3 == 0)
            {
                btnClientes.Text = " ACESSO RESTRITO ";
                btnClientes.Enabled = false;
                btnClientes.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f4 == 0)
            {
                btnProdutos.Text = " ACESSO RESTRITO ";
                btnProdutos.Enabled = false;
                btnProdutos.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f5 == 0)
            {
                btnOrcamentos.Text = " ACESSO RESTRITO ";
                btnOrcamentos.Enabled = false;
                btnOrcamentos.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f6 == 0)
            {
                btnPedidosClientes.Text = " ACESSO RESTRITO ";
                btnPedidosClientes.Enabled = false;
                btnPedidosClientes.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f7 == 0)
            {
                btnEntregas.Text = " ACESSO RESTRITO ";
                btnEntregas.Enabled = false;
                btnEntregas.BackColor = Color.LightSlateGray;   //mudar cor
            }
            if (f8 == 0)
            {
                btnRequisicoes.Text = " ACESSO RESTRITO ";
                btnRequisicoes.Enabled = false;
                btnRequisicoes.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f9 == 0)
            {
                btnDespesas.Text = " ACESSO RESTRITO ";
                btnDespesas.Enabled = false;
                btnDespesas.BackColor = Color.LightSlateGray; //mudar cor
            }
            if (f10 == 0)
            {
                btnBackup.Text = " ACESSO RESTRITO ";
                btnBackup.Enabled = false;
                btnBackup.BackColor = Color.LightSlateGray; //mudar cor
            }
            
        }
    }
}
