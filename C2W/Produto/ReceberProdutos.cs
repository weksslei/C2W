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
    public partial class ReceberProdutos : Form
    {
        public int CodigoCompra,Fornecedor;
        public double Quant, ValorCusto, Somatoria , SubTotal;

        private void ReceberProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }
       
        public ReceberProdutos(int Cod)
        {
            InitializeComponent();
            CodigoCompra = Cod;
        }

        public void Popular_CBox()
        {
            cbCondicoesPagamento.Items.Clear();

            //popular combobox condicoes de pagamento
            C2W.c2wDataSet.condicoes_pagamentoDataTable dtCondicoesPG = new c2wDataSet.condicoes_pagamentoDataTable();
            condicoes_pagamentoTableAdapter taCondicoesPG = new condicoes_pagamentoTableAdapter();
            dtCondicoesPG = taCondicoesPG.ListarCondicoes();
            if (dtCondicoesPG != null)
            {
                for (int i = 0; i < dtCondicoesPG.Rows.Count; i++)
                {
                    cbCondicoesPagamento.Items.Add(dtCondicoesPG.Rows[i]["nome"].ToString());
                }
            }

          
        }


        private void ReceberProdutos_Load(object sender, EventArgs e)
        {
            DT_Entrada.Text = (DateTime.Today).ToString();
            DT_Entrada.Enabled = false;
            Popular_CBox();

            // instânciar itens comprados
            C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
            itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

            dtItensComprados = taItensComprados.ItensComprados(CodigoCompra);
            Carrega_Itens_Comprados(dtItensComprados);

            btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());

            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            dtPedidoCompra = taPedidoCompra.PesquisaId(CodigoCompra);

            DataPedido.Text = dtPedidoCompra.Rows[0]["data"].ToString();
            txtObservacao.Text= dtPedidoCompra.Rows[0]["observacao"].ToString();

            Fornecedor = int.Parse(dtPedidoCompra.Rows[0]["idfornecedor"].ToString());

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
            txtObservacao.Enabled = false;
            DataPedido.Enabled = false;
            //txtValor.Enabled = false;
            //txtQuantidade.Enabled = false;

            //btnIncluir.Enabled = false;
            btnRemover.Enabled = false;
            btnAlterar.Enabled = false;

            //ListaProdutos.Enabled = true;
            listaProdutosComprados.Enabled = true;

            txtNumeroNF.Focus();
           
            //fim do load
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

                item.Text = dr[1].ToString().PadLeft(5, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                //(String.Format("{0:f}", dr[3])).ToString()

                ValorCusto = Convert.ToDouble(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:f3}", dr[2]).ToString)());   // preço formato moeda
                Quant = Convert.ToDouble(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3])).ToString());
                SubTotal = Quant * ValorCusto;
                listaProdutosComprados.Items.Add(item);
                Somatoria = Somatoria + SubTotal;


                //item.SubItems.Add((String.Format("{0:f}", dr[2])).ToString());
                //item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda

                //listaProdutosComprados.Items.Add(item);
            }
        }

        public string CodProdutoComprado, iCusto, iQuant;

        private void listaProdutosComprados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProdutoComprado = listaProdutosComprados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoComprado) > 0)
                {
                    txtObservacao.Enabled = true;
                    btnRemover.Enabled = true;
                    btnAlterar.Enabled = true;
                    //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    iQuant = (listaProdutosComprados.SelectedItems[0].SubItems[2].Text); // quantidade
                    iCusto = (listaProdutosComprados.SelectedItems[0].SubItems[3].Text);  //custo
                    iCusto = iCusto.Replace("R$ ", "0");  //custo sem R$
                    //MessageBox.Show(" Produto => " + CodProdutoCotado + "  quant = " + a + " custo = " + c);
                }
            }
            catch
            {

            }
        }

        public string a, b, c;
        public double ValorAnterior,NovoValor;

         private void btnAlterar_Click(object sender, EventArgs e)
        {
            //desenvolver
            ConcertaPedido.Visible = true;
            try
            {
                CodProdutoComprado = listaProdutosComprados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoComprado) > 0)
                {
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

        public Frm_Base Funcao = new Frm_Base();

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
                    //txtValor.Enabled = true;
                    txtValorCusto.Focus();
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarQuantidade(sender, e);
        }

        private void txtNumeroNF_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if(e.KeyCode==Keys.Enter)
            {
                txtSerie.Focus();
            }
        }

        private void txtNumeroNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                DT_Emissao.Focus();
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void DT_Emissao_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalNF.Focus();
            }
        }

        private void DT_Emissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void txtTotalNF_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTotalNF.Text == "" || txtTotalNF.Text == "," || Convert.ToDouble(txtTotalNF.Text) < 0.1)
                {
                    MessageBox.Show(" Valor informado inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorCusto.Focus();
                }
                else
                {
                    cbCondicoesPagamento.Focus();
                }
            }
        }

        private void txtTotalNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarMoeda(sender, e);
        }

        private void txtValorCusto_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtValorCusto.Text == "" || txtValorCusto.Text == "," || Convert.ToDouble(txtValorCusto.Text) < 0.1)
                {
                    MessageBox.Show(" Valor informado inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorCusto.Focus();
                }
                else
                {
                    if (MessageBox.Show(" Confirma Alteração deste Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                                //alterar o item

                        C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                        pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                        dtPedidoCompra = taPedidoCompra.PesquisaId(CodigoCompra);
                        Double Alt_Total = Convert.ToDouble(dtPedidoCompra.Rows[0]["total"].ToString());
                        Alt_Total = Alt_Total - ValorAnterior;
                        NovoValor = Convert.ToDouble(txtValorCusto.Text) * Convert.ToDouble(txtQuantidade.Text);
                        Alt_Total = Alt_Total + Convert.ToDouble(NovoValor);
                        taPedidoCompra.Alterar_TotalDe_UmaCompra(Convert.ToDecimal(Alt_Total), txtObservacao.Text, CodigoCompra);
                // instânciar itens cotados
                        C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
                        itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();
                        taItensComprados.AlterarItensComprados(Convert.ToDecimal(txtQuantidade.Text),
                        Convert.ToDecimal(txtValorCusto.Text), CodigoCompra, int.Parse(CodProdutoComprado));
                        MessageBox.Show(" Pedido Alterado com Sucesso...", "Operação Realizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtItensComprados = taItensComprados.ItensComprados(CodigoCompra);
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
                    txtValorCusto.Text = "";
                    btnAlterar.Enabled = false;
                    //faz tudo e esconde o grupobox
                    ConcertaPedido.Visible = false;
                }
            }
        }

        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.FormatarMoeda(sender, e);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;
            if (CodigoCompra > 0)
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
                    dtItensComprados = taItensComprados.Pesquisa_Excluir(CodigoCompra, int.Parse(CodProdutoComprado));

                    //taItensComprados.ExcluirItensDaCompra(CodigoCompra, int.Parse(CodProdutoComprado));

                    double Exc_Quant = int.Parse(dtItensComprados.Rows[0]["quantidade"].ToString());
                    double Exc_Custo = Convert.ToDouble(dtItensComprados.Rows[0]["valor_custo"].ToString());
                    double Exc_SubTotal = Exc_Quant * Exc_Custo;
                    taItensComprados.ExcluirItensDaCompra(CodigoCompra, int.Parse(CodProdutoComprado));

                    for (int i = 0; i < listaProdutosComprados.Items.Count; i++)
                    {
                        if ((listaProdutosComprados.Items[i].Text == CodProdutoComprado))
                        {
                            listaProdutosComprados.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }
                    C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
                    pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();
                    dtPedidoCompra = taPedidoCompra.PesquisaId(CodigoCompra);
                    Double Exc_Total = Convert.ToDouble(dtPedidoCompra.Rows[0]["total"].ToString());
                    Exc_Total = Exc_Total - Exc_SubTotal;
                    taPedidoCompra.Alterar_TotalDe_UmaCompra(Convert.ToDecimal(Exc_Total), txtObservacao.Text, CodigoCompra);
                    btnTotal.Text = (String.Format("{0:C}", Exc_Total).ToString());
                    MessageBox.Show(" Produto removido com Sucesso...", "Operação Realizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Exc_Total == 0)
                    {
                        //Excluir compra
                        taPedidoCompra.ExcluirPedidoCompra(CodigoCompra);
                        //Close();
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // salvar nota fiscal
            bool Exito = SalvarNF();
            if (Exito)
            {
                // salvar itens da nota fiscal
                GravarItensNF();
                // salvar contas a pagar
                GravarContas_a_Pagar();

                ControlaEstoque();

                MessageBox.Show(" Informações Salvas com sucesso...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

           
        }

        public bool SalvarNF()
        {
            bool bSalvar = false;
            C2W.c2wDataSet.notas_fiscaisDataTable dtNF = new c2wDataSet.notas_fiscaisDataTable();
            notas_fiscaisTableAdapter taNF = new notas_fiscaisTableAdapter();

            dtNF = taNF.Verifica_Numero_NF_Existe(Fornecedor,txtNumeroNF.Text);
            if(dtNF.Rows.Count > 0)
            {
                MessageBox.Show(" Favor verificar número da Nota Fiscal...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroNF.Focus();
                return bSalvar;
            }

            if(txtNumeroNF.Text == "" || Convert.ToDecimal(txtNumeroNF.Text) < 1)
            {
                MessageBox.Show(" Favor entrar com número da Nota Fiscal...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroNF.Focus();
                return bSalvar;
            }
            if (txtSerie.Text == "" || Convert.ToDecimal(txtSerie.Text) < 1)
            {
                MessageBox.Show(" Favor entrar com número de Série da NF..", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerie.Focus();
                return bSalvar;
            }
            DT_Emissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            string data = DT_Emissao.Text;
            if (!Funcao.ValidarData(data))     // chama a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DT_Emissao.Text = "";
                DT_Emissao.Focus();
                return bSalvar;
            }
            if (txtTotalNF.Text == "" || txtTotalNF.Text == "," || Convert.ToDouble(txtTotalNF.Text) < 0.1)
            {
                MessageBox.Show(" Valor informado inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValorCusto.Focus();
                return bSalvar;
            }
            c = btnTotal.Text.Replace("R$ ", "");  //custo sem R$
       //     MessageBox.Show(c + "   " + txtTotalNF.Text);

            if (Convert.ToDouble(c) != Convert.ToDouble(txtTotalNF.Text))
            {
                MessageBox.Show(" Confira a NOTA FISCAL com o pedido de compras... Total da NF não confere com o Pedido!", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalNF.Focus();
                return bSalvar;
            }

            if (CodigoCondicao < 1)
            {
                MessageBox.Show(" Favor selecionar uma forma de pagamento!", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCondicoesPagamento.Focus();
                return bSalvar;
            }



            // salvando enfim a NF
            // Cadeia de caracteres não foi reconhecida como DateTime válido.
            DT_Emissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna formatação
            DT_Entrada.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna formatação

            if (taNF.Insert(txtNumeroNF.Text, txtSerie.Text, Fornecedor, CodigoCompra, CodigoCondicao, Convert.ToDateTime(DT_Emissao.Text),
               Convert.ToDateTime(DT_Entrada.Text), Convert.ToDouble(txtTotalNF.Text), 0) > 0)
            {
                bSalvar = true;
            }
            return bSalvar;
        }

        public int CodigoCondicao;
        public string X_prazo,Forma_Pagamento,N_Vezes;

        private void cbCondicoesPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Forma_Pagamento = cbCondicoesPagamento.SelectedItem.ToString();
            //pegar o codigo da condicao de pagamento
            C2W.c2wDataSet.condicoes_pagamentoDataTable dtCondicoesPG = new c2wDataSet.condicoes_pagamentoDataTable();
            condicoes_pagamentoTableAdapter taCondicoesPG = new condicoes_pagamentoTableAdapter();
            dtCondicoesPG = taCondicoesPG.CondicaoSelecionada(cbCondicoesPagamento.SelectedItem.ToString());
            
            if (dtCondicoesPG.Rows.Count == 1)
            {
                CodigoCondicao = int.Parse(dtCondicoesPG.Rows[0]["id"].ToString());
                X_prazo = dtCondicoesPG.Rows[0]["prazo"].ToString();

                //MessageBox.Show("  tamanho: " + X_prazo.LongCount() );
            }
        }

        public void GravarItensNF()
        {
            
            int ItenNF = 1, IdProduto;
            double Quantidade, Valor, Total;
            C2W.c2wDataSet.itens_notasfiscaisDataTable dtItensNF = new c2wDataSet.itens_notasfiscaisDataTable();
            itens_notasfiscaisTableAdapter taItensNF = new itens_notasfiscaisTableAdapter();

            //salvar lista de produtos comprados


            foreach (ListViewItem listViewItem in this.listaProdutosComprados.Items)
            {
                IdProduto = int.Parse(listViewItem.SubItems[0].Text);

                Quantidade=Convert.ToDouble(listViewItem.SubItems[2].Text);

                string Val= (listViewItem.SubItems[3].Text);
                Val = Val.Replace("R$ ","");
                Valor = Convert.ToDouble(Val);
                Total = Quantidade * Valor;

                //MessageBox.Show(" itens da nota fiscal.........................................." + "NF: " + txtNumeroNF.Text + "    SERIE: " + txtSerie.Text + "    Fornecedor: " + Fornecedor + "    ITEN " + ItenNF + " Produto => " + IdProduto + "  Quant: " + Quantidade + "   R$ " + Valor + "   Total iten R$ " + Total);

                taItensNF.Insert(txtNumeroNF.Text, txtSerie.Text, Fornecedor, ItenNF, IdProduto, Quantidade, Valor, Total);
                ItenNF++;
            }
        }

        public string Alfabeto = "ABCDEFGHIJ";
       

        public void GravarContas_a_Pagar()
        {
            
            string Parcela="";
            double ValorParcela=0,Saldo=0;
            DateTime DT_Vencimento;
            byte Situacao = 0;

            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();

            if(X_prazo=="0")
            {
                Parcela = Alfabeto.Substring(0,1);
                ValorParcela = Convert.ToDouble(txtTotalNF.Text);
                Saldo = ValorParcela;
                Situacao = 0;
                //MessageBox.Show(" Contas a pagar.........................................." + "NF: " + txtNumeroNF.Text + "    SERIE: " + txtSerie.Text + "    Fornecedor: " + Fornecedor +
                //"    PARCELA " + Parcela + " Valor R$  " + ValorParcela + 
                //"    Vencimento: " + DateTime.Now + "   Saldo R$ " + Saldo + 
                //"    Data do Pagamento=> " + DateTime.Now + "    Situacao: " + Situacao);
                taContas.Insert(txtNumeroNF.Text, txtSerie.Text, Fornecedor, Parcela, ValorParcela,
                    DateTime.Today, DateTime.Now, Saldo, DateTime.Now, Situacao);
            }
            else
            {

                int Prestacoes = 0, i = 0;
                double SaldoParcela;
                string Prazo="",ItenPrazo="";
   
               // MessageBox.Show(" Prazo => " + X_prazo +"    "+ ItenPrazo);
                
                for ( i=0 ;i < X_prazo.LongCount() ;i++)
                {                    
                    ItenPrazo = X_prazo.Substring(i, 1);
                    if (ItenPrazo == ";")
                    {
                        Prestacoes = Prestacoes + 1;
                    }
                }


                Prestacoes++;
               // MessageBox.Show(" Prestacoes => " + Prestacoes);

                ValorParcela =  Convert.ToDouble(txtTotalNF.Text) / Prestacoes;
                SaldoParcela = ValorParcela;
                Situacao = 0;
                int k, l=0;

                for(i=0; i < Prestacoes; i++)
                {
                    for ( k = l; k < X_prazo.LongCount(); k++)
                    {
                        ItenPrazo = X_prazo.Substring(k, 1);
                        if (ItenPrazo == ";")
                        {
                            break;
                        }
                        else
                        {
                            Prazo = Prazo + ItenPrazo; // dias a pagar
                        }
                    }
                    l = k + 1;
                    //MessageBox.Show(Prazo);

                    Parcela = Alfabeto.Substring(i,1);  // letra da parcela
                  
                    DT_Emissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // tira a formatação
                    DT_Vencimento = Convert.ToDateTime(DT_Emissao.Text);
                    
                    DT_Vencimento=DT_Vencimento.AddDays(Convert.ToDouble(Prazo));

                    //MessageBox.Show(" Contas a pagar.........................................." + 
                    //    " Parcela => " + Parcela + "    R$ " + ValorParcela 
                    //    + " pagar com prazo de " + Prazo + " dias." + "   Pagar até " + DT_Vencimento);
                    taContas.Insert(txtNumeroNF.Text, txtSerie.Text, Fornecedor, Parcela, ValorParcela , DateTime.Today,
                    DT_Vencimento, SaldoParcela, null , Situacao);

                    Prazo = "";

                }
            }
        }

        public void ControlaEstoque()
        {
            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            ////MessageBox.Show(dtPedidoCompra.Rows[0]["id"].ToString() + "    " + dtPedidoCompra.Rows[0]["total"].ToString());
            taPedidoCompra.AlterarObservacao(txtObservacao.Text, CodigoCompra);
            taPedidoCompra.ReceberPedidoCompra(CodigoCompra);

            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            // agora tenho que instanciar itens do pedido
            // instânciar itens comprados
            C2W.c2wDataSet.itens_compradosDataTable dtItensComprados = new c2wDataSet.itens_compradosDataTable();
            itens_compradosTableAdapter taItensComprados = new itens_compradosTableAdapter();

            dtItensComprados = taItensComprados.ItensComprados(CodigoCompra);

            double NovoEstoque;
            int CodProduto;
            // alterando estoque

            for (int i = 0; i < dtItensComprados.Rows.Count; i++)
            {
                // MessageBox.Show(dtItensComprados.Rows[i]["idproduto"].ToString() + "    " + dtItensComprados.Rows[i]["quantidade"].ToString());
                //localizar produto na tabela produtos
                CodProduto = int.Parse(dtItensComprados.Rows[i]["idproduto"].ToString());
                dtProduto = taProduto.PesquisaProdutoId(CodProduto);
                if (dtProduto.Rows[0]["nome"].ToString() == "CARCAÇA BOVINA FEMEA" ||
                    dtProduto.Rows[0]["nome"].ToString() == "CARCAÇA BOVINA MACHO")
                {
                    //desmenbramento bovino padrao
                    Desmenbrar_Bovino();
                }
                else
                {
                    if (dtProduto.Rows[0]["nome"].ToString() == "CARCAÇA SUÍNA")
                    {
                        //desmenbramento suíno
                        Desmenbrar_Suino();
                    }
                    else
                    {
                        if (dtProduto.Rows[0]["nome"].ToString() == "DIANTEIRO BOVINO C/ COSTELA")
                        {
                            //desmenbramento Dianteiro Bovino C/ Costela
                            Desmenbrar_DianteiroBovino_ComCostela();
                        }
                        else
                        {
                            if (dtProduto.Rows[0]["nome"].ToString() == "DIANTEIRO BOVINO S/ COSTELA")
                            {
                                //desmenbramento Dianteiro Bovino S/ Costela 
                                Desmenbrar_DianteiroBovino_SemCostela();
                            }
                            else
                            {
                                if (dtProduto.Rows[0]["nome"].ToString() == "TRASEIRO BOVINO RESFRIADO")
                                {
                                    //desmenbramento trazeiro bovino 
                                    Desmenbrar_TrazeiroBovino();
                                }
                                else
                                {
                                    NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                                  //  MessageBox.Show("Estoque atual => " + NovoEstoque);
                                    //    e somar um por um no estoque
                                    NovoEstoque = NovoEstoque + Convert.ToDouble(dtItensComprados.Rows[i]["quantidade"].ToString());
                                   // MessageBox.Show("Novo Estoque  => " + NovoEstoque);
                                    //nesse ponto salvar novo volume_estocado
                                    taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), CodProduto);
                                }
                            }
                        }
                    }
                }

            }
        }

        public double[] FracaoBovina = { 2.359,8.458,2.109,4.811,7.779,6.573,3.844,1.974,1.577,3.949,3.445
        ,1.895,1.577,2.214,13.363,4.799,8.172,5.076};

        public void Desmenbrar_Bovino()
        {
            string Peso = listaProdutosComprados.Items[0].SubItems[2].Text;
            int Cont = 0;
            double Peso_Item, NovoEstoque;
            double Peso_Boi = Convert.ToDouble(Peso);
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            for(int Iten=50; Iten<=67; Iten++)
            {
                dtProduto = taProduto.PesquisaProdutoId(Iten);
                Peso_Item = (Peso_Boi * FracaoBovina[Cont]) / 100;
                NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                NovoEstoque = NovoEstoque + Peso_Item;
                taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), Iten);
                Cont++;
            }
        }

        public double[] FracaoSuina = { 22.82, 10.01, 35.98, 5.54, 7.28, 2.08, 1.31, 1.13 };

        public void Desmenbrar_Suino()
        {
            string Peso = listaProdutosComprados.Items[0].SubItems[2].Text;
            int Cont = 0;
            double Peso_Item, NovoEstoque;
            double Peso_Porco = Convert.ToDouble(Peso);
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            for (int Iten = 68; Iten <= 75; Iten++)
            {
                dtProduto = taProduto.PesquisaProdutoId(Iten);
                Peso_Item = (Peso_Porco * FracaoSuina[Cont]) / 100;
                NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                NovoEstoque = NovoEstoque + Peso_Item;
                taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), Iten);
                Cont++;
            }
        }

        public double[] FracaoBovinaTrazeiro = {4.839,17.368,4.332,9.874,15.963,8.815
                ,7.889,4.058,3.232,4.078};

        public void Desmenbrar_TrazeiroBovino()
        {
            string Peso = listaProdutosComprados.Items[0].SubItems[2].Text;
            int Cont = 0;
            double Peso_Item, NovoEstoque;
            double Peso_Trazeiro = Convert.ToDouble(Peso);
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            for (int Iten = 50; Iten <= 59; Iten++)
            {
                dtProduto = taProduto.PesquisaProdutoId(Iten);
                Peso_Item = (Peso_Trazeiro * FracaoBovinaTrazeiro[Cont]) / 100;
                NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                NovoEstoque = NovoEstoque + Peso_Item;
                taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), Iten);
                Cont++;
            }
        }

        public double[] FracaoBovinaDianteiroComCostela = {3.841,6.759,3.725,3.094,4.349,26.208,
            9.427,16.049,9.95,4.463};

        public void Desmenbrar_DianteiroBovino_ComCostela()
        {
            string Peso = listaProdutosComprados.Items[0].SubItems[2].Text;
            int Cont = 0;
            double Peso_Item, NovoEstoque;
            double Peso_Dianteiro = Convert.ToDouble(Peso);
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            for (int Iten = 59; Iten <= 67; Iten++)
            {
                dtProduto = taProduto.PesquisaProdutoId(Iten);
                Peso_Item = (Peso_Dianteiro * FracaoBovinaDianteiroComCostela[Cont]) / 100;
                NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                NovoEstoque = NovoEstoque + Peso_Item;
                taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), Iten);
                Cont++;
            }
            dtProduto = taProduto.PesquisaProdutoId(55);
            Peso_Item = (Peso_Dianteiro * FracaoBovinaDianteiroComCostela[9]) / 100;
            NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
            NovoEstoque = NovoEstoque + Peso_Item;
            taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), 55);

        }

        public double[] FracaoBovinaDianteiroSEM_Costela = {5.193,9.136,5.038,4.179,5.88,35.399,
            12.735,6.034};

        public void Desmenbrar_DianteiroBovino_SemCostela()
        {
            string Peso = listaProdutosComprados.Items[0].SubItems[2].Text;
            int Cont = 0;
            double Peso_Item, NovoEstoque;
            double Peso_Dianteiro = Convert.ToDouble(Peso);
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            for (int Iten = 59; Iten <= 65; Iten++)
            {
                dtProduto = taProduto.PesquisaProdutoId(Iten);
                Peso_Item = (Peso_Dianteiro * FracaoBovinaDianteiroSEM_Costela[Cont]) / 100;
                NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
                NovoEstoque = NovoEstoque + Peso_Item;
                taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), Iten);
                Cont++;
            }
            dtProduto = taProduto.PesquisaProdutoId(55);
            Peso_Item = (Peso_Dianteiro * FracaoBovinaDianteiroSEM_Costela[7]) / 100;
            NovoEstoque = Convert.ToDouble(dtProduto.Rows[0]["volume_estocado"].ToString());
            NovoEstoque = NovoEstoque + Peso_Item;
            taProduto.AlterarEstoque(Convert.ToDecimal(NovoEstoque), 55);
        }

      

        // fim de receber produtos...
    }
}
