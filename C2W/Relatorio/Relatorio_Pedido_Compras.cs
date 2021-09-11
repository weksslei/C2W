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
    public partial class Relatorio_Pedido_Compras : Form
    {
        public Relatorio_Pedido_Compras()
        {
            InitializeComponent();
        }

        private void Relatorio_Pedido_Compras_Load(object sender, EventArgs e)
        {
            listaProdutosComprados.Items.Clear();
            DateTime dt1, dt2;
            dt2 = DateTime.Now;
            dt1 = dt2.AddDays(-180);

            //MessageBox.Show(" d1 " + dt1 + "  //  d2 " + dt2);
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.Pesquisa_Compras06_meses(dt1,dt2);

            C2W.c2wDataSet.itens_compradosDataTable dtItens_Comprados = new c2wDataSet.itens_compradosDataTable();
            itens_compradosTableAdapter taItens_Comprados = new itens_compradosTableAdapter();
            //MessageBox.Show("  Pedidos: " + dtPedidoCompra.Rows.Count);
            for (int i=1; i < dtPedidoCompra.Rows.Count; i++)
            {

                dtItens_Comprados = taItens_Comprados.ItensComprados(int.Parse(dtPedidoCompra.Rows[i]["Id"].ToString()));
                Carrega_Itens_Comprados(dtItens_Comprados);
            }
            listaProdutosComprados.Enabled = true;
        }

        public void Carrega_Itens_Comprados(DataTable dt)
        {
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            //            dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));

            //listaProdutosComprados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                item.Text = dr[1].ToString().PadLeft(5, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.SubItems.Add( dtProduto.Rows[0]["nome"].ToString());
                //(String.Format("{0:f}", dr[3])).ToString()

                item.SubItems.Add((String.Format("{0:f3}", dr[2])).ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda

                dtPedidoCompra = taPedidoCompra.PesquisaId(int.Parse(dr[0].ToString()));
                item.SubItems.Add(string.Format("{0:d}", dtPedidoCompra.Rows[0]["data"]).ToString());

                listaProdutosComprados.Items.Add(item);
            }
        }

        private void Relatorio_Pedido_Compras_KeyDown(object sender, KeyEventArgs e)
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

    }
}
