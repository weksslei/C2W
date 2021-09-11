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
    public partial class Pesquisar_Entregas : Form
    {
        public Pesquisar_Entregas()
        {
            InitializeComponent();
        }

        private void Pesquisar_Entregas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void Pesquisar_Entregas_Load(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            mtbData.Visible = false;
            cbClientes.Visible = false;
            txtPesquisar.Visible = false;
            btnImprimir.Enabled = false;
            btnVisualizar.Enabled = false;
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            dtPedidoVendas = taPedidoVendas.Listar_Todos_Pedidos_A_Entregar();

            Carrega_Pedidos_Vendas(dtPedidoVendas);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Carrega_Pedidos_Vendas(DataTable dt)
        {
            string Teste, Status_Entrega;
            //clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();

            ListaEntregas.Items.Clear();
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

                ListaEntregas.Items.Add(item);
            }
        }

        public string CodigoPedidoVenda;

        private void ListaEntregas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoPedidoVenda = ListaEntregas.SelectedItems[0].Text;
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
                dtPedidoVendas = taPedidoVendas.PesquisarPedidoVenda_Id(int.Parse(CodigoPedidoVenda));
                if (dtPedidoVendas.Rows[0]["foiEntregue"].ToString() == "0")
                {
                    btnImprimir.Enabled = true;
                    btnVisualizar.Enabled = true;
                }
                else
                {
                    btnImprimir.Enabled = false;
                    btnVisualizar.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Entregas Realizar = new Entregas((CodigoPedidoVenda));
            Realizar.ShowDialog();
            Pesquisar_Entregas Pe = new Pesquisar_Entregas();
            Pe.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // desenvolver imprimir entregas
        }

        private void ListaEntregas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoPedidoVenda = ListaEntregas.SelectedItems[0].Text;
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
                dtPedidoVendas = taPedidoVendas.PesquisarPedidoVenda_Id(int.Parse(CodigoPedidoVenda));
                if (dtPedidoVendas.Rows[0]["foiEntregue"].ToString() == "0")
                {
                    Entregas Realizar = new Entregas((CodigoPedidoVenda));
                    Realizar.ShowDialog();
                    Pesquisar_Entregas_Load(sender, e);
                }
            }
            catch
            {

            }
        }

        public int Opcao;

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OpcaoPesquisa.Text=="Cliente")
            {
                Opcao = 1;
                btnPesquisar.Enabled = false;
                mtbData.Visible = false;

                cbClientes.Visible = false;
                txtPesquisar.Visible = true;
                txtPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Bairro")
            {
                Opcao = 2;
                btnPesquisar.Enabled = false;
                mtbData.Visible = false;

                cbClientes.Visible = false;
                txtPesquisar.Visible = true;
                txtPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Cidade")
            {
                Opcao = 3;
                btnPesquisar.Enabled = false;
                mtbData.Visible = false;

                cbClientes.Visible = false;
                txtPesquisar.Visible = true;
                txtPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Data")
            {
                Opcao = 4;
                btnPesquisar.Enabled = false;
                mtbData.Visible = true;

                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                mtbData.Focus();
            }
            if (OpcaoPesquisa.Text == "Ordem Cronológica")
            {
                Opcao = 5;
                btnPesquisar.Enabled = true;
                mtbData.Visible = false;

                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                btnPesquisar.Focus();
            }
        
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

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            if (e.KeyCode == Keys.Enter)
            {
                if (Opcao == 1)
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
                if (Opcao == 2) // por bairro
                {
                    btnPesquisar.Enabled = true;
                    btnPesquisar.Focus();
                }
                if (Opcao == 3) // por cidade
                {
                    btnPesquisar.Enabled = true;
                    btnPesquisar.Focus();
                }
                txtPesquisar.Text = "";
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            if (Opcao==1) // entregas de um cliente
            {
                dtPedidoVendas = taPedidoVendas.Entregas_De_Um_Cliente(CodigoCliente);
            }
            if(Opcao==2) // por bairro
            {
                dtPedidoVendas = taPedidoVendas.Entregas_Do_Bairro("%" + txtPesquisar.Text + "%");
            }
            if(Opcao==3)  // por cidade
            {
                dtPedidoVendas = taPedidoVendas.Entregas_Por_Cidade("%" + txtPesquisar.Text + "%");
            }
            if(Opcao==4)  //data
            {
                mtbData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                dtPedidoVendas = taPedidoVendas.Entregas_Desta_Data(Convert.ToDateTime(mtbData.Text));
            }
            if (Opcao==5)   // ordem cronológica
            {
                dtPedidoVendas = taPedidoVendas.Listar_Todos_Pedidos_A_Entregar();
            }
            if (dtPedidoVendas.Rows.Count > 0 )
            {
                Carrega_Pedidos_Vendas(dtPedidoVendas);
            }
            else
            {
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPesquisar.Enabled = false;
                mtbData.Text = "";
                txtPesquisar.Text = "";
            }



        }
    }
}
