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
    public partial class PesquisarPedidosVendas : Form
    {
        public int Opcao = 1;

        public PesquisarPedidosVendas()
        {
            InitializeComponent();
        }

        private void PesquisarPedidosVendas_KeyDown(object sender, KeyEventArgs e)
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

        private void PesquisarPedidosVendas_Load(object sender, EventArgs e)
        {
            btnDesconto.Enabled = false;
            btnVisualizar.Enabled = false;
            btnPesquisar.Enabled = false;

            txtPesquisar.Visible = false;
            cbClientes.Visible = false;
            lblDataInicial.Visible = false;
            lblDataFinal.Visible = false;
            mtbDataInicial.Visible = false;
            mtbDataFinal.Visible = false;

            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            dtPedidoVendas = taPedidoVendas.Listar_Todos_PedidosNaoConcluidos();

            Carrega_Pedidos_Vendas(dtPedidoVendas);
        }

        public void Carrega_Pedidos_Vendas(DataTable dt)
        {
            string Teste,Status_Entrega;
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

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbDataFinal.Text = "";
            mtbDataInicial.Text = "";
            txtPesquisar.Text = "";
            if (OpcaoPesquisa.Text == "Pedidos não finalizados")
            {
                txtPesquisar.Visible = false;
                cbClientes.Visible = false;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;

                Opcao = 1;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
                
            }
            if (OpcaoPesquisa.Text == "Pedidos a entregar")
            {
                txtPesquisar.Visible = false;
                cbClientes.Visible = false;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;

                Opcao = 2;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Pedidos de um Cliente")
            {
                txtPesquisar.Visible = true;
                cbClientes.Visible = false;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;
                btnPesquisar.Enabled = false;

                Opcao = 3;
                txtPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Cliente a finalizar")
            {
                txtPesquisar.Visible = true;
                cbClientes.Visible = false;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;
                btnPesquisar.Enabled = false;

                Opcao = 4;
                txtPesquisar.Focus();
                
            }
            if (OpcaoPesquisa.Text == "Período")
            {
                txtPesquisar.Visible = false;
                cbClientes.Visible = false;
                lblDataInicial.Visible = true;
                lblDataFinal.Visible = true;
                mtbDataInicial.Visible = true;
                mtbDataFinal.Visible = true;

                Opcao = 5;
                btnPesquisar.Enabled = false;
                mtbDataInicial.Enabled = true;
                mtbDataFinal.Enabled = true;

                mtbDataInicial.Focus();
                
            }

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
        public string DataI, DataF;

        private void mtbDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = mtbDataInicial.Text;
                if (!Funcao.ValidarData(data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataInicial.Focus();
                }
                else
                {

                    mtbDataFinal.Focus();
                }
            }
        }

        private void mtbDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);

        }

        private void mtbDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                DataF = mtbDataFinal.Text;
                if (!Funcao.ValidarData(DataF))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataFinal.Focus();
                }
                else
                {
                    mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // devolve a formatação
                    mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //              string DataI, DataF;
                    DataI = mtbDataInicial.Text;
                    DataF = mtbDataFinal.Text;

                    // MessageBox.Show(DataI + "   " + DataF);


                    if (Convert.ToDateTime(DataF) > Convert.ToDateTime(DataI))
                    {
                        btnPesquisar.Enabled = true;
                        btnPesquisar.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" Data Inválida...A data FINAL deverá ser superior a data INICIAL...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbDataFinal.Text = "";
                        mtbDataFinal.Focus();
                    }
                }
            }
        }

        private void mtbDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);

        }

       
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
          
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();

            //// instânciar orçamentos
            //C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            //orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();

            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVendas = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVendas = new pedidos_vendasTableAdapter();
            
           

            if (Opcao == 1)   //            Pedidos não finalizados
            {
                dtPedidoVendas = taPedidoVendas.Listar_Todos_PedidosNaoConcluidos();
            }
            if (Opcao == 2)   //Pedidos a entregar
            {
                dtPedidoVendas = taPedidoVendas.Listar_Pedidos_A_Entregar();
            }
            if (Opcao == 3)    //Pedidos de um Cliente
            {
                dtPedidoVendas = taPedidoVendas.Listar_PedidosDeUmCliente(CodigoCliente);               
            }
            if (Opcao==4)   //Cliente a finalizar
            {
                dtPedidoVendas = taPedidoVendas.Listar_PedidosDeUmCliente_A_Finalizar(CodigoCliente);
            }
            if(Opcao==5)   //Período
            {
                mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                dtPedidoVendas = taPedidoVendas.PedidosDeUmPeriodo(Convert.ToDateTime(mtbDataInicial.Text), Convert.ToDateTime(mtbDataFinal.Text));
            }
            
            
            


            if (dtPedidoVendas.Rows.Count > 0)
            {
                Carrega_Pedidos_Vendas(dtPedidoVendas);

            }
            else
            {
                ListaVendas.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPesquisar.Enabled = false;
                mtbDataInicial.Text = "";
                mtbDataFinal.Text = "";
                txtPesquisar.Text = "";
               
            }
        }

        public string CodigoPedidoVenda;

        private void ListaCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnDesconto.Enabled = true;
                btnVisualizar.Enabled = true;
                CodigoPedidoVenda = ListaVendas.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Vendas Exibir = new Vendas(int.Parse(CodigoPedidoVenda),0);
            Exibir.ShowDialog();
            PesquisarPedidosVendas Ppv = new PesquisarPedidosVendas();
            Ppv.ShowDialog();
        }
        
        private void ListaCompras_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoPedidoVenda = ListaVendas.SelectedItems[0].Text;
                Vendas Exibir = new Vendas(int.Parse(CodigoPedidoVenda), 0);
                Exibir.ShowDialog();
                PesquisarPedidosVendas_Load(sender, e);
            }
            catch
            {

            }
        }

      

        private void cbNovoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close();
            if (cbNovoPedido.Text == "Escolher Orçamento")
            {
                PesquisarOrcamentos Po = new PesquisarOrcamentos();
                Po.ShowDialog();
            }
            if(cbNovoPedido.Text == "Sem Orçamento")
            {
                // criar novo pedido sem ter feito orçamento selecionar cliente na tela vendas
                Vendas Exibir = new Vendas(-1, 0);
                Exibir.ShowDialog();
            }
            PesquisarPedidosVendas Ppv = new PesquisarPedidosVendas();
            Ppv.ShowDialog();
        }


        private void btnDesconto_Click(object sender, EventArgs e)
        {            
            Desconto Exibir = new Desconto(CodigoPedidoVenda);
            Exibir.ShowDialog();
            PesquisarPedidosVendas Ppv = new PesquisarPedidosVendas();
            Ppv.ShowDialog();
        }


    }    
}
