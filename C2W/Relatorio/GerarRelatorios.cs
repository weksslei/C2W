using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2W
{
    public partial class GerarRelatorios : Form
    {
        public GerarRelatorios()
        {
            InitializeComponent();
        }

        private void GerarRelatorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAniversariantes_Click(object sender, EventArgs e)
        {
            Relatorio_Aniversariantes RA = new Relatorio_Aniversariantes();
            RA.ShowDialog();
        }

        private void btnPedidosCompras_Click(object sender, EventArgs e)
        {
            Relatorio_Pedido_Compras RC = new Relatorio_Pedido_Compras();
            RC.ShowDialog();
        }

        private void btnClientesInativos_Click(object sender, EventArgs e)
        {
            Relatorio_Clientes_Inativos RI = new Relatorio_Clientes_Inativos();
            RI.ShowDialog();
        }

        private void btnDespesas_Click(object sender, EventArgs e)
        {
            Relatorio_Contas_A_Pagar R_Contas = new Relatorio_Contas_A_Pagar();
            R_Contas.ShowDialog();
        }

        private void btnRequisicoesCompras_Click(object sender, EventArgs e)
        {
            Relatorio_Requisicoes R_Requisicoes = new Relatorio_Requisicoes();
            R_Requisicoes.ShowDialog();
        }

        private void btnProdutosReceber_Click(object sender, EventArgs e)
        {
            Relatorio_Produtos_A_Receber RPAR = new Relatorio_Produtos_A_Receber();
            RPAR.ShowDialog();
        }

        private void btnPedidosVendas_Click(object sender, EventArgs e)
        {
            Relatorio_Pedidos_Vendas RPV = new Relatorio_Pedidos_Vendas();
            RPV.ShowDialog();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Relatorio_Vendas RV = new Relatorio_Vendas();
            RV.ShowDialog();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            Relatorio_Orcamentos RO = new Relatorio_Orcamentos();
            RO.ShowDialog();
        }
    }
}
