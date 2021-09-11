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
    public partial class Cotacoes : C2W.Frm_Base
    {
        public string a, b, c;

        public string CodProduto, CodProdutoCotado;

        public Double Somatoria, Editar_SubTotal;

        public double NovoValor;
        public double Total, SubTotal, Editar_btnTotal, ValorAnterior;


        public int i = 0;
        public int Teste = 1;


        public int CodFornecedor, TipoExecucao ;

        public Cotacoes(string Cod, int Tipagem) // onde Cod recebe codigo do fornecedor e tipagem recebe
        {                                        // codigo de uma cotacao 
            InitializeComponent();
            CodFornecedor = int.Parse(Cod);
            TipoExecucao = Tipagem;              // tipoExecução recebe codigo de uma cotacao
        }

        public override void tsbNovo_Click(object sender, EventArgs e)
        {
            if (TipoExecucao == 0)
            {
                listaProdutosCotados.Items.Clear();
                Total = 0;
                btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            }
            //if(TipoExecucao>0)
            //{
            //    Close();
            //    PesquisaCotacoes Pc = new PesquisaCotacoes();
            //    Pc.ShowDialog();
            //}
        }  //ok

        private void Cotacoes_Load(object sender, EventArgs e)
        {
            if (TipoExecucao > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
            }

            //   MessageBox.Show(" F => " + CodFornecedor);
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            dt = ta.PesquisaFornecedorId(CodFornecedor);

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
            listaProdutosCotados.Enabled = true;

            C2W.c2wDataSet.portifolioDataTable dtp = new c2wDataSet.portifolioDataTable();
            portifolioTableAdapter tap = new portifolioTableAdapter();
            dtp = tap.PortifolioProdutos(CodFornecedor);  //todos os produtos de um fornecedor

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
            if (TipoExecucao == 0)
            {
                MessageBox.Show(" Passo 1 - Selecione um produto no portifólio para efetuar a cotação...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ListaProdutos.Focus();
            }

            
            if (TipoExecucao > 0)
            {
                //carregar itens cotados
                // instânciar itens cotados
                C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
                dtItensCotados = taItensCotados.ItensCotados(TipoExecucao);
                Carrega_Itens_Cotados(dtItensCotados);

                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());

                listaProdutosCotados.Enabled = false;
                ListaProdutos.Enabled = false;
            }
        }       // ok

        public void Carrega_Itens_Cotados(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            listaProdutosCotados.Items.Clear();
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
                listaProdutosCotados.Items.Add(item);
                Somatoria = Somatoria + Editar_SubTotal;
            }
           
        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProduto = ListaProdutos.SelectedItems[0].Text;
                if (int.Parse(CodProduto) > 0)
                {
                    Operacao = Tarefa.NovoItem;

                    C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
                    produtosTableAdapter taProduto = new produtosTableAdapter();
                    dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));

                    lblNomeProduto.Text= dtProduto.Rows[0]["Nome"].ToString();

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
            FormatarQuantidade(sender, e);
            //restringe_teclas(e);
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
                    if (TipoExecucao == 0 || Operacao == Tarefa.NovoItem)
                    {
                        btnIncluir.Enabled = true;
                        btnIncluir.Focus();
                    }
                    else
                    {
                        if (Operacao == Tarefa.VelhoItem)
                        {
                            if (MessageBox.Show(" Confirma Alteração deste Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //alterar o item

                                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                                dtCotacao = taCotacao.PesquisaCotacaoID(TipoExecucao);
                                double Alt_Total = Convert.ToDouble(dtCotacao.Rows[0]["total"].ToString());

                                //MessageBox.Show("total => " + Alt_Total); //ok
                                //MessageBox.Show("Conta => " + Alt_Total + "  -  " + ValorAnterior);

                                Alt_Total = Alt_Total - ValorAnterior;

                                //MessageBox.Show("Resultado => " + Alt_Total);

                                NovoValor = Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text);
                                //MessageBox.Show("Conta => " + Alt_Total + "  + Novo Valor=>  " + NovoValor);

                                Alt_Total = Alt_Total + Convert.ToDouble(NovoValor);

                                //MessageBox.Show("Resultado => " + Alt_Total);


                                taCotacao.Alterar_TotalDe_UmaCotacao(Convert.ToDecimal(Alt_Total), TipoExecucao);

                                // instânciar itens cotados
                                C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                                itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

                                taItensCotados.AlterandoItemCotacao(Convert.ToDecimal(txtQuantidade.Text),
                                    Convert.ToDecimal(txtValor.Text), TipoExecucao, int.Parse(CodProdutoCotado));

                                MessageBox.Show(" Cotação Alterada com Sucesso...", "Operação Realizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                dtItensCotados = taItensCotados.ItensCotados(TipoExecucao);
                                Carrega_Itens_Cotados(dtItensCotados);

                                btnTotal.Text = (String.Format("{0:C}", Alt_Total).ToString());

                             
                                listaProdutosCotados.Focus();
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
                }
            }
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            int x = listaProdutosCotados.Items.Count;
            int n = 0 , g;
           
           

            if (TipoExecucao == 0)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaProdutosCotados.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Este produto já está cotado...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    listaProdutosCotados.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;
                }
            }

            if (TipoExecucao > 0)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaProdutosCotados.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Este produto já está cotado...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        n = 0; //nao achou
                    }
                }
                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                dtCotacao = taCotacao.PesquisaCotacaoID(TipoExecucao);
                Editar_btnTotal= Convert.ToDouble(dtCotacao.Rows[0]["total"].ToString());
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
                    listaProdutosCotados.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;

                    C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                    itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

                    taItensCotados.Insert(TipoExecucao, int.Parse(CodProduto), Quant, Moeda);

                    taCotacao.Alterar_TotalDe_UmaCotacao(Convert.ToDecimal(Total), TipoExecucao);
                }
               
            }


            btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            lblNomeProduto.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
            txtValor.Enabled = false;
            txtQuantidade.Enabled = false;
            btnIncluir.Enabled = false;

            //Contador = 0;
        }
    
        private void btnRemover_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;
            if (TipoExecucao == 0)
            {
                double x_Quant, x_Custo;
                for (i = 0; i < listaProdutosCotados.Items.Count; i++)
                {
                    if ((listaProdutosCotados.Items[i].Text == CodProdutoCotado))
                    {
                        x_Quant = Convert.ToDouble(a);
                        x_Custo = Convert.ToDouble(c);
                        SubTotal = x_Quant * x_Custo;
                        listaProdutosCotados.Items.RemoveAt(i);
                        btnRemover.Enabled = false;
                        break;
                    }
                }
                Total = Total - SubTotal;
                btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            }
            if(TipoExecucao > 0)
            {
                // trabalhar para excluir itens cotados
                // idcotacao = tipoexecucao    idproduto = codprodutocotado
                if (MessageBox.Show(" Deseja realmente excluir este Produto ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // instânciar itens cotados
                    C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                    itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

                    dtItensCotados =taItensCotados.Pesquisa_Excluir(TipoExecucao, int.Parse(CodProdutoCotado));
                    double Exc_Quant = Convert.ToDouble(dtItensCotados.Rows[0]["quantidade"].ToString());
                    double Exc_Custo = Convert.ToDouble(dtItensCotados.Rows[0]["valor_custo"].ToString());
                    double Exc_SubTotal = Exc_Quant * Exc_Custo;
                    taItensCotados.Excluir_Itens_Cotados(TipoExecucao, int.Parse(CodProdutoCotado));

                    for (i = 0; i < listaProdutosCotados.Items.Count; i++)
                    {
                        if ((listaProdutosCotados.Items[i].Text == CodProdutoCotado))
                        {                           
                            listaProdutosCotados.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }
                    

                    C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                    cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                    dtCotacao = taCotacao.PesquisaCotacaoID(TipoExecucao);
                    Double Exc_Total = Convert.ToDouble(dtCotacao.Rows[0]["total"].ToString());
                    Exc_Total = Exc_Total - Exc_SubTotal;
                    taCotacao.Alterar_TotalDe_UmaCotacao(Convert.ToDecimal(Exc_Total),TipoExecucao);

                    btnTotal.Text = (String.Format("{0:C}", Exc_Total).ToString());
                    if(Exc_Total==0)
                    {
                        //Exccluir cotacao
                        taCotacao.ExcluirCotacao(TipoExecucao);
                    }

                }
            }
        }

        private void listaProdutosCotados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProdutoCotado = listaProdutosCotados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoCotado) > 0)
                {
                    btnRemover.Enabled = true;
                    btnAlterar.Enabled = true;
                    //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    a = (listaProdutosCotados.SelectedItems[0].SubItems[2].Text); // quantidade
                    b = (listaProdutosCotados.SelectedItems[0].SubItems[3].Text);  //custo
                    c = b.Replace("R$ ", "0");  //custo sem R$
                    //MessageBox.Show(" Produto => " + CodProdutoCotado + "  quant = " + a + " custo = " + c);
                }
            }
            catch
            {

            }
        }

        private void listaProdutosCotados_DoubleClick(object sender, EventArgs e)
        {
            AlterarItem();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarItem();
        }

        public void AlterarItem()
        {
            try
            {
                CodProdutoCotado = listaProdutosCotados.SelectedItems[0].Text;
                if (int.Parse(CodProdutoCotado) > 0)
                {
                    Operacao = Tarefa.VelhoItem;

                    txtQuantidade.Enabled = true;
                    txtValor.Enabled = true;
                    btnRemover.Enabled = false;

                    lblNomeProduto.Text = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    a = (listaProdutosCotados.SelectedItems[0].SubItems[2].Text); // quantidade
                    b = (listaProdutosCotados.SelectedItems[0].SubItems[3].Text);  //custo
                    c = b.Replace("R$ ", "");  //custo sem R$
                    a = a.Replace(",000", "");
                    //a = a.TrimEnd();
                    //txtQuantidade.Text = a;
                    //txtValor.Text = c;


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

        public override bool Salvar()
        {
            bool bSalvar = false;
            if(listaProdutosCotados.Items.Count < 1)
            {
                MessageBox.Show(" Não existem produtos cotados...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bSalvar;
            }

           

            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();

            C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
            itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

            if (Status == StatusCadastro.scInserindo || TipoExecucao==0)
            {
                if (MessageBox.Show(" Deseja realmente salvar esta Cotação ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return bSalvar;
                }
                
                bSalvar = (taCotacao.Insert(CodFornecedor, DateTime.Today, Total, 0) > 0);

                if (bSalvar)
                {
                    //pegar o ultimo id inserido acima na tabela cotacoes
                    string iCotacao = "", iProduto, iQuantidade, iCusto;
                    int f, cont;
                    dtCotacao = taCotacao.ListarTodasCotacoes();
                    cont = dtCotacao.Rows.Count;
                    if (cont > 0)
                    {
                        for (f = 0; f < cont; f++)
                        {
                            iCotacao = dtCotacao.Rows[f]["Id"].ToString();  //rotina que pega a última cotação realizada
                        }
                    }

                    //MessageBox.Show(" Ultimo => " + iCotacao);

                    for (i = 0; i < listaProdutosCotados.Items.Count; i++)   // salvando itens cotados
                    {
                        //idcotacao , idproduto , quantidade , valor_Custo

                        iProduto = (listaProdutosCotados.Items[i].SubItems[0].Text);
                        iProduto = iProduto.TrimStart('0');

                        iQuantidade = (listaProdutosCotados.Items[i].SubItems[2].Text);
                        iQuantidade = iQuantidade.Replace(",000", "");

                        iCusto = (listaProdutosCotados.Items[i].SubItems[3].Text);
                        iCusto = iCusto.Replace("R$ ", "0");
                        //MessageBox.Show(iCotacao + "   " + iProduto + "   " + iQuantidade + "    " + iCusto);

                        taItensCotados.Insert(int.Parse(iCotacao), int.Parse(iProduto), Convert.ToDouble(iQuantidade), Convert.ToDouble(iCusto));
                    }
                }


            }
            if (Status == StatusCadastro.scEditando)
            {
                // as alterações dos itens cotados já foram realizados anteriormente
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
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            if(TipoExecucao>0)
            {
                dtCotacao = taCotacao.PesquisaCotacaoID(TipoExecucao);
                byte Verifica = Convert.ToByte(dtCotacao.Rows[0]["aceita"].ToString());
                if(Verifica==0)  // significa que a cotação ainda não se tornou um pedido de compra
                {
                    listaProdutosCotados.Enabled = true;
                    ListaProdutos.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" Esta Cotação já se tornou um pedido de Compra... Alteração não permitida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            Status = StatusCadastro.scEditando;

          
            return bLocalizar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // se uma cotação se torna um pedido de compra não poderá ser excluída
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();

            dtCotacao = taCotacao.PesquisaCotacaoID(TipoExecucao);

            if( int.Parse(dtCotacao.Rows[0]["aceita"].ToString()) == 1)
            {
                MessageBox.Show(" Esta Cotação não poderá ser excluída! Se tornou um pedido de Compras...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bExcluir;

            }

            C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
            itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

            string iProduto;

            for (i = 0; i < listaProdutosCotados.Items.Count; i++)   // excluindo itens cotados
            {
                iProduto = (listaProdutosCotados.Items[i].SubItems[0].Text);
                iProduto = iProduto.TrimStart('0');

                taItensCotados.Excluir_Itens_Cotados(TipoExecucao, int.Parse(iProduto));
            }


           
            bExcluir = (taCotacao.ExcluirCotacao(TipoExecucao) > 0);

           
            LimparControles();
            Close();
            return bExcluir;
        }

        public enum Tarefa
        {
            NovoItem , VelhoItem
        }

        public Tarefa Operacao;
    }
}
