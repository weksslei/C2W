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
    public partial class Vendas : C2W.Frm_Base
    {
        public int Codigo_PedidoVenda, Codigo_Orcamento;

        public Vendas(int Cod_Pedido_V, int Cod_Orcamento)  // -1,0 permite escolher cliente .....status inserindo
        {                                                   //  >0 , 0 exibir pedido  ............status editando
            InitializeComponent();                          // 0, >0 exibir orçamento  ...........status inserindo
            Codigo_PedidoVenda = Cod_Pedido_V;
            Codigo_Orcamento = Cod_Orcamento;
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            // buscar clientes
            C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taClientes = new clientesTableAdapter();
            txtFiltrarProduto.Enabled = false;
            btnRemover.Enabled = false;
            btnIncluir.Enabled = false;
            txtQuantidade.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;
            txtPesquisar.Enabled = false;
            cbClientes.Enabled = false;
            if (Codigo_PedidoVenda < 1 && Codigo_Orcamento < 1)
            {
                txtPesquisar.Enabled = true;
                txtPesquisar.Focus();
            }

            if (Codigo_PedidoVenda > 0 && Codigo_Orcamento < 1)
            {
                // instânciar pedidos vendas
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Codigo_PedidoVenda);
                dtClientes = taClientes.PesquisaClienteId(int.Parse(dtPedidoVenda.Rows[0]["idCliente"].ToString()));
                Carrega_Clientes(dtClientes);

                
                txtObservacao.Text = dtPedidoVenda.Rows[0]["observacao"].ToString();
                byte T_Entrega = Convert.ToByte(dtPedidoVenda.Rows[0]["entregar"].ToString());
                if(T_Entrega==1)
                {
                    rbSim.Checked = true;
                    rbNao.Checked = false;
                }
                else
                {
                    rbNao.Checked = true;
                    rbSim.Checked = false;
                }

                byte T_Finaliza = Convert.ToByte(dtPedidoVenda.Rows[0]["concluido"].ToString());
                if(T_Finaliza==1)
                {
                    rbSIM_Finalizar.Checked = true;
                    rbNAO_Finalizar.Checked = false;
                }
                else
                {
                    rbSIM_Finalizar.Checked = false;
                    rbNAO_Finalizar.Checked = true;
                }
                // exibir o pedido de venda
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
                dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(Codigo_PedidoVenda);

                Carrega_Orcamento_OU_Pedido(dtItensVendidos);
                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());

                btnFiltrarProduto.Enabled = false;
                txtObservacao.Enabled = false;
                gbEntregar.Enabled = false;
                gbFinalizar.Enabled = false;
            }
            if (Codigo_PedidoVenda < 1 && Codigo_Orcamento > 0)
            {
                // exibir o orçamento
                C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
                itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();
                dtItensOrcados = taItensOrcados.Pesquisa_Itens_OrcamentoId(Codigo_Orcamento);
                Carrega_Orcamento_OU_Pedido(dtItensOrcados);

                // instânciar orçamentos
                C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
                orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
                dtOrcamento = taOrcamento.PesquisaOrcamentoId(Codigo_Orcamento);

                dtClientes = taClientes.PesquisaClienteId(int.Parse(dtOrcamento.Rows[0]["idCliente"].ToString()));
                Carrega_Clientes(dtClientes);
                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());
                Total = Somatoria;
            }


            ListaProdutos.Enabled = false;
            ListaVendas.Enabled = false;
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

        public void Carrega_Clientes(DataTable dtCliente)
        {
            CodigoCliente = int.Parse(dtCliente.Rows[0]["id"].ToString());
            txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
            txtCPF.Text = dtCliente.Rows[0]["cpf"].ToString();
            txtEmail.Text = dtCliente.Rows[0]["e_mail"].ToString();
            txtFone1.Text = dtCliente.Rows[0]["fone1"].ToString();
            txtFone2.Text = dtCliente.Rows[0]["fone2"].ToString();
        }

        private void txtFiltrarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFiltrarProduto.Focus();
            }
        }

        private void btnFiltrarProduto_Click(object sender, EventArgs e)
        {
            cbClientes.Enabled = false;
            ListaProdutos.Enabled = true;
            ListaVendas.Enabled = true;
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.PesquisaNome("%" + txtFiltrarProduto.Text + "%");
            Carrega_Produtos(dtProduto);
        }

        private void btnOfertas_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();
            dtOferta = taOferta.ListarOfertas(DateTime.Now);

            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            ListaProdutos.Items.Clear();

            foreach (DataRow dr in dtOferta.Rows)
            {
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                ListViewItem item = new ListViewItem();
                item.Text = dtProduto.Rows[0]["id"].ToString().PadLeft(5, '0');
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                item.BackColor = Color.Aquamarine;
                item.SubItems.Add(String.Format("{0:C}", dr[5]).ToString());   // preço formato moeda
                item.SubItems.Add((String.Format("{0:f3}", dtProduto.Rows[0]["volume_estocado"].ToString())));  //estoque com 3 casas decimais
                ListaProdutos.Items.Add(item);
            }
        }

        public string NomeCliente;
        public int CodigoCliente;

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NomeCliente = cbClientes.SelectedItem.ToString();

                CodigoCliente = int.Parse(NomeCliente.Substring(0, 5));
                // MessageBox.Show("=> " + CodigoCliente);

                //   filtrar clientes
                C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
                clientesTableAdapter taCliente = new clientesTableAdapter();
                dtCliente = taCliente.PesquisaClienteId(CodigoCliente);

                //            MessageBox.Show("=> " + dtCliente.Rows[0]["id"].ToString());

                Carrega_Clientes(dtCliente);
                txtFiltrarProduto.Enabled = true;
                txtFiltrarProduto.Focus();
            }
            catch
            {

            }
        }

        public void Carrega_Produtos(DataTable dtProduto)
        {
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();


            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dtProduto.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                dtOferta = taOferta.PesquisaProdutoID_OfertaValida(int.Parse(dr[0].ToString()), DateTime.Now);
                if (dtOferta.Rows.Count > 0)
                {
                    item.BackColor = Color.Aquamarine;
                    item.SubItems.Add(String.Format("{0:C}", dtOferta.Rows[0]["Valor_Oferta"]).ToString());   // preço formato moeda
                }
                else
                {
                    item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                }
                item.SubItems.Add((String.Format("{0:f3}", dr[4]).ToString)());  //estoque com 3 casas decimais
                ListaProdutos.Items.Add(item);
            }
        }
        
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            cbClientes.Enabled = true;
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            if (e.KeyCode == Keys.Enter)
            {
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

        public double Valor, Total, SubTotal;
        
        public string CodProduto;

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProduto = ListaProdutos.SelectedItems[0].Text;


                if (int.Parse(CodProduto) > 0)
                {
                    // Operacao = Tarefa.NovoItem;

                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));

                    lblNomeProduto.Text = dtProduto.Rows[0]["Nome"].ToString();

                    Valor = Convert.ToDouble(dtProduto.Rows[0]["valor_venda"].ToString());

                    //verificar existência de oferta
                    C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
                    ofertasTableAdapter taOferta = new ofertasTableAdapter();
                    dtOferta = taOferta.PesquisaProdutoID_OfertaValida(int.Parse(CodProduto), DateTime.Today);
                    if (dtOferta.Rows.Count > 0)
                    {
                        Valor = Convert.ToDouble(dtOferta.Rows[0]["valor_oferta"].ToString());
                    }
                    ListaProdutos.Enabled = false;
                }

                // MessageBox.Show(CodProduto + "  " + Valor);

            }
            catch
            {

            }
            txtQuantidade.Enabled = true;
            txtQuantidade.Focus();
        }
             
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatarQuantidade(sender, e);
        }

    
        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            ListaProdutos.Enabled = true;
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuantidade.Text == "" || Convert.ToDouble(txtQuantidade.Text) < 0.1)
                {
                    MessageBox.Show(" Quantidade informada inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                }
                else
                {
                    btnIncluir.Enabled = true;
                    btnIncluir.Focus();
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            int x = ListaVendas.Items.Count;
            int n = 0, g;
            if ( Codigo_PedidoVenda < 1 )
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((ListaVendas.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Produto já inserido na lista do Pedido do Cliente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    double Moeda = Convert.ToDouble(Valor);
                    item.SubItems.Add(String.Format("{0:C}", Moeda).ToString());
                    ListaVendas.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;
                }
            }

           

            if (Codigo_PedidoVenda > 0)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((ListaVendas.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Produto já inserido na Lista do Pedido do Cliente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        n = 0; //nao achou
                    }
                }
                // instânciar pedidos vendas
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Codigo_PedidoVenda);
                
                Total = Convert.ToDouble(dtPedidoVenda.Rows[0]["total"].ToString());
                if (n == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = CodProduto;
                    item.SubItems.Add(lblNomeProduto.Text);
                    double Quant = Convert.ToDouble(txtQuantidade.Text);
                    item.SubItems.Add(String.Format("{0:f3}", Quant).ToString());

                    item.SubItems.Add(String.Format("{0:C}", Valor).ToString());
                    ListaVendas.Items.Add(item);
                    SubTotal = Quant * Valor;
                    Total = Total + SubTotal;

                    C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                    itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
                    taItensVendidos.Insert(Codigo_PedidoVenda, int.Parse(CodProduto), Quant, Valor);
                    
                    taPedidoVenda.Alterar_Total_PedidoVenda(Convert.ToDecimal(Total), Codigo_PedidoVenda);
                }
            }


            btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            lblNomeProduto.Text = "";
            txtQuantidade.Text = "";
            Valor = 0;
            txtQuantidade.Enabled = false;
            btnIncluir.Enabled = false;
        }

        public byte Entregar;

        private void rbSim_CheckedChanged(object sender, EventArgs e)
        {
            Entregar = 1;
        }

        private void rbNao_CheckedChanged(object sender, EventArgs e)
        {
            Entregar = 0;
        }

        public string CodProdutoOrcado, iQuant, iValor;
        public byte Finalizar = 0;

        private void rbNAO_Finalizar_CheckedChanged(object sender, EventArgs e)
        {
            Finalizar = 0;
        }

        private void rbSIM_Finalizar_CheckedChanged(object sender, EventArgs e)
        {
            Finalizar = 1;
        }

        private void ListaVendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProdutoOrcado = ListaVendas.SelectedItems[0].Text;
                if (int.Parse(CodProdutoOrcado) > 0)
                {
                    btnRemover.Enabled = true;
                    //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    iQuant = (ListaVendas.SelectedItems[0].SubItems[2].Text); // quantidade
                    iValor = (ListaVendas.SelectedItems[0].SubItems[3].Text);  //custo
                    iValor = iValor.Replace("R$ ", "0");  //custo sem R$
                                                          // MessageBox.Show(" Produto => " + CodProdutoOrcado + "  quant = " + iQuant + " preço = " + iValor);
                }
            }
            catch
            {

            }
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            Clientes Novo = new Clientes("-1");
            Novo.ShowDialog();
        }

        private void ListaVendas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodProdutoOrcado = ListaVendas.SelectedItems[0].Text;
                if (int.Parse(CodProdutoOrcado) > 0 && Codigo_PedidoVenda > 0)
                {
                    btnRemover.Enabled = true;
                    //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    iQuant = (ListaVendas.SelectedItems[0].SubItems[2].Text); // quantidade
                    iValor = (ListaVendas.SelectedItems[0].SubItems[3].Text);  //custo
                    iValor = iValor.Replace("R$ ", "0");  //custo sem R$
                                                          // MessageBox.Show(" Produto => " + CodProdutoOrcado + "  quant = " + iQuant + " preço = " + iValor);
                    Somatoria = 0;

                    Alterar_Quantidade A_Quant = new Alterar_Quantidade(Codigo_PedidoVenda, int.Parse(CodProdutoOrcado), ListaVendas,Convert.ToDouble(iValor),iQuant);
                    A_Quant.ShowDialog();

                    //Carrega_Orcamento_OU_Pedido();
                    Vendas_Load(sender, e);
                }
            }
            catch
            {

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if ( Codigo_PedidoVenda < 1)
            {
                double x_Quant, x_Preco;
                for (int i = 0; i < ListaVendas.Items.Count; i++)
                {
                    if ((ListaVendas.Items[i].Text == CodProdutoOrcado))
                    {
                        x_Quant = Convert.ToDouble(iQuant);
                        x_Preco = Convert.ToDouble(iValor);
                        SubTotal = x_Quant * x_Preco;
                        ListaVendas.Items.RemoveAt(i);
                        btnRemover.Enabled = false;
                        break;
                    }
                }
                Total = Total - SubTotal;
                btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            }
            if ( Codigo_PedidoVenda > 0 )
            {
                // trabalhar para excluir itens do pedido de venda
                // idcotacao = tipoexecucao    idproduto = codprodutocotado
                if (MessageBox.Show(" Deseja realmente excluir este Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                    itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
                    dtItensVendidos = taItensVendidos.Pesquisa_Excluir(Codigo_PedidoVenda, int.Parse(CodProdutoOrcado));
                    //dtItensOrcados = taItensOrcados.Pesquisa_Excluir(CodigoOrcamento, int.Parse(CodProdutoOrcado));
                    double Exc_Quant = Convert.ToDouble(dtItensVendidos.Rows[0]["quantidade"].ToString());
                    double Exc_Custo = Convert.ToDouble(dtItensVendidos.Rows[0]["valor_venda"].ToString());
                    double Exc_SubTotal = Exc_Quant * Exc_Custo;
                    taItensVendidos.Excluir_Itens_PedidoVenda(Codigo_PedidoVenda, int.Parse(CodProdutoOrcado));

                    for (int i = 0; i < ListaVendas.Items.Count; i++)
                    {
                        if ((ListaVendas.Items[i].Text == CodProdutoOrcado))
                        {
                            ListaVendas.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }


                    // instânciar pedidos vendas
                    C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                    pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
                    dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Codigo_PedidoVenda);
                    
                    double Exc_Total = Convert.ToDouble(dtPedidoVenda.Rows[0]["total"].ToString());
                    Exc_Total = Exc_Total - Exc_SubTotal;
                    taPedidoVenda.Alterar_Total_PedidoVenda(Convert.ToDecimal(Exc_Total), Codigo_PedidoVenda);

                    btnTotal.Text = (String.Format("{0:C}", Exc_Total).ToString());
                    if (Exc_Total == 0)
                    {
                        //Excluir pedido de venda
                        taPedidoVenda.Excluir_PedidoVenda(Codigo_PedidoVenda);
                    }

                }
            }
        }

        public override bool Salvar()
        {
            bool bSalvar = false;

            if (ListaVendas.Items.Count < 1)
            {
                MessageBox.Show(" Não existem produtos neste pedido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bSalvar;
            }
            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();

            C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
            itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();

            if (Status == StatusCadastro.scInserindo || Codigo_PedidoVenda < 1)
            {
                if (CodigoCliente < 1)
                {
                    MessageBox.Show(" Favor selecionar um Cliente antes de Salvar este Pedido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPesquisar.Focus();
                    return bSalvar;
                }
                if (MessageBox.Show(" Deseja realmente salvar este Pedido de Vendas ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return bSalvar;
                }

                bSalvar = (taPedidoVenda.Insert(CodigoCliente,Codigo_Orcamento, DateTime.Today, Total,txtObservacao.Text,Finalizar,Entregar,null, 0) > 0);

                if (bSalvar)
                {
                    //pegar o ultimo id inserido acima na tabela de pedidos
                    string iPedidoVenda = "", iProduto, iQuantidade, iPreco;
                    int f, cont;
                    dtPedidoVenda = taPedidoVenda.ListarTodosPedidos();
                    cont = dtPedidoVenda.Rows.Count;
                    if (cont > 0)
                    {
                        for (f = 0; f < cont; f++)
                        {
                            iPedidoVenda = dtPedidoVenda.Rows[f]["Id"].ToString();  //rotina que pega o último orçamento realizado
                        }
                    }

                    //MessageBox.Show(" Ultimo => " + iCotacao);

                    for (int i = 0; i < ListaVendas.Items.Count; i++)   // salvando itens cotados
                    {
                        //idcotacao , idproduto , quantidade , valor_Custo

                        iProduto = (ListaVendas.Items[i].SubItems[0].Text);
                        iProduto = iProduto.TrimStart('0');

                        iQuantidade = (ListaVendas.Items[i].SubItems[2].Text);
                        iQuantidade = iQuantidade.Replace(",000", "");

                        iPreco = (ListaVendas.Items[i].SubItems[3].Text);
                        iPreco = iPreco.Replace("R$ ", "0");
                        //MessageBox.Show(iCotacao + "   " + iProduto + "   " + iQuantidade + "    " + iCusto);

                        taItensVendidos.Insert(int.Parse(iPedidoVenda), int.Parse(iProduto), Convert.ToDouble(iQuantidade), Convert.ToDouble(iPreco));
                    }

                    if (Codigo_Orcamento > 0)
                    {
                        // instânciar orçamentos
                        C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
                        orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
                        //dtOrcamento = taOrcamento.PesquisaOrcamentoId(Codigo_Orcamento);
                        taOrcamento.Orcamento_VirouPedido(Codigo_Orcamento);

                    }
                    if(Finalizar==1)
                    {
                        Baixar_Estoque(int.Parse(iPedidoVenda));
                    }
                }
            }
            if (Status == StatusCadastro.scEditando)
            {
                if (Finalizar == 1)
                {
                    Finalizar_Pedido(Codigo_PedidoVenda);
                }
               
                    // as alterações dos itens cotados já foram realizados anteriormente
                    taPedidoVenda.Atualizar_Observacao_Entrega(txtObservacao.Text, Entregar, Codigo_PedidoVenda);
                    bSalvar = true;
                    // alterar valor de uma cotacao e seus itens
                
            }

            //CodFornecedor        //MessageBox.Show(DateTime.Today.ToString());   // aceita = 0;


            Close();
            return bSalvar;
        }
              
        public override bool Localizar()
        {
            bool bLocalizar = false;
            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
            if (Codigo_PedidoVenda > 0)
            {
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Codigo_PedidoVenda);
                
                byte Verifica = Convert.ToByte(dtPedidoVenda.Rows[0]["concluido"].ToString());
                if (Verifica == 0)  // significa que o pedido ainda não se tornou uma venda
                {
                    ListaProdutos.Enabled = true;
                    ListaVendas.Enabled = true;
                    btnFiltrarProduto.Enabled = true;
                    txtObservacao.Enabled = true;
                    gbEntregar.Enabled = true;
                    gbFinalizar.Enabled = true;
                    txtFiltrarProduto.Enabled = true;
                    if (Convert.ToByte(dtPedidoVenda.Rows[0]["foiEntregue"].ToString()) == 1)
                    {
                        gbEntregar.Enabled = false;
                    }
                    txtFiltrarProduto.Focus();
                }
                else
                {
                    MessageBox.Show(" Este Pedido já se tornou uma Venda concluída... Alteração não permitida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Status = StatusCadastro.scEditando;
            return bLocalizar;            
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // se um pedido de venda se torna uma venda não poderá ser excluído
            // instânciar pedidos vendas
            C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
            pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();
            dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(Codigo_PedidoVenda);

            if (int.Parse(dtPedidoVenda.Rows[0]["concluido"].ToString()) == 1)
            {
                MessageBox.Show(" Este Pedido já se tornou uma Venda concluída... Exclusão não permitida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bExcluir;

            }

            C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
            itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();

            string iProduto;

            for (int i = 0; i < ListaVendas.Items.Count; i++)   // excluindo itens cotados
            {
                iProduto = (ListaVendas.Items[i].SubItems[0].Text);
                iProduto = iProduto.TrimStart('0');

                taItensVendidos.Excluir_Itens_PedidoVenda(Codigo_PedidoVenda, int.Parse(iProduto));
            }



            bExcluir = (taPedidoVenda.Excluir_PedidoVenda(Codigo_PedidoVenda) > 0);


            LimparControles();
            Close();
            return bExcluir;
        }

        public void Baixar_Estoque(int CodPedidoVenda)
        {
            // aqui devo atualizar -- no estoque
            C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
            itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
            dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(CodPedidoVenda);


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

        public void Finalizar_Pedido(int CodPedidoVenda)
        {
            // dar baixa no estoque...

            if (MessageBox.Show(" Confirma a finalização deste Pedido de Vendas ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // instânciar pedidos vendas
                C2W.c2wDataSet.pedidos_vendasDataTable dtPedidoVenda = new c2wDataSet.pedidos_vendasDataTable();
                pedidos_vendasTableAdapter taPedidoVenda = new pedidos_vendasTableAdapter();

//checar falha               
                dtPedidoVenda = taPedidoVenda.PesquisarPedidoVenda_Id(CodPedidoVenda);  
                if (Convert.ToByte(dtPedidoVenda.Rows[0]["concluido"].ToString()) == 1)
                {
                    MessageBox.Show(" Este pedido já estava finalizado... Operação Cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (CodPedidoVenda > 0)
                    {
                        taPedidoVenda.Pedido_SeTorna_Venda(CodPedidoVenda);

                        // aqui devo atualizar -- no estoque
                        C2W.c2wDataSet.itens_vendidosDataTable dtItensVendidos = new c2wDataSet.itens_vendidosDataTable();
                        itens_vendidosTableAdapter taItensVendidos = new itens_vendidosTableAdapter();
                        dtItensVendidos = taItensVendidos.Listar_Itens_Pedido(CodPedidoVenda);


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
                }
            }
        }



    }
}
