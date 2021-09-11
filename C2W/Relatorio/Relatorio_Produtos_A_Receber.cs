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
    public partial class Relatorio_Produtos_A_Receber : Form
    {
        public Relatorio_Produtos_A_Receber()
        {
            InitializeComponent();
        }

        private void Relatorio_Produtos_A_Receber_Load(object sender, EventArgs e)
        {
            Anos.Enabled = false;
            btnEmitir.Enabled = false;
            Meses.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Relatorio_Produtos_A_Receber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
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

            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.ComprasDeUmPeriodo(Data1, Data2);
            //Compras_De_Um_Mes

            if (dtPedidoCompra.Rows.Count < 1)
            {
                ListaCompras.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Carrega_Compras(dtPedidoCompra);

        }

        public void Carrega_Compras(DataTable dt)
        {
            string Teste;
            //Fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            //dt = ta.PesquisaFornecedorId(CodFornecedor);

            ListaCompras.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');

                dtEmpresa = taEmpresa.PesquisaFornecedorId(int.Parse(dr[1].ToString()));
                item.SubItems.Add(dtEmpresa.Rows[0]["nome_empresa"].ToString()); //idforncedor
                                                                                 //   item.SubItems.Add(dr[1].ToString()); //idforncedor
                item.SubItems.Add(String.Format("{0:d}", dr[3]).ToString()); //data sem hora
                item.SubItems.Add((String.Format("{0:C}", dr[4]).ToString)());   // preço formato moeda

                if (int.Parse(dr[6].ToString()) == 1)
                {
                    Teste = "Sim";
                }
                else
                {
                    Teste = "Não";
                    item.BackColor = Color.Peru;
                }
                item.SubItems.Add(Teste);
                ListaCompras.Items.Add(item);
            }
        }

        private void ListaCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string CodigoCompra = ListaCompras.SelectedItems[0].Text;

                //carregar itens comprados
                // instânciar itens comprados
                C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

                dtItensComprados = taItensComprados.ItensComprados(int.Parse(CodigoCompra));
                Carrega_Itens_Comprados(dtItensComprados);
            }
            catch
            {

            }
        }

        public void Carrega_Itens_Comprados(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            //            dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));

            listaProdutosComprados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                //item.Text = dr[1].ToString().PadLeft(5, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dtProduto.Rows[0]["nome"].ToString();
                //(String.Format("{0:f}", dr[3])).ToString()

                item.SubItems.Add((String.Format("{0:f3}", dr[2])).ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda

                listaProdutosComprados.Items.Add(item);
            }
        }



    }
}
