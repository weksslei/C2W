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
    public partial class Despesas : C2W.Frm_Base
    {
        public int CodEmpresa, CodigoProduto;
        public string CodNF, CodSerie, CodParcela;
        
        public Despesas(string NF,string Serie, string IdEmpresa, string Parcela)
        {
            InitializeComponent();
            CodNF = NF;
            CodSerie = Serie;
            CodEmpresa = int.Parse(IdEmpresa);
            CodParcela = Parcela;

            
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // instanciar contas a pagar
            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();
            if (cbStatus.Text == "QUITADA")
            {
                taContas.MudarStatusDeUmaConta(1,0,DateTime.Now,CodNF,CodSerie,CodEmpresa,CodParcela);
                MessageBox.Show(" Status da parcela foi alterado... Parcela quitada!!!", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStatus.Text = "PARCELA QUITADA";
            }
            if (cbStatus.Text == "A PAGAR")
            {
                //                MessageBox.Show("" + txtValorParcela.Text);
                txtValorParcela.Text = txtValorParcela.Text.Replace("R$ ","");
                taContas.MudarStatusDeUmaConta(0,Convert.ToDecimal(txtValorParcela.Text),null, CodNF, CodSerie, CodEmpresa, CodParcela);
                MessageBox.Show(" Status da parcela foi alterado... Parcela  a pagar!!!", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStatus.Text = "PARCELA A PAGAR";
            }
        }

        private void cbNovaDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparControles();
            //txtEmpresa.Text = "";
            //txtRepresentante.Text = "";
            //txtFone1.Text = "";
            //txtFone2.Text = "";
            //            gbNF.Visible = true;
            gbNF.Enabled = false;
            //            gbParcela.Visible = false;

            Lista_ItensNF.Items.Clear();
            cbCondicoesPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cbNovaDespesa.Text== "RECEBER PEDIDOS DE COMPRA")
            {
                PesquisarPedidoCompras Ppc = new PesquisarPedidoCompras();
                Ppc.ShowDialog();

            }
            if(cbNovaDespesa.Text== "DESPESAS BÁSICAS")
            {
                Status = StatusCadastro.scInserindo;
                cbDespesasBasicas.Enabled = true;
                C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                produtosTableAdapter taProduto = new produtosTableAdapter();
                dtProduto = taProduto.ListarProdutosDespesasBasicas();

                cbDespesasBasicas.Items.Clear();
                if (dtProduto != null)
                {
                    for (int i = 0; i < dtProduto.Rows.Count; i++)
                    {
                        cbDespesasBasicas.Items.Add(dtProduto.Rows[i]["nome"].ToString());
                    }
                }
                cbDespesasBasicas.Focus();
            }
            
        }

        private void cbDespesasBasicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFornecedores.Enabled = true;
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.PesquisaProdutoDespesaBasica(cbDespesasBasicas.SelectedItem.ToString());
            if (dtProduto.Rows.Count == 1)
            {
                CodigoProduto = int.Parse(dtProduto.Rows[0]["id"].ToString());
                //           MessageBox.Show("  id escolhido => " + CodigoGrupo);


                C2W.c2wDataSet.portifolioDataTable dtPortifolio = new c2wDataSet.portifolioDataTable();
                portifolioTableAdapter taPortifolio = new portifolioTableAdapter();
                dtPortifolio = taPortifolio.FornecedoresDeUmProduto(CodigoProduto);
                cbFornecedores.Items.Clear();
                if (dtPortifolio != null)
                {
                    for (int i = 0; i < dtPortifolio.Rows.Count; i++)
                    {
                        dtEmpresa = taEmpresa.PesquisaFornecedorId(int.Parse(dtPortifolio.Rows[i]["idFornecedor"].ToString()));
                        if (dtEmpresa.Rows.Count == 1)
                        {
                            cbFornecedores.Items.Add(dtEmpresa.Rows[0]["nome_empresa"].ToString());
                        }
                    }
                }

                cbFornecedores.Focus();
            }
        }

        public int Fornecedor;

        private void cbFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            dtEmpresa = taEmpresa.FiltrarFornecedores(cbFornecedores.SelectedItem.ToString());
            if (dtEmpresa.Rows.Count == 1)
            {
                Fornecedor = int.Parse(dtEmpresa.Rows[0]["id"].ToString());
            }
            Carrega_Fornecedor(Fornecedor);
            gbNF.Enabled = true;
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

            txtNF.Focus();
            DT_EntradaNF.Text = (DateTime.Today).ToString();
            DT_EntradaNF.Enabled = false;

        }

        private void Despesas_Load(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(CodNF) > 0)
            {
//                gbNF.Visible = false;
//                gbParcela.Visible = true;
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
            }
            else
            {
//                gbNF.Visible = true;
//                gbParcela.Visible = false;
//                gbNF.Enabled = false;
                gbFornecedores.Enabled = false;
                cbNovaDespesa.Focus();
                MessageBox.Show(" Na guia INSERIR NOVA CONTA escolha uma das Opções...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gbNF.Enabled = false;
            gbParcela.Enabled = false;
            cbNovaDespesa.Enabled = true;
            cbDespesasBasicas.Enabled = false;
            cbFornecedores.Enabled = false;
            //cbStatus.Enabled = true;
        }

        public override void CarregaValores()
        {
            // instanciar contas a pagar
            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();
            dtContas = taContas.PesquisaUmaConta(CodNF, CodSerie, CodEmpresa, CodParcela);
            if (dtContas.Rows.Count > 0)
            {
                txtNumeroNF.Text = dtContas.Rows[0]["NumeroNF"].ToString();
                txtSerie.Text = dtContas.Rows[0]["SerieNF"].ToString();
                Fornecedor = int.Parse(dtContas.Rows[0]["Idfornecedor"].ToString());
                txtParcela.Text = dtContas.Rows[0]["Parcela"].ToString();
                DT_Emissao.Text = dtContas.Rows[0]["DT_Emissao"].ToString();
                DT_Vencimento.Text = dtContas.Rows[0]["DT_Vencimento"].ToString();
                txtValorParcela.Text = (String.Format("{0:C}", dtContas.Rows[0]["Valor"]).ToString());
                if (Convert.ToByte(dtContas.Rows[0]["Situacao"].ToString()) == 1)
                {
                    txtStatus.Text = "PARCELA QUITADA";
                }
                else
                {
                    txtStatus.Text = "PARCELA A PAGAR";
                }
            }
            Carrega_Fornecedor(Fornecedor);


            txtNumeroNF.Enabled = false;
            txtSerie.Enabled = false;
            txtParcela.Enabled = false;
            DT_Emissao.Enabled = false;
            DT_Vencimento.Enabled = false;
            txtValorParcela.Enabled = false;
            txtStatus.Enabled = false;

            C2W.c2wDataSet.notas_fiscaisDataTable dtNF = new c2wDataSet.notas_fiscaisDataTable();
            notas_fiscaisTableAdapter taNF = new notas_fiscaisTableAdapter();
            dtNF = taNF.PesquisaNF_Id(CodNF, CodSerie, CodEmpresa);
            if (dtNF.Rows.Count > 0)
            {
                txtNF.Text = dtNF.Rows[0]["NumeroNF"].ToString();
                txtNumeroSerie.Text = dtNF.Rows[0]["SerieNF"].ToString();
                DT_EmissaoNF.Text = dtNF.Rows[0]["DT_Emissao"].ToString();
                DT_EntradaNF.Text = dtNF.Rows[0]["DT_Entrada"].ToString();
                txtTotal_NF.Text = (String.Format("{0:C}", dtNF.Rows[0]["total"]).ToString());
                int Condicao = int.Parse(dtNF.Rows[0]["IdCondicoesPagamento"].ToString());
                C2W.c2wDataSet.condicoes_pagamentoDataTable dtCondicao = new c2wDataSet.condicoes_pagamentoDataTable();
                condicoes_pagamentoTableAdapter taCondicao = new condicoes_pagamentoTableAdapter();
                dtCondicao = taCondicao.PesquisaCondicaoId(Condicao);
                cbCondicoesPagamento.DropDownStyle = ComboBoxStyle.Simple;
                cbCondicoesPagamento.Text = dtCondicao.Rows[0]["nome"].ToString();
            }
            //parei aqui
            C2W.c2wDataSet.itens_notasfiscaisDataTable dtItensNF = new c2wDataSet.itens_notasfiscaisDataTable();
            itens_notasfiscaisTableAdapter taItensNF = new itens_notasfiscaisTableAdapter();
            dtItensNF = taItensNF.PesquisaItensNF(CodNF, CodSerie, CodEmpresa);

            Carrega_ItensNF(dtItensNF);
        }

        public void Carrega_ItensNF(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            Lista_ItensNF.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                item.Text = dr[3].ToString().PadLeft(3, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[4].ToString()));
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                item.SubItems.Add((String.Format("{0:f3}", dr[5]).ToString)());  
                item.SubItems.Add((String.Format("{0:C}", dr[6])).ToString());  // preço formato moeda
                item.SubItems.Add((String.Format("{0:C}", dr[7])).ToString()); // total do iten formato moeda
                Lista_ItensNF.Items.Add(item);
            }

            Lista_ItensNF.Enabled = false;

        }

        public void Carrega_Fornecedor(int Id_Fornecedor)
        {
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.PesquisaFornecedorId(Id_Fornecedor);
            txtEmpresa.Text = dt.Rows[0]["nome_Empresa"].ToString();
            txtRepresentante.Text = dt.Rows[0]["nome_vendedor"].ToString();
            txtFone1.Text = dt.Rows[0]["fone1"].ToString();
            txtFone2.Text = dt.Rows[0]["fone2"].ToString();
            txtEmpresa.Enabled = false;
            txtRepresentante.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;

        }

        private void txtNF_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtNumeroSerie.Focus();
            }
        }

        private void txtNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtNumeroSerie_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                DT_EmissaoNF.Focus();
            }
        }

        private void txtNumeroSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void DT_EmissaoNF_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtTotal_NF.Focus();
            }
        }

        private void DT_EmissaoNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtTotal_NF_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTotal_NF.Text == "" || txtTotal_NF.Text == "," || Convert.ToDouble(txtTotal_NF.Text) < 0.1)
                {
                    MessageBox.Show(" Valor informado inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotal_NF.Focus();
                }
                else
                {
                    cbCondicoesPagamento.Focus();
                }
            }
        }

        private void txtTotal_NF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatarMoeda(sender, e);
        }
        
        public override bool Salvar()
        {
            bool bSalvar = false;

            if (Status == StatusCadastro.scEditando)
            {
                bSalvar = true;
                Close();
                return bSalvar;
            }
            C2W.c2wDataSet.notas_fiscaisDataTable dtNF = new c2wDataSet.notas_fiscaisDataTable();
            notas_fiscaisTableAdapter taNF = new notas_fiscaisTableAdapter();
            if (txtNF.Text == "" || Convert.ToDecimal(txtNF.Text) < 1)
            {
                MessageBox.Show(" Favor entrar com número da Nota Fiscal...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNF.Focus();
                return bSalvar;
            }
            if (txtNumeroSerie.Text == "" || Convert.ToDecimal(txtNumeroSerie.Text) < 1)
            {
                MessageBox.Show(" Favor entrar com número de Série da NF..", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroSerie.Focus();
                return bSalvar;
            }
            DT_EmissaoNF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            string data = DT_EmissaoNF.Text;
            if (!ValidarData(data))     // chama a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DT_EmissaoNF.Text = "";
                DT_EmissaoNF.Focus();
                return bSalvar;
            }


            if (txtTotal_NF.Text == "" || txtTotal_NF.Text == "," || Convert.ToDouble(txtTotal_NF.Text) < 1)
            {
                MessageBox.Show(" Confira a NOTA FISCAL... Valor inválido!", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotal_NF.Focus();
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
            DT_EmissaoNF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna formatação
            DT_EntradaNF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna formatação

            if (Status == StatusCadastro.scInserindo)
            {
                // observação importante: 0 = codigo de compra somente para cadastros de despesas básicas
                if (taNF.Insert(txtNF.Text, txtNumeroSerie.Text, Fornecedor, 0, CodigoCondicao, Convert.ToDateTime(DT_EmissaoNF.Text),
                   Convert.ToDateTime(DT_EntradaNF.Text), Convert.ToDouble(txtTotal_NF.Text), 0) > 0)
                {
                    bSalvar = true;

                    // salvar itens da nota fiscal
                    //GravarItensNF();   //agua,luz e etc
                    C2W.c2wDataSet.itens_notasfiscaisDataTable dtItensNF = new c2wDataSet.itens_notasfiscaisDataTable();
                    itens_notasfiscaisTableAdapter taItensNF = new itens_notasfiscaisTableAdapter();

                    taItensNF.Insert(txtNF.Text, txtNumeroSerie.Text, Fornecedor, 1, CodigoProduto, 1, Convert.ToDouble(txtTotal_NF.Text), Convert.ToDouble(txtTotal_NF.Text));
                    // salvar contas a pagar

                    GravarContas_a_Pagar();  // gravar a conta


                    //ControlaEstoque(); // possui estoque a controlar? acho que não. analisar
                    LimparControles();
                    Close();
                }
            }
            return bSalvar;
        }
        
        public int CodigoCondicao;
        public string X_prazo, Forma_Pagamento,N_Vezes;
               
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
                
            }
        }

        public string Alfabeto = "ABCDEFGHIJ";
        
        public void GravarContas_a_Pagar()
        {

            string Parcela = "";
            double ValorParcela = 0, Saldo = 0;
            DateTime DT_Vencimento;
            byte Situacao = 0;

            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();

            if (X_prazo == "0")
            {
                Parcela = Alfabeto.Substring(0, 1);
                ValorParcela = Convert.ToDouble(txtTotal_NF.Text);
                Saldo = ValorParcela;
                Situacao = 0;
                //MessageBox.Show(" Contas a pagar.........................................." + "NF: " + txtNumeroNF.Text + "    SERIE: " + txtSerie.Text + "    Fornecedor: " + Fornecedor +
                //"    PARCELA " + Parcela + " Valor R$  " + ValorParcela +
                //"    Vencimento: " + DateTime.Now + "   Saldo R$ " + Saldo +
                //"    Data do Pagamento=> " + DateTime.Now + "    Situacao: " + Situacao);
                taContas.Insert(txtNF.Text, txtNumeroSerie.Text, Fornecedor, Parcela, ValorParcela,
                    DateTime.Today, DateTime.Now, Saldo, null, Situacao);
            }
            else
            {

                int Prestacoes = 0, i = 0;
                double SaldoParcela;
                string Prazo = "", ItenPrazo = "";

                // MessageBox.Show(" Prazo => " + X_prazo +"    "+ ItenPrazo);

                for (i = 0; i < X_prazo.Length; i++)
                {
                    ItenPrazo = X_prazo.Substring(i, 1);
                    if (ItenPrazo == ";")
                    {
                        Prestacoes = Prestacoes + 1;
                    }
                }


                Prestacoes++;
                // MessageBox.Show(" Prestacoes => " + Prestacoes);

                ValorParcela = Convert.ToDouble(txtTotal_NF.Text) / Prestacoes;
                SaldoParcela = ValorParcela;
                Situacao = 0;
                int k, l = 0;

                for (i = 0; i < Prestacoes; i++)
                {
                    for (k = l; k < X_prazo.Length; k++)
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

                    Parcela = Alfabeto.Substring(i, 1);  // letra da parcela

                    DT_EmissaoNF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // tira a formatação
                    DT_Vencimento = Convert.ToDateTime(DT_EmissaoNF.Text);

                    DT_Vencimento = DT_Vencimento.AddDays(Convert.ToDouble(Prazo));

                    //MessageBox.Show(" Contas a pagar.........................................." +
                    //    " Parcela => " + Parcela + "    R$ " + ValorParcela
                    //    + " pagar com prazo de " + Prazo + " dias." + "   Pagar até " + DT_Vencimento);
                    taContas.Insert(txtNF.Text, txtNumeroSerie.Text, Fornecedor, Parcela, ValorParcela, DateTime.Today,
                    DT_Vencimento, SaldoParcela, null, Situacao);

                    Prazo = "";

                }
            }
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // instânciar pedidos de compras
            C2W.c2wDataSet.pedidos_comprasDataTable dtPedidoCompra = new c2wDataSet.pedidos_comprasDataTable();
            pedidos_comprasTableAdapter taPedidoCompra = new pedidos_comprasTableAdapter();

            // instanciar despesas
            C2W.c2wDataSet.notas_fiscaisDataTable dtNF = new c2wDataSet.notas_fiscaisDataTable();
            notas_fiscaisTableAdapter taNF = new notas_fiscaisTableAdapter();

            C2W.c2wDataSet.itens_notasfiscaisDataTable dtItensNF = new c2wDataSet.itens_notasfiscaisDataTable();
            itens_notasfiscaisTableAdapter taItensNF = new itens_notasfiscaisTableAdapter();

            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();

            //MessageBox.Show(txtNF.Text + "    " + txtNumeroSerie.Text + "    " + Fornecedor);
            dtContas = taContas.PesquisarContasDeUmaNF(txtNF.Text,txtNumeroSerie.Text,Fornecedor);
            int i = 0;
            for(i=0; i<dtContas.Rows.Count;i++)
            {
                //MessageBox.Show(dtContas.Rows[i]["Parcela"].ToString() + "    " + dtContas.Rows[i]["valor"].ToString() + "    " + dtContas.Rows[i]["situacao"].ToString());
                if (Convert.ToByte(dtContas.Rows[i]["situacao"].ToString()) == 1)
                {
                    MessageBox.Show(" Esta NF não poderá ser excluída!  ", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return bExcluir;
                }
            }
            dtNF = taNF.PesquisaNF_Id(txtNF.Text, txtNumeroSerie.Text, Fornecedor);
            int PedidoCompra = int.Parse(dtNF.Rows[0]["IdPedido_Compra"].ToString());

            if (PedidoCompra > 0)
            {
                dtPedidoCompra = taPedidoCompra.PesquisaId(PedidoCompra);

                taPedidoCompra.Nao_ReceberPedidoCompra(PedidoCompra);
            }

            // excluindo contas a pagar de uma NF
            taContas.ExcluirContas_A_Pagar(txtNF.Text, txtNumeroSerie.Text, Fornecedor);

            // excluindo itens de uma NF
            taItensNF.ExcluirItensNF(txtNF.Text, txtNumeroSerie.Text, Fornecedor);

            // excluindo itens de uma NF
            taNF.Excluir_NF(txtNF.Text, txtNumeroSerie.Text, Fornecedor);
            bExcluir = true;


            //        LimparControles();
            Close();
            return bExcluir;
        }

        public override bool Localizar()
        {
            bool bLocalizar = false;
            if (txtNumeroNF.Text == "")
            {
                txtNumeroNF.Text = "0";
            }
            if (Convert.ToDecimal(txtNumeroNF.Text) > 0)
            {
                MessageBox.Show(" Para a rotina que envolve Contas a pagar e Notas fiscais, apenas o Status de uma parcela poderá ser alterada...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbParcela.Enabled = true;
            }
            if (txtNumeroNF.Text == "0")
            {
                txtNumeroNF.Text = "";
            }
            return bLocalizar;
        }


    }
}
