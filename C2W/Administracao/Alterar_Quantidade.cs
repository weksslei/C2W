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
    public partial class Alterar_Quantidade : Form
    {
        public int Codigo_Produto, Cod_Pedido_Venda;
        public ListView L_Vendas;
        public double Total, Preco;
        public string Quant;

        public Alterar_Quantidade(int Cod_Pedido,int CodProduto,ListView Lista, double Valor, string iQuant) //,string iTotal
        {
            InitializeComponent();
            Cod_Pedido_Venda = Cod_Pedido;
            Codigo_Produto = CodProduto;
            L_Vendas = Lista;
            Preco = Valor;
            Quant = iQuant;
        }
       
        private void Alterar_Quantidade_Load(object sender, EventArgs e)
        {
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.PesquisaProdutoId(Codigo_Produto);

            lblNomeProduto.Text = dtProduto.Rows[0]["nome"].ToString();

            C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
            unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();
            dtUM = taUM.PesquisaUnidadeId(int.Parse(dtProduto.Rows[0]["IdUM"].ToString()));

            if(dtUM.Rows[0]["Nome"].ToString()=="UNIDADE")
            {
                Quant = Quant.Replace(",000", "");
            }

            lbl_Quantidade.Text = Quant + "  " + dtUM.Rows[0]["Nome"].ToString() + " (s)";
            txtQuantidade.Focus();

           // MessageBox.Show("" + Codigo_Produto + "     => " + Preco);
        }

        private void Alterar_Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

     
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == "" || txtQuantidade.Text == "," || Convert.ToDouble(txtQuantidade.Text) < 1)
            {
                MessageBox.Show(" Quantidade informada inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
            }
            else
            {
                // instânciar pedidos vendas
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Cod_Pedido_Venda);
                Total = Convert.ToDouble(dtPedidoVenda.Rows[0]["total"].ToString());

                C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();

                double x_Quant, SubTotal = 0;

                if (Convert.ToDouble(txtQuantidade.Text) > 0)
                {
                    for (int i = 0; i < L_Vendas.Items.Count; i++)
                    {
                        if (int.Parse(L_Vendas.Items[i].Text) == Codigo_Produto)
                        {
                            x_Quant = Convert.ToDouble(L_Vendas.Items[i].SubItems[2].Text);
                            SubTotal = x_Quant * Preco;
                            L_Vendas.Items.RemoveAt(i);
                            break;
                        }
                    }
                    Total = Total - SubTotal;
                    //produtos
                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(Codigo_Produto);
                    ListViewItem item = new ListViewItem();
                    item.Text = (Codigo_Produto).ToString().PadLeft(5, '0');
                    item.SubItems.Add(lblNomeProduto.Text);
                    double Quant = Convert.ToDouble(txtQuantidade.Text);
                    item.SubItems.Add((String.Format("{0:f3}", txtQuantidade.Text)).ToString());
                    item.SubItems.Add((String.Format("{0:C}", Preco).ToString)());   // preço formato moeda
                    L_Vendas.Items.Add(item);
                    Total = Total + (Quant * Preco);

                    taPedidoVenda.Alterar_Total_PedidoVenda(Convert.ToDecimal(Total), Cod_Pedido_Venda);
                    taItensVendidos.Alterar_Quantidade_Iten(Convert.ToDecimal(txtQuantidade.Text), Cod_Pedido_Venda, Codigo_Produto);
                    Close();
                }

            }
        }

        Frm_Base Funcao = new Frm_Base();

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuantidade.Text == "" || Convert.ToDouble(txtQuantidade.Text) < 1)
                {
                    MessageBox.Show(" Quantidade informada inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                }
                else
                {
                    btnConfirmar.Focus();
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarQuantidade(sender, e);
        }
    }
}
