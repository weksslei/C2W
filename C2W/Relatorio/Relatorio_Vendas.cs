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
    public partial class Relatorio_Vendas : Form
    {
        public Relatorio_Vendas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Relatorio_Vendas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void Relatorio_Vendas_Load(object sender, EventArgs e)
        {
            Anos.Enabled = false;
            btnEmitir.Enabled = false;
            Meses.Focus();
        }

        private void Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anos.Enabled = true;
            Anos.Focus();
        }

        private void Anos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEmitir.Enabled = true;
            btnEmitir.Focus();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            string Mes = "";
            DateTime Data1, Data2;
            switch (Meses.Text)
            {
                case "JANEIRO":
                    Mes = "01";
                    break;
                case "FEVEREIRO":
                    Mes = "02";
                    break;
                case "MARÇO":
                    Mes = "03";
                    break;
                case "ABRIL":
                    Mes = "04";
                    break;
                case "MAIO":
                    Mes = "05";
                    break;
                case "JUNHO":
                    Mes = "06";
                    break;
                case "JULHO":
                    Mes = "07";
                    break;
                case "AGOSTO":
                    Mes = "08";
                    break;
                case "SETEMBRO":
                    Mes = "09";
                    break;
                case "OUTUBRO":
                    Mes = "10";
                    break;
                case "NOVEMBRO":
                    Mes = "11";
                    break;
                case "DEZEMBRO":
                    Mes = "12";
                    break;
                default:
                    Mes = "01";
                    break;
            }
            if (Anos.Text == "ANO")
            {
                Anos.Text = "2010";
            }

            string Periodo = (Anos.Text + "-" + Mes + "-" + "01");

            Data1 = Convert.ToDateTime(Periodo);

            if (int.Parse(Mes) == 12)
            {
                Data2 = Convert.ToDateTime((int.Parse(Anos.Text) + 1) + "-" + "01" + "-" + "01");
            }
            else
            {
                Data2 = Convert.ToDateTime(Anos.Text + "-" + (int.Parse(Mes) + 1) + "-" + "01");
            }

            // instânciar pedidos de vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            dtPedidoVendas = taPedidoVendas.Vendas_De_Um_Periodo(Data1, Data2);

            if (dtPedidoVendas.Rows.Count < 1)
            {
                ListaVendas.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Carrega_Pedidos_Vendas(dtPedidoVendas);
        }

        public void Carrega_Pedidos_Vendas(DataTable dt)
        {
            string Teste, Status_Entrega;
            //clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();

            ListaVendas.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');

                dtCliente = taCliente.PesquisaClienteId(int.Parse(dr[1].ToString()));
                item.SubItems.Add(dtCliente.Rows[0]["nome"].ToString()); //idcliente
                                                                         //   item.SubItems.Add(dr[1].ToString()); //idforncedor
                item.SubItems.Add(String.Format("{0:d}", dr[3]).ToString()); //data sem hora
                item.SubItems.Add((String.Format("{0:C}", dr[4]).ToString)());   // preço formato moeda
                item.SubItems.Add(dr[5].ToString()); // observacao
                if (int.Parse(dr[6].ToString()) == 1)
                {
                    Teste = "Sim";
                }
                else
                {
                    item.BackColor = Color.Peru;
                    Teste = "Não";
                }
                item.SubItems.Add(Teste);

                if (int.Parse(dr[7].ToString()) == 1)
                {
                    if (int.Parse(dr[9].ToString()) == 1)
                    {

                        Status_Entrega = "Entrega realizada...";
                    }
                    else
                    {
                        Status_Entrega = "Cliente aguarda entrega!";
                    }

                }
                else
                {
                    Status_Entrega = "Não solicitou entrega";
                }
                item.SubItems.Add(Status_Entrega);

                ListaVendas.Items.Add(item);
            }
        }


    }
}
