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
    public partial class PesquisarDescontos : Form
    {
        public int Opcao;
        public PesquisarDescontos()
        {
            InitializeComponent();
        }

        private void PesquisarDescontos_KeyDown(object sender, KeyEventArgs e)
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

        private void PesquisarDescontos_Load(object sender, EventArgs e)
        {
            lblOpcoes.Visible = false;
            Meses.Visible = false;
            Anos.Visible = false;
            btnPesquisar.Enabled = false;
            mtbData.Visible = false;
          
            cbClientes.Visible = false;
            txtPesquisar.Visible = false;
            btnPesquisar.Enabled = false;
            C2W.c2wDataSet.descontosDataTable dtDesconto = new c2wDataSet.descontosDataTable();
            descontosTableAdapter taDesconto = new descontosTableAdapter();
            dtDesconto = taDesconto.ListarUltimos_50_Descontos();
            Carregar_Descontos(dtDesconto);
        }

        public void Carregar_Descontos(DataTable dt)
        {
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            //clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();

            ListaDescontos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(String.Format("{0:d}", dr[1]).ToString()); //data sem hora
                item.SubItems.Add(dr[2].ToString().PadLeft(5, '0'));
                dtPedidoVendas = taPedidoVendas.PesquisarPedidoVenda_Id(int.Parse(dr[2].ToString())); // pesquisar id do pedido

                dtCliente = taCliente.PesquisaClienteId(int.Parse(dtPedidoVendas.Rows[0]["idCliente"].ToString()));
                item.SubItems.Add(dtCliente.Rows[0]["nome"].ToString());

                item.SubItems.Add(String.Format("{0:C2}", dtPedidoVendas.Rows[0]["total"]).ToString());

                item.SubItems.Add(String.Format("{0:C2}", dr[3]).ToString()); //valor descontado
                item.SubItems.Add((String.Format("{0:f}", dr[4]).ToString)());   // taxa
                
               
                ListaDescontos.Items.Add(item);
            }
        }

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OpcaoPesquisa.Text == "Cliente")
            {
                Opcao = 1;
                lblOpcoes.Visible = false;
                Meses.Visible = false;
                Anos.Visible = false;
                btnPesquisar.Enabled = false;
                mtbData.Visible = false;
               
                cbClientes.Visible = false;
                txtPesquisar.Visible = true;
                txtPesquisar.Focus();
            }
            if(OpcaoPesquisa.Text == "Mês")
            {
                Opcao = 2;
                lblOpcoes.Visible = true;
                Meses.Visible = true;
                Anos.Visible = true;
                btnPesquisar.Enabled = false;
                mtbData.Visible = false;
             
                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                Meses.Focus();
            }
            if(OpcaoPesquisa.Text == "Data")
            {
                Opcao = 3;
                lblOpcoes.Visible = false;
                Meses.Visible = false;
                Anos.Visible = false;
                btnPesquisar.Enabled = false;
                mtbData.Visible = true;
             
                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                mtbData.Focus();
            }
        }

        private void Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anos.Focus();
        }

        private void Anos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = true;
            btnPesquisar.Focus();
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            if (e.KeyCode == Keys.Enter)
            {
                //  btnPesquisar.Enabled = true;
                txtPesquisar.Visible = false;
                cbClientes.Visible = true;
                dtCliente = taCliente.Filtrar_Cliente_Nome("%" + txtPesquisar.Text + "%");

                cbClientes.Items.Clear();
                if (dtCliente != null)
                {
                    for (int i = 0; i < dtCliente.Rows.Count; i++)
                    {
                        cbClientes.Items.Add(dtCliente.Rows[i]["id"].ToString().PadLeft(5, '0') + "   " + dtCliente.Rows[i]["nome"].ToString());
                    }
                }

                cbClientes.Focus();
            }
        }

        public string NomeCliente;
        public int CodigoCliente;

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            NomeCliente = cbClientes.SelectedItem.ToString();
            CodigoCliente = int.Parse(NomeCliente.Substring(0, 5));

            btnPesquisar.Enabled = true;
            btnPesquisar.Focus();
        }

        Frm_Base Funcao = new Frm_Base();
        public string Data;

        private void mtbData_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                Data = mtbData.Text;
                if (!Funcao.ValidarData(Data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbData.Focus();
                }
                else
                {
                    //mtbData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // devolve a formatação
                      // MessageBox.Show(DataI + "   " + DataF);
                    btnPesquisar.Enabled = true;
                    btnPesquisar.Focus();
                }
            }
        }
        
        private void mtbData_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        public void Carrega2(DataTable dt)
        {
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();

            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(String.Format("{0:d}", dr[1]).ToString()); //data sem hora
                item.SubItems.Add(dr[2].ToString().PadLeft(5, '0'));
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(int.Parse(dr[2].ToString())); // pesquisar id do pedido

                dtCliente = taCliente.PesquisaClienteId(int.Parse(dtPedidoVenda.Rows[0]["idCliente"].ToString()));
                item.SubItems.Add(dtCliente.Rows[0]["nome"].ToString());

                item.SubItems.Add(String.Format("{0:C2}", dtPedidoVenda.Rows[0]["total"]).ToString());

                item.SubItems.Add(String.Format("{0:C2}", dr[3]).ToString()); //valor descontado
                item.SubItems.Add((String.Format("{0:f}", dr[4]).ToString)());   // taxa


                ListaDescontos.Items.Add(item);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();

            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();

            // instânciar orçamentos
            C2W.c2wDataSet.descontosDataTable dtDesconto = new c2wDataSet.descontosDataTable();
            descontosTableAdapter taDesconto = new descontosTableAdapter();
            if (Opcao == 1)   // Nome do Cliente
            {
                ListaDescontos.Items.Clear();
                //dtCliente = taCliente.Filtrar_Cliente_Nome(NomeCliente);
                dtPedidoVenda = taPedidoVenda.Listar_PedidosDeUmCliente(CodigoCliente);

               // MessageBox.Show(" " + dtPedidoVenda.Rows.Count);
                for(int i=0; i < dtPedidoVenda.Rows.Count; i++)
                {
                    dtDesconto = taDesconto.Descontos_PedidosVendas(int.Parse(dtPedidoVenda.Rows[i]["id"].ToString()));

                  //  MessageBox.Show(" " + dtPedidoVenda.Rows[i]["Id"].ToString());
                    if(dtDesconto.Rows.Count > 0)
                    {
                        Carrega2(dtDesconto);                   
                    }
                }
                
                //dtDesconto = taDesconto.Descontos_Cliente(CodigoCliente); // concertar query
            }
            if (Opcao == 2)  // por mes
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

                dtDesconto = taDesconto.Descontos_Mes(Data1, Data2);
               
                
            }
            if (Opcao == 3)  // uma data
            {
                mtbData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                dtDesconto = taDesconto.Desconto_Data(Convert.ToDateTime(mtbData.Text));
            }


            if (dtDesconto.Rows.Count > 0 && Opcao != 1)
            {
                Carregar_Descontos(dtDesconto);
            }
            else
            {
                if (Opcao != 1 || (Opcao==1 && ListaDescontos.Items.Count < 1))
                {
                    ListaDescontos.Items.Clear();
                    MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnPesquisar.Enabled = false;
                mtbData.Text = "";
                txtPesquisar.Text = "";

            }
        }
    }
}
