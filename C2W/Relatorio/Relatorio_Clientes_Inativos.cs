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
    public partial class Relatorio_Clientes_Inativos : Form
    {
        public Relatorio_Clientes_Inativos()
        {
            InitializeComponent();
        }

        private void Relatorio_Clientes_Inativos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Relatorio_Clientes_Inativos_Load(object sender, EventArgs e)
        {

            btnPesquisar.Enabled = false;
            OpcaoPesquisa.Focus();
        }

        public int Opcao = 0;

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaClientes.Items.Clear();
            if(OpcaoPesquisa.Text== "7 DIAS")
            {
                Opcao = 1;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
            if(OpcaoPesquisa.Text== "15 DIAS")
            {
                Opcao = 2;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "30 DIAS")
            {
                Opcao = 3;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "60 DIAS")
            {
                Opcao = 4;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
           
            //C2W.c2wDataSet.pedidos_vendasDataTable dtPedidos_Vendas = new c2wDataSet.pedidos_vendasDataTable();
            //pedidos_vendasTableAdapter taPedidos_Vendas = new pedidos_vendasTableAdapter();

            DateTime Data_Consulta;

            if(Opcao==1)
            {
                Data_Consulta = DateTime.Today.AddDays(-7);
                dtCliente = taCliente.Clientes_Inativos(Data_Consulta);
                Carrega_Clientes(dtCliente);
            }
            if (Opcao == 2)
            {
                Data_Consulta = DateTime.Today.AddDays(-15);
                dtCliente = taCliente.Clientes_Inativos(Data_Consulta);
                Carrega_Clientes(dtCliente);
            }
            if (Opcao == 3)
            {
                Data_Consulta = DateTime.Today.AddDays(-30);
                dtCliente = taCliente.Clientes_Inativos(Data_Consulta);
                Carrega_Clientes(dtCliente);
            }
            if (Opcao == 4)
            {
                Data_Consulta = DateTime.Today.AddDays(-60);
                dtCliente = taCliente.Clientes_Inativos(Data_Consulta);
                Carrega_Clientes(dtCliente);
            }
        }



        public void Carrega_Clientes(DataTable dt)
        {
            //listaClientes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                // formatar campo mostrar somente data
                item.SubItems.Add(string.Format("{0:d}", dr[2]).ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                listaClientes.Items.Add(item);
            }
        }
    }
}
