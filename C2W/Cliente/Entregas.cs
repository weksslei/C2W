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
    public partial class Entregas : Form
    {
        public string Codigo_PedidoVenda;

        public Entregas(string CodVenda)
        {
            InitializeComponent();
            Codigo_PedidoVenda = CodVenda;
        }

        private void Entregas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void Entregas_Load(object sender, EventArgs e)
        {
            gbFinalizar.Enabled = false;
            ListaVendas.Enabled = false;
            lblPedido.Text = lblPedido.Text + Codigo_PedidoVenda;
            // buscar clientes
            C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taClientes = new clientesTableAdapter();
            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
            dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(int.Parse(Codigo_PedidoVenda));
            dtClientes = taClientes.PesquisaClienteId(int.Parse(dtPedidoVenda.Rows[0]["idCliente"].ToString()));
            Carrega_Clientes(dtClientes);
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;
            txtObservacao.Text = dtPedidoVenda.Rows[0]["observacao"].ToString();
           

            byte T_Finaliza = Convert.ToByte(dtPedidoVenda.Rows[0]["concluido"].ToString());
            if (T_Finaliza == 1)
            {
                lblStatus_Pedido.Text = " Finalizado";
            }
            else
            {
                lblStatus_Pedido.Text = " Em aberto";
            }


            byte T_Entrega = Convert.ToByte(dtPedidoVenda.Rows[0]["foiEntregue"].ToString());
            if (T_Entrega == 1)
            {
                rbSim.Checked = true;
                rbNao.Checked = false;
            }
            else
            {
                rbNao.Checked = true;
                rbSim.Checked = false;
            }
            C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
            itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
            dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(int.Parse(Codigo_PedidoVenda));

            Carrega_Orcamento_OU_Pedido(dtItensVendidos);
            btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());
            btnConfirmar.Enabled = false;
        }

        public double Somatoria, Editar_SubTotal;

        public void Carrega_Orcamento_OU_Pedido(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            ListaVendas.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dr[1].ToString().PadLeft(5, '0');
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                double Quant = Convert.ToDouble(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:f3}", dr[2])).ToString());
                double Preco = Convert.ToDouble(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                Editar_SubTotal = Quant * Preco;
                ListaVendas.Items.Add(item);
                Somatoria = Somatoria + Editar_SubTotal;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
            
                //dar baixa no estoque
            
            if (MessageBox.Show(" Confirma as alterações deste Pedido de Vendas ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            else
            {
                

                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(int.Parse(Codigo_PedidoVenda));
                if (Convert.ToByte(dtPedidoVenda.Rows[0]["concluido"].ToString()) == 1)
                {
                    // pedido já finalizado
                    if (FoiEntregue == 1)
                    {
                        taPedidoVenda.AtualizarEntregasRealizadas(txtObservacao.Text, 1, DateTime.Now, FoiEntregue, int.Parse(Codigo_PedidoVenda));

                        MessageBox.Show(" Entrega Confirmada no sistema... Operação bem sucedida!!!", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                else
                {
                    if (int.Parse(Codigo_PedidoVenda) > 0 && Finalizar==1)
                    {
                        taPedidoVenda.Pedido_SeTorna_Venda(int.Parse(Codigo_PedidoVenda));

                        // aqui devo atualizar -- no estoque
                        C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                        itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
                        dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(int.Parse(Codigo_PedidoVenda));


                        C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                        produtosTableAdapter taProduto = new produtosTableAdapter();


                        for (int i = 0; i < dtItensVendidos.Rows.Count; i++)
                        {
                            // MessageBox.Show(dtItensComprados.Rows[i]["idproduto"].ToString() + "    " + dtItensComprados.Rows[i]["quantidade"].ToString());
                            //localizar produto na tabela produtos
                            int CodProduto = int.Parse(dtItensVendidos.Rows[i]["id_produto"].ToString());
                            dtProduto = taProduto.PesquisaProdutoId(CodProduto);

                            double NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                            //  MessageBox.Show("Estoque atual => " + NovoEstoque);
                            //    e subtrair um por um no estoque
                            NovoEstoque = NovoEstoque - Convert.ToDouble(dtItensVendidos.Rows[i]["quantidade"].ToString());
                            // MessageBox.Show("Novo Estoque  => " + NovoEstoque);
                            //nesse ponto salvar novo volume_estocado
                            taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), CodProduto);
                        }

                        MessageBox.Show(" Venda confirmada com sucesso... Estoque Atualizado...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    taPedidoVenda.AtualizarEntregasRealizadas(txtObservacao.Text, Finalizar, DateTime.Now, FoiEntregue, int.Parse(Codigo_PedidoVenda));

                    MessageBox.Show(" Informações salvas com sucesso...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Close();
        }

        public byte Finalizar, FoiEntregue;

       

        private void rbSim_CheckedChanged(object sender, EventArgs e)
        {
            Finalizar = 1;
            FoiEntregue = 1;
            btnConfirmar.Enabled = true;
        }

        private void rbNao_CheckedChanged(object sender, EventArgs e)
        {
            Finalizar = 0;
            FoiEntregue = 0;
            btnConfirmar.Enabled = false;
        }

        public void Carrega_Clientes(DataTable dtCliente)
        {
            txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
            txtCPF.Text = dtCliente.Rows[0]["cpf"].ToString();
            txtEmail.Text = dtCliente.Rows[0]["e_mail"].ToString();
            txtFone1.Text = dtCliente.Rows[0]["fone1"].ToString();
            txtFone2.Text = dtCliente.Rows[0]["fone2"].ToString();
        }

        

    }
}
