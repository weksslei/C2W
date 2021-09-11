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
    public partial class PesquisarPedidoCompras : Form
    {
        public PesquisarPedidoCompras()
        {
            InitializeComponent();
        }

        public Frm_Base Funcao = new Frm_Base();

        public string DataI, DataF;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarPedidoCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void PesquisarPedidoCompras_Load(object sender, EventArgs e)
        {
            btnReceberPedido.Enabled = false;
            btnPesquisar.Enabled = false;
            mtbDataFinal.Enabled = false;
            mtbDataInicial.Enabled = false;
            btnOK.Enabled = false;
            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.Compras_A_Receber();
            
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
                }
                item.SubItems.Add(Teste);
                ListaCompras.Items.Add(item);
            }
        }

        private void rbComprasReceber_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            mtbDataFinal.Enabled = false;
            mtbDataInicial.Enabled = false;
            mtbDataFinal.Text = "";
            mtbDataInicial.Text = "";
            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.Compras_A_Receber();

            Carrega_Compras(dtPedidoCompra);
        }

        private void rbPeriodo_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnReceberPedido.Enabled = false;
            btnPesquisar.Enabled = true;
            mtbDataFinal.Enabled = true;
            mtbDataInicial.Enabled = true;
            ListaCompras.Items.Clear();
            listaProdutosComprados.Items.Clear();
            mtbDataInicial.Focus();
        }

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
                        //btnPesquisar.Enabled = true;
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

        private void mtbDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void mtbDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            mtbDataInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // devolve a formatação
            mtbDataFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            DataI = mtbDataInicial.Text;
            DataF = mtbDataFinal.Text;
            if (!Funcao.ValidarData(DataI) || !Funcao.ValidarData(DataF))     // chama a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbDataInicial.Focus();
            }
            else
            {
                ListaCompras.Items.Clear();
                // Pesquisa será por período onde será informada data inicial e final...
                // instânciar pedidos de compras
                C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

                string DtInicial, DtFinal;
                mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação


                DtInicial = mtbDataInicial.Text;
                DtFinal = mtbDataFinal.Text;

                // MessageBox.Show(DtInicial + "   " + DtFinal);

                dtPedidoCompra = taPedidoCompra.ComprasDeUmPeriodo(Convert.ToDateTime(DtInicial), Convert.ToDateTime(DtFinal));

                if (dtPedidoCompra.Rows.Count > 0)
                {
                    Carrega_Compras(dtPedidoCompra);
                }
                else
                {
                    MessageBox.Show(" Não existem informações a apresentar para este período...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public string CodigoCompra, CodigoFornecedor;
        public byte Recebido;

        private void ListaCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoCompra = ListaCompras.SelectedItems[0].Text;

                // instânciar pedidos de compras
                C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                dtPedidoCompra = taPedidoCompra.PesquisaId(int.Parse(CodigoCompra));

                Recebido =Convert.ToByte(dtPedidoCompra.Rows[0]["Recebido"].ToString());
              //  MessageBox.Show(" => " + Recebido);

                if(Recebido == 0)
                {
                    btnReceberPedido.Enabled = true;
                }
                else
                {
                    btnReceberPedido.Enabled = false;
                }

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

        private void ListaCompras_DoubleClick(object sender, EventArgs e)
        {
            //mandar para editar
            try
            {
                CodigoCompra = ListaCompras.SelectedItems[0].Text;
                ExibeCompra();
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //mandar para editar
            ExibeCompra();
            PesquisarPedidoCompras Ppc = new PesquisarPedidoCompras();
            Ppc.ShowDialog();
        }

        public void ExibeCompra()
        {
            if (int.Parse(CodigoCompra) > 0)
            {
                // instânciar pedidos de compras
                C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

                dtPedidoCompra = taPedidoCompra.PesquisaId(int.Parse(CodigoCompra));
                CodigoFornecedor = dtPedidoCompra.Rows[0]["IdFornecedor"].ToString();
                //pegar fornecedor

                Compras Editar = new Compras("0",CodigoFornecedor, CodigoCompra);
                Editar.ShowDialog();

             
                dtPedidoCompra = taPedidoCompra.Compras_A_Receber();
                Carrega_Compras(dtPedidoCompra);
           
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ConstruirPedidoCompra Cpc = new ConstruirPedidoCompra();
            Cpc.ShowDialog();
            PesquisarPedidoCompras Ppc = new PesquisarPedidoCompras();
            Ppc.ShowDialog();
        }
 
        private void btnReceberPedido_Click(object sender, EventArgs e)
        {
            // confirmar recebimento de mercadorias e realizar o incremento no estoque
            if (MessageBox.Show(" Confirma recebimento de Pedido Selecionado ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // abrir formulário de recebimento
                ReceberProdutos Rp = new ReceberProdutos(int.Parse(CodigoCompra));
                Rp.ShowDialog();
            }
            PesquisarPedidoCompras Ppc = new PesquisarPedidoCompras();
            Ppc.ShowDialog();
        }



    }
}
