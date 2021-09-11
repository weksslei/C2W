using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C2W.c2wDataSetTableAdapters;

namespace C2W
{
    public partial class Compras : C2W.Frm_Base
    {
        // situações possíveis:
        //  0  ,  0  ,x>0  significa uma compra já realizada onde "editar" e excluir somente se campo recebido == 0
        // exibir fornecedor, pedido, items comprados


        //  0  , x>0 , 0   significa novo pedido de compra sem realizar cotacao 
        // exibir fornecedor e seu portifolio

        // x>0 ,  0  , 0   significa novo pedido através de uma cotação transformando-a em um pedido
        // exibir fornecedor e transformar itens cotados em items de compra

        public string a, b, c;
        public string CodProduto, CodProdutoCotado;
        public double Somatoria, Editar_SubTotal;
        public double NovoValor, x_Quant, x_Custo;
        public double Total, SubTotal, Editar_btnTotal, ValorAnterior;
        public int i = 0;

        public int Teste = 1;

        public enum Tarefa
        {
            NovoItem, VelhoItem
        }

        public Tarefa Operacao;
                
        public int Cotacao, Fornecedor, Compra;
        
        public Compras(string CodCotacao,string CodFornecedor, string CodCompra) 
        {
            InitializeComponent();
            //MessageBox.Show(" Fornecedor: " + CodFornecedor);
            //MessageBox.Show(" Compra: " + CodCompra);
            Cotacao = int.Parse(CodCotacao);
            Fornecedor = int.Parse(CodFornecedor);
            Compra = int.Parse(CodCompra);
            //MessageBox.Show(" Cotacao: " + Cotacao);

        }

        public override void tsbNovo_Click(object sender, EventArgs e)
        {
            if (Compra == 0)
            {
                listaProdutosComprados.Items.Clear();
                Total = 0;
                btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            }
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            //   Cotacao, Fornecedor, Compra
            // instanciar pedido de compra
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            // instanciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();

            if (Compra > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);
                // se compra > 0 pegar o id do fornececedor
                Fornecedor = int.Parse(dtPedidoCompra.Rows[0]["idfornecedor"].ToString());
                txtObservacao.Text = dtPedidoCompra.Rows[0]["observacao"].ToString();
                //carregar itens comprados
                // instânciar itens comprados
                C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

                dtItensComprados = taItensComprados.ItensComprados(Compra);
                Carrega_Itens_Comprados(dtItensComprados);

                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());


            }
            if(Cotacao > 0)
            {
                // se cotacao > 0 pegar o id do fornececedor
                dtCotacao = taCotacao.PesquisaCotacaoID(Cotacao);
                Fornecedor = int.Parse(dtCotacao.Rows[0]["idFornecedor"].ToString());

                // carregar itens cotados em lista de compras e avisar ao usuário
                // instânciar itens cotados
                C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
                dtItensCotados = taItensCotados.ItensCotados(Cotacao);
                Carrega_Itens_Cotados(dtItensCotados);

                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());
                Total = Somatoria; //faze de teste
                //listaProdutosComprados.Enabled = false;
                //ListaProdutos.Enabled = false;
                MessageBox.Show(" ATENÇÃO!!! Cotação realizada em " + dtCotacao.Rows[0]["data"] + " . Confirme as informações antes de salvar o Pedido...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }





            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.PesquisaFornecedorId(Fornecedor);

            txtEmpresa.Text = dt.Rows[0]["nome_Empresa"].ToString();
            txtRepresentante.Text = dt.Rows[0]["nome_vendedor"].ToString();
            txtFone1.Text = dt.Rows[0]["fone1"].ToString();
            txtFone2.Text = dt.Rows[0]["fone2"].ToString();
            txtEmpresa.Enabled = false;
            txtRepresentante.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;
            txtValor.Enabled = false;
            txtQuantidade.Enabled = false;

            btnIncluir.Enabled = false;
            btnRemover.Enabled = false;
            btnAlterar.Enabled = false;

            ListaProdutos.Enabled = true;
            listaProdutosComprados.Enabled = true;


            C2W.c2wDataSet.portifolioDataTable dtp = new c2wDataSet.portifolioDataTable();
            portifolioTableAdapter tap = new portifolioTableAdapter();
            dtp = tap.PortifolioProdutos(Fornecedor);  //todos os produtos de um fornecedor

            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dtp.Rows)  // rodar produto por produto chave estrangeira
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[1].ToString().PadLeft(5, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString())); //pesquisa o produto
                if (dtProduto.Rows.Count > 0)
                {
                    item.SubItems.Add(dtProduto.Rows[0]["Nome"].ToString());
                }
                ListaProdutos.Items.Add(item);
            }
            if (Compra == 0 && Cotacao == 0)
            {
                MessageBox.Show(" Passo 1 - Selecione um produto no portifólio para efetuar o Pedido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ListaProdutos.Focus();
            }
            if (Compra > 0)
            {
                listaProdutosComprados.Enabled = false;
                ListaProdutos.Enabled = false;

            }


        }

        public void Carrega_Itens_Cotados(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            listaProdutosComprados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dr[1].ToString().PadLeft(5, '0');
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                double Quant = Convert.ToDouble(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:f}", dr[2])).ToString());
                double Custo = Convert.ToDouble(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                Editar_SubTotal = Quant * Custo;
                listaProdutosComprados.Items.Add(item);
                Somatoria = Somatoria + Editar_SubTotal;
            }

        }

        public void Carrega_Itens_Comprados(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            listaProdutosComprados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dr[1].ToString().PadLeft(5, '0');
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                double Quant = Convert.ToDouble(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:f}", dr[2])).ToString());
                double Custo = Convert.ToDouble(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                Editar_SubTotal = Quant * Custo;
                listaProdutosComprados.Items.Add(item);
                Somatoria = Somatoria + Editar_SubTotal;
            }

        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAlterar.Enabled = false;
                btnRemover.Enabled = false;
                CodProduto = ListaProdutos.SelectedItems[0].Text;
                if (int.Parse(CodProduto) > 0)
                {
                    Operacao = Tarefa.NovoItem;

                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));

                    lblNomeProduto.Text = dtProduto.Rows[0]["Nome"].ToString();

                    ListaProdutos.Enabled = false;
                }
            }
            catch
            {

            }
            txtQuantidade.Enabled = true;
            txtQuantidade.Focus();
        }

 
        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            ListaProdutos.Enabled = true;
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuantidade.Text == "" || Convert.ToDouble(txtQuantidade.Text) < 1)
                {
                    MessageBox.Show(" Quantidade informada inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                }
                else
                {

                    txtValor.Enabled = true;
                    txtValor.Focus();
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //restringe_teclas(e);
            FormatarQuantidade(sender, e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Status == StatusCadastro.scEditando && Teste == 1)
            {
                txtValor.Text = "";
                Teste = 0;
            }
            //funcao
            FormatarMoeda(sender, e);
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            //  btnIncluir.Enabled = true;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtValor.Text == "" || txtValor.Text == "," || Convert.ToDouble(txtValor.Text) < 0.1)
                {
                    MessageBox.Show(" Valor informado inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor.Focus();
                }
                else
                {
                    if ( (Compra == 0 && Operacao == Tarefa.NovoItem) && Cotacao==0)
                    {
                        btnIncluir.Enabled = true;
                        btnIncluir.Focus();
                    }
                    else
                    {
                        if ((Compra == 0 && Operacao == Tarefa.NovoItem) && Cotacao > 0)
                        {
                            btnIncluir.Enabled = true;
                            btnIncluir.Focus();
                        }

                        if ((Compra == 0 && Operacao == Tarefa.VelhoItem) ) //&& Cotacao > 0)
                        {
                            if (MessageBox.Show(" Confirma Alteração deste Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //

                                for (i = 0; i < listaProdutosComprados.Items.Count; i++)
                                {
                                    if ((listaProdutosComprados.Items[i].Text == CodProdutoCotado))
                                    {
                                        x_Quant = Convert.ToDouble(a);
                                        x_Custo = Convert.ToDouble(c);
                                        SubTotal = x_Quant * x_Custo;
                                        listaProdutosComprados.Items.RemoveAt(i);
                                        btnRemover.Enabled = false;
                                        break;
                                    }
                                }
                                Total = Total - SubTotal;
                                btnTotal.Text = (String.Format("{0:C}", Total).ToString());


                                ListViewItem item = new ListViewItem();
                                item.Text = CodProdutoCotado;
                                item.SubItems.Add(lblNomeProduto.Text);
                                double Quant = Convert.ToDouble(txtQuantidade.Text);
                                item.SubItems.Add(String.Format("{0:f3}", Quant).ToString());
                                double Moeda = Convert.ToDouble(txtValor.Text);
                                item.SubItems.Add(String.Format("{0:C}", Moeda).ToString());
                                listaProdutosComprados.Items.Add(item);
                                SubTotal = Quant * Moeda;
                                Total = Total + SubTotal;

                                btnTotal.Text = (String.Format("{0:C}", Total).ToString());

                                lblNomeProduto.Text = "";
                                txtQuantidade.Text = "";
                                txtValor.Text = "";
                                btnAlterar.Enabled = false;
                                listaProdutosComprados.Focus();

                            }
                        }
                        if (Compra > 0 && Operacao == Tarefa.VelhoItem)
                        {
                            if (MessageBox.Show(" Confirma Alteração deste Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //alterar o item

                                C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                                pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                                dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);
                                
                                Double Alt_Total = Convert.ToDouble(dtPedidoCompra.Rows[0]["total"].ToString());

                                //MessageBox.Show("total => " + Alt_Total); //ok
                                //MessageBox.Show("Conta => " + Alt_Total + "  -  " + ValorAnterior);

                                Alt_Total = Alt_Total - ValorAnterior;

                                //MessageBox.Show("Resultado => " + Alt_Total);

                                NovoValor = Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text);
                                //MessageBox.Show("Conta => " + Alt_Total + "  + Novo Valor=>  " + NovoValor);

                                Alt_Total = Alt_Total + Convert.ToDouble(NovoValor);

                                //MessageBox.Show("Resultado => " + Alt_Total);


                                //criar query                                
                                taPedidoCompra.Alterar_TotalDe_UmaCompra(Convert.ToDecimal(Alt_Total), txtObservacao.Text,Compra);

                                // instânciar itens cotados
                                C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                                itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

                                //criar query
                                taItensComprados.AlterarItensComprados(Convert.ToDecimal(txtQuantidade.Text),
                                    Convert.ToDecimal(txtValor.Text), Compra , int.Parse(CodProdutoCotado));

                                MessageBox.Show(" Pedido Alterado com Sucesso...", "Operação Realizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                dtItensComprados = taItensComprados.ItensComprados(Compra);
                                Carrega_Itens_Comprados(dtItensComprados);

                                btnTotal.Text = (String.Format("{0:C}", Alt_Total).ToString());


                                listaProdutosComprados.Focus();
                            }
                            else
                            {
                                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            lblNomeProduto.Text = "";
                            txtQuantidade.Text = "";
                            txtValor.Text = "";
                            txtQuantidade.Enabled = false;
                            txtValor.Enabled = false;

                            btnAlterar.Enabled = false;

                        }
                    }
                    if (Compra > 0 && Operacao == Tarefa.NovoItem)
                    {
                        if (MessageBox.Show(" Este Pedido já estava fechado! Confirma Inclusão deste Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //incluir novo item de compra
                            btnIncluir.Enabled = true;
                            btnIncluir.Focus();
                        }
                    }
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            int x = listaProdutosComprados.Items.Count;
            int n = 0, g;



            if (Compra == 0)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaProdutosComprados.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Este produto já existe na lista de Compras...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        n = 0; //nao achou
                    }
                }
                if (n == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = CodProduto;
                    item.SubItems.Add(lblNomeProduto.Text);
                    double Quant = Convert.ToDouble(txtQuantidade.Text);
                    item.SubItems.Add(String.Format("{0:f3}", Quant).ToString());
                    double Moeda = Convert.ToDouble(txtValor.Text);
                    item.SubItems.Add(String.Format("{0:C}", Moeda).ToString());
                    listaProdutosComprados.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;
                }
            }

            if (Compra > 0)
            {
                for (g = 0; g < x; g++)
                {
                    //MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaProdutosComprados.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Produto já solicitado na lista de compras...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        n = 0; //nao achou
                    }
                }
                C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);
                Editar_btnTotal = Convert.ToDouble(dtPedidoCompra.Rows[0]["total"].ToString());
                Total = Editar_btnTotal;

                if (n == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = CodProduto;
                    item.SubItems.Add(lblNomeProduto.Text);
                    double Quant = Convert.ToDouble(txtQuantidade.Text);
                    item.SubItems.Add(String.Format("{0:f3}", Quant).ToString());
                    double Moeda = Convert.ToDouble(txtValor.Text);
                    item.SubItems.Add(String.Format("{0:C}", Moeda).ToString());
                    listaProdutosComprados.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;

                    C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                    itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

                    taItensComprados.Insert(Compra, int.Parse(CodProduto), Quant, Moeda);

                    taPedidoCompra.Alterar_TotalDe_UmaCompra(Convert.ToDecimal(Total), txtObservacao.Text, Compra);
                }

            }


            btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            lblNomeProduto.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
            txtValor.Enabled = false;
            txtQuantidade.Enabled = false;
            btnIncluir.Enabled = false;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarItem();
        }

        private void listaProdutosComprados_DoubleClick(object sender, EventArgs e)
        {
            AlterarItem();
        }

        private void listaProdutosComprados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProdutoCotado = listaProdutosComprados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoCotado) > 0)
                {
                    btnRemover.Enabled = true;
                    btnAlterar.Enabled = true;
                    //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    a = (listaProdutosComprados.SelectedItems[0].SubItems[2].Text); // quantidade
                    b = (listaProdutosComprados.SelectedItems[0].SubItems[3].Text);  //custo
                    c = b.Replace("R$ ", "0");  //custo sem R$
                    //MessageBox.Show(" Produto => " + CodProdutoCotado + "  quant = " + a + " custo = " + c);
                }
            }
            catch
            {

            }
        }

        public void AlterarItem()
        {
            try
            {
                CodProdutoCotado = listaProdutosComprados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoCotado) > 0)
                {
                    Operacao = Tarefa.VelhoItem;

                    txtQuantidade.Enabled = true;
                    txtValor.Enabled = true;
                    btnRemover.Enabled = false;

                    lblNomeProduto.Text = (listaProdutosComprados.SelectedItems[0].SubItems[1].Text); //nome produto
                    a = (listaProdutosComprados.SelectedItems[0].SubItems[2].Text); // quantidade
                    b = (listaProdutosComprados.SelectedItems[0].SubItems[3].Text);  //custo
                    c = b.Replace("R$ ", "");  //custo sem R$
                    a = a.Replace(",000", "");
                    //a = a.TrimEnd();

                    //txtQuantidade.Text = a;

                   // txtValor.Text = c;


                    //MessageBox.Show(" Produto => " + CodProdutoCotado + "  quant = " + a + " custo = " + c);

                    txtQuantidade.Focus();
                    ValorAnterior = (Convert.ToDouble(c) * Convert.ToDouble(a));
                    //MessageBox.Show(" Descontar => " + ValorAnterior);
                }
            }
            catch
            {

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;
            if (Compra == 0 )
            {
                //double x_Quant, x_Custo;

                if (MessageBox.Show(" Deseja realmente excluir este Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    for (i = 0; i < listaProdutosComprados.Items.Count; i++)
                    {
                        if ((listaProdutosComprados.Items[i].Text == CodProdutoCotado))
                        {
                            x_Quant = Convert.ToDouble(a);
                            x_Custo = Convert.ToDouble(c);
                            SubTotal = x_Quant * x_Custo;
                            listaProdutosComprados.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }
                    Total = Total - SubTotal;
                    btnTotal.Text = (String.Format("{0:C}", Total).ToString());
                }
            }
            if (Compra > 0)
            {
                // trabalhar para excluir itens comprados
                // idcotacao = tipoexecucao    idproduto = codprodutocotado
                if (MessageBox.Show(" Deseja realmente excluir este Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // instânciar itens comprados
                    C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                    itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();
                    dtItensComprados = taItensComprados.Pesquisa_Excluir(Compra, int.Parse(CodProdutoCotado));

                    taItensComprados.ExcluirItensDaCompra(Compra, int.Parse(CodProdutoCotado));

                    double Exc_Quant = Convert.ToDouble(dtItensComprados.Rows[0]["quantidade"].ToString());
                    double Exc_Custo = Convert.ToDouble(dtItensComprados.Rows[0]["valor_custo"].ToString());
                    double Exc_SubTotal = Exc_Quant * Exc_Custo;
                    taItensComprados.ExcluirItensDaCompra(Compra, int.Parse(CodProdutoCotado));

                    for (i = 0; i < listaProdutosComprados.Items.Count; i++)
                    {
                        if ((listaProdutosComprados.Items[i].Text == CodProdutoCotado))
                        {
                            listaProdutosComprados.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }

                    C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                    pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                    dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);


                    double Exc_Total = Convert.ToDouble(dtPedidoCompra.Rows[0]["total"].ToString());
                    Exc_Total = Exc_Total - Exc_SubTotal;
                    taPedidoCompra.Alterar_TotalDe_UmaCompra(Convert.ToDecimal(Exc_Total), txtObservacao.Text, Compra);

                    btnTotal.Text = (String.Format("{0:C}", Exc_Total).ToString());
                    //MessageBox.Show("Novo total: " + Exc_Total);
                    if (Exc_Total == 0)
                    {
                        //Exccluir compra
                        taPedidoCompra.ExcluirPedidoCompra(Compra);

                        Close();
                    }

                }
            }
        }

        public override bool Salvar()
        {
            bool bSalvar = false;
            if (listaProdutosComprados.Items.Count < 1)
            {
                MessageBox.Show(" Não existem produtos solicitados para gravar este pedido de compra...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bSalvar;
            }



            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            // instânciar itens comprados
            C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
            itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

            if (Status == StatusCadastro.scInserindo || Compra == 0)
            {
                if (MessageBox.Show(" Deseja realmente salvar este Pedido de Compra ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return bSalvar;
                }

                //MessageBox.Show(" Cotacao: " + Cotacao);
                bSalvar = (taPedidoCompra.Insert(Fornecedor, Cotacao, DateTime.Today, Total, txtObservacao.Text, 0) > 0);

                if (bSalvar)
                {
                    //pegar o ultimo id inserido acima na tabela cotacoes
                    string iCompra = "", iProduto, iQuantidade, iCusto;
                    int f, cont;
                    dtPedidoCompra = taPedidoCompra.ListarTodasCompras();
                    cont = dtPedidoCompra.Rows.Count;
                    if (cont > 0)
                    {
                        for (f = 0; f < cont; f++)
                        {
                            iCompra = dtPedidoCompra.Rows[f]["Id"].ToString();  //rotina que pega a última compra realizada
                        }
                    }

                    //MessageBox.Show(" Ultimo => " + iCompra);

                    for (i = 0; i < listaProdutosComprados.Items.Count; i++)   // salvando itens cotados
                    {
                        //idcotacao , idproduto , quantidade , valor_Custo

                        iProduto = (listaProdutosComprados.Items[i].SubItems[0].Text);
                        iProduto = iProduto.TrimStart('0');

                        iQuantidade = (listaProdutosComprados.Items[i].SubItems[2].Text);

                        if (iQuantidade.Contains(",000"))
                        {
                            iQuantidade = iQuantidade.Replace(",000", "");
                        }
                        else
                        {
                            iQuantidade = iQuantidade.Replace(",00", "");
                        }
                        //QuantidadeInt = Convert.ToInt32(iQuantidade);

                        iCusto = (listaProdutosComprados.Items[i].SubItems[3].Text);
                        iCusto = iCusto.Replace("R$ ", "0");
                       // MessageBox.Show(iCompra + "   " + iProduto + "   " + iQuantidade + "    " + iCusto);

                        taItensComprados.Insert(int.Parse(iCompra), int.Parse(iProduto), Convert.ToDouble(iQuantidade), Convert.ToDouble(iCusto));
                    }

                  //  MessageBox.Show(" Cotacao: " + Cotacao + "  Fornecedor: " + Fornecedor + "   Compra: " + Compra);

                    if (Cotacao > 0 && Compra == 0)
                    {
                        C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                        cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                        //dtCotacao = taCotacao.PesquisaCotacaoID(Cotacao);
                        taCotacao.ConverteCotacao_PedidoCompra(Cotacao);
                    }
                }


            }
            if (Status == StatusCadastro.scEditando)
            {
                // as alterações dos itens comprados já foram realizados anteriormente
                taPedidoCompra.AlterarObservacao(txtObservacao.Text,Compra);
                bSalvar = true;
            }
            Close();
            return bSalvar;
        }

        public override bool Localizar() //editar
        {
            bool bLocalizar = false;
            // pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
            if (Compra > 0)
            {
                dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);
                byte Verifica = Convert.ToByte(dtPedidoCompra.Rows[0]["recebido"].ToString());
                if (Verifica == 0)  // significa que o pedido ainda não foi entregue pelo fornecedor
                {
                    listaProdutosComprados.Enabled = true;
                    ListaProdutos.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" Este pedido já deu entrada no estoque... Alteração não permitida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            Status = StatusCadastro.scEditando;


            return bLocalizar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // se um pedido de compra tiver dado entrada no estoque, o mesmo não poderá ser excluído
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.PesquisaId(Compra);

            if (int.Parse(dtPedidoCompra.Rows[0]["recebido"].ToString()) == 1)
            {
                MessageBox.Show(" Este Pedido de Compra não poderá ser excluído! Houve entrada de Estoque...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bExcluir;

            }

            C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
            itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

            string iProduto;

            for (i = 0; i < listaProdutosComprados.Items.Count; i++)   // salvando itens cotados
            {
                iProduto = (listaProdutosComprados.Items[i].SubItems[0].Text);
                iProduto = iProduto.TrimStart('0');

                taItensComprados.ExcluirItensDaCompra(Compra, int.Parse(iProduto));
            }



            bExcluir = (taPedidoCompra.ExcluirPedidoCompra(Compra) > 0);


            LimparControles();
            Close();
            return bExcluir;
        }

    }
}
