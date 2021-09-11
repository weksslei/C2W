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
    public partial class Desconto : Form
    {
        public int CodPedidoVenda;

        public Desconto(string CodigoPedidoVenda)
        {
            InitializeComponent();
            CodPedidoVenda = int.Parse(CodigoPedidoVenda);
        }

        private void Desconto_Load(object sender, EventArgs e)
        {
            gbCliente.Enabled = false;
            gbDesconto.Enabled = false;
            //txtObservacao.Enabled = false;
            //fazer login de gerente com senha
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtUsuario.Text == "adm" && txtSenha.Text == "123adm")
                {
                    Liberar_Desconto();
                }
                else
                {
                    //acesso negado
                    MessageBox.Show(" Acesso Negado...", "Usuário / Senha Inválidos !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
            }
        }


        public void Liberar_Desconto()
        {
            gbDesconto.Enabled = true;

            C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taClientes = new clientesTableAdapter();

            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
            dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(CodPedidoVenda);
            dtClientes = taClientes.PesquisaClienteId(int.Parse(dtPedidoVenda.Rows[0]["idCliente"].ToString()));
            Carrega_Clientes(dtClientes);
            txtObservacao.Text = dtPedidoVenda.Rows[0]["observacao"].ToString();
            C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
            itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
            dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(CodPedidoVenda);

            Carrega_Orcamento_OU_Pedido(dtItensVendidos);
            btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());
            txtPercentual.Enabled = false;
            txtValor.Focus();
        }

        public double Somatoria, Editar_SubTotal, Copia_Total;

        private void rbPercentual_CheckedChanged(object sender, EventArgs e)
        {
            btnTotal_Com_Desconto.Text = "";
            txtValor.Text = "";
            txtValor.Enabled = false;
            txtPercentual.Enabled = true;
            txtPercentual.Focus();
        }

        private void rbValor_CheckedChanged(object sender, EventArgs e)
        {
            btnTotal_Com_Desconto.Text = "";
            txtPercentual.Text = "";
            txtPercentual.Enabled = false;
            txtValor.Enabled = true;
            txtValor.Focus();
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtValor.Text != "")
            {

                ValorDesconto = Convert.ToDouble(txtValor.Text);
                ValorTaxa = (ValorDesconto * 100) / Somatoria;
                txtPercentual.Text = (ValorTaxa).ToString();
                btnTotal_Com_Desconto.Text = (String.Format("{0:C}", (Somatoria - ValorDesconto)).ToString());
            }
        }

        Frm_Base Funcao = new Frm_Base();

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarMoeda(sender, e);
        }

        private void txtPercentual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ValorTaxa = Convert.ToDouble(txtPercentual.Text);
                ValorDesconto = (ValorTaxa / 100) * Somatoria;
                txtValor.Text = (ValorDesconto).ToString();
                btnTotal_Com_Desconto.Text = (String.Format("{0:C}", (Somatoria - ValorDesconto)).ToString());
            }
        }

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarMoeda(sender, e);

        }

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

        private void Desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

      
        public double ValorDesconto, ValorTaxa;

        public void Carrega_Clientes(DataTable dtCliente)
        {
            // CodigoCliente = int.Parse(dtCliente.Rows[0]["id"].ToString());
            txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
            txtCPF.Text = dtCliente.Rows[0]["cpf"].ToString();
            txtEmail.Text = dtCliente.Rows[0]["e_mail"].ToString();
            txtFone1.Text = dtCliente.Rows[0]["fone1"].ToString();
            txtFone2.Text = dtCliente.Rows[0]["fone2"].ToString();
        }

        Vendas Importa_Funcao = new Vendas(0,0);

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "" || txtValor.Text=="0")
            {
                MessageBox.Show(" Valor de desconto inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValor.Focus();
            }
            else
            {
                if (Convert.ToDouble(txtValor.Text) > 0)
                {


                    if (MessageBox.Show(" Deseja realmente conceder este desconto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        Importa_Funcao.Finalizar_Pedido(CodPedidoVenda);

                        // instânciar pedidos vendas
                        C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                        pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
                        dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(CodPedidoVenda);

                        if (dtPedidoVenda.Rows[0]["concluido"].ToString() == "1")
                        {
                            //salvar desconto
                            C2W.c2wDataSet.descontosDataTable dtDesconto = new c2wDataSet.descontosDataTable();
                            descontosTableAdapter taDesconto = new descontosTableAdapter();
                            taDesconto.Insert(DateTime.Now, CodPedidoVenda, Convert.ToDouble(txtValor.Text), Convert.ToDouble(txtPercentual.Text));
                            MessageBox.Show(" Desconto concedido...", "Aviso do sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(" Desconto cancelado...", "Aviso do sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                       
                    }
                }
            }
        }

    }
}
