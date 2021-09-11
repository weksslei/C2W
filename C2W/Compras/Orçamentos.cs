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
    public partial class Orçamentos : C2W.Frm_Base
    {
        public int CodigoOrcamento, CodigoCliente;

        public Orçamentos(string CodOrcamento)
        {
            InitializeComponent();
            CodigoOrcamento = int.Parse(CodOrcamento);
        }

        public string NomeCliente;
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

        private void Orçamentos_Load(object sender, EventArgs e)
        {
            txtFiltrarProduto.Enabled = false;
            btnRemover.Enabled = false;
            btnIncluir.Enabled = false;
            txtQuantidade.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
            txtFone1.Enabled = false;
            txtFone2.Enabled = false;
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            dtProduto = taProduto.ListarProdutosParaVenda();
            Carrega_Produtos(dtProduto);
            if (CodigoOrcamento > 0)
            {
                txtPesquisar.Enabled = false;
                cbClientes.Enabled = false;
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
                itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();
                dtItensOrcados = taItensOrcados.Pesquisa_Itens_OrcamentoId(CodigoOrcamento);
                Carrega_Orcamentos(dtItensOrcados);

                // instânciar orçamentos
                C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
                orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
                dtOrcamento = taOrcamento.PesquisaOrcamentoId(CodigoOrcamento);

                // buscar clientes
                C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
                clientesTableAdapter taClientes = new clientesTableAdapter();
                dtClientes = taClientes.PesquisaClienteId(int.Parse(dtOrcamento.Rows[0]["idCliente"].ToString()));
                Carrega_Clientes(dtClientes);
                btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());
                
            }
            else
            {
                txtPesquisar.Enabled = true;
                txtPesquisar.Focus();
            }
            ListaProdutos.Enabled = false;
            listaOrcamento.Enabled = false;
        }

        public double Somatoria , Editar_SubTotal;

        public void Carrega_Orcamentos(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            listaOrcamento.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dr[1].ToString().PadLeft(5, '0');
                item.SubItems.Add(dtProduto.Rows[0]["nome"].ToString());
                double Quant = Convert.ToDouble(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:f}", dr[2])).ToString());
                double Preco = Convert.ToDouble(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                Editar_SubTotal = Quant * Preco;
                listaOrcamento.Items.Add(item);
                Somatoria = Somatoria + Editar_SubTotal;
            }
        }

        public void Carrega_Clientes(DataTable dtCliente)
        {
            txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
            txtCPF.Text = dtCliente.Rows[0]["cpf"].ToString();
            txtEmail.Text = dtCliente.Rows[0]["e_mail"].ToString();
            txtFone1.Text = dtCliente.Rows[0]["fone1"].ToString();
            txtFone2.Text = dtCliente.Rows[0]["fone2"].ToString();
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
                dtOferta = taOferta.PesquisaProdutoID_OfertaValida(int.Parse(dr[0].ToString()),DateTime.Now);
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
                        cbClientes.Items.Add(dtCliente.Rows[i]["id"].ToString().PadLeft(5,'0') + "   " + dtCliente.Rows[i]["nome"].ToString());
                    }
                }

                cbClientes.Focus();
            }
        }

        public string CodProduto;

        private void txtFiltrarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnFiltrarProduto.Focus();
            }
        }

        private void btnFiltrarProduto_Click(object sender, EventArgs e)
        {
            cbClientes.Enabled = false;
            ListaProdutos.Enabled = true;
            listaOrcamento.Enabled = true;
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
        
        public double Valor,Total,SubTotal;

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
                    if(dtOferta.Rows.Count > 0)
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
                    btnIncluir.Enabled = true;
                    btnIncluir.Focus();
                }
            }
        }

      
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatarQuantidade(sender, e);
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            int x = listaOrcamento.Items.Count;
            int n = 0, g;
            if (CodigoOrcamento < 1)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaOrcamento.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Produto já inserido no orçamento...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    listaOrcamento.Items.Add(item);
                    SubTotal = Quant * Moeda;
                    Total = Total + SubTotal;
                }
            }

            if (CodigoOrcamento > 0)
            {
                for (g = 0; g < x; g++)
                {
                    //                MessageBox.Show(" na Listview => " + listaProdutosCotados.Items[g].Text + "         Selecionado => " + CodProduto);
                    if ((listaOrcamento.Items[g].Text == CodProduto))
                    {
                        n = 1;
                        MessageBox.Show(" Produto já inserido no orçamento...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        n = 0; //nao achou
                    }
                }
                // instânciar orçamentos
                C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
                orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
                dtOrcamento = taOrcamento.PesquisaOrcamentoId(CodigoOrcamento);
                Total = Convert.ToDouble(dtOrcamento.Rows[0]["total"].ToString());
                if (n == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = CodProduto;
                    item.SubItems.Add(lblNomeProduto.Text);
                    double Quant = Convert.ToDouble(txtQuantidade.Text);
                    item.SubItems.Add(String.Format("{0:f3}", Quant).ToString());
                    
                    item.SubItems.Add(String.Format("{0:C}", Valor).ToString());
                    listaOrcamento.Items.Add(item);
                    SubTotal = Quant * Valor;
                    Total = Total + SubTotal;

                    C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
                    itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();

                    taItensOrcados.Insert(CodigoOrcamento, int.Parse(CodProduto), Quant, Valor);

                    taOrcamento.Alterar_TotalDe_UmOrcamento(Convert.ToDecimal(Total), CodigoOrcamento);
                }
            }
            btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            lblNomeProduto.Text = "";
            txtQuantidade.Text = "";
            Valor = 0;
            txtQuantidade.Enabled = false;
            btnIncluir.Enabled = false;
        }

        public string CodProdutoOrcado,iQuant,iValor;

        private void listaOrcamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodProdutoOrcado = listaOrcamento.SelectedItems[0].Text;
                if (int.Parse(CodProdutoOrcado) > 0)
                {
                    btnRemover.Enabled = true;
                     //NomeProduto = (listaProdutosCotados.SelectedItems[0].SubItems[1].Text); //nome produto
                    iQuant = (listaOrcamento.SelectedItems[0].SubItems[2].Text); // quantidade
                    iValor = (listaOrcamento.SelectedItems[0].SubItems[3].Text);  //custo
                    iValor = iValor.Replace("R$ ", "0");  //custo sem R$
                   // MessageBox.Show(" Produto => " + CodProdutoOrcado + "  quant = " + iQuant + " preço = " + iValor);
                }
            }
            catch
            {

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (CodigoOrcamento < 1)
            {
                double x_Quant, x_Preco;
                for (int i = 0; i < listaOrcamento.Items.Count; i++)
                {
                    if ((listaOrcamento.Items[i].Text == CodProdutoOrcado))
                    {
                        x_Quant = Convert.ToDouble(iQuant);
                        x_Preco = Convert.ToDouble(iValor);
                        SubTotal = x_Quant * x_Preco;
                        listaOrcamento.Items.RemoveAt(i);
                        btnRemover.Enabled = false;
                        break;
                    }
                }
                Total = Total - SubTotal;
                btnTotal.Text = (String.Format("{0:C}", Total).ToString());
            }
            if (CodigoOrcamento > 0)
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
                   
                    C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
                    itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();
                    dtItensOrcados=taItensOrcados.Pesquisa_Excluir(CodigoOrcamento, int.Parse(CodProdutoOrcado));
                    double Exc_Quant = Convert.ToDouble(dtItensOrcados.Rows[0]["quantidade"].ToString());
                    double Exc_Custo = Convert.ToDouble(dtItensOrcados.Rows[0]["valor_venda"].ToString());
                    double Exc_SubTotal = Exc_Quant * Exc_Custo;
                    taItensOrcados.Excluir_Itens_Orcamento(CodigoOrcamento, int.Parse(CodProdutoOrcado));

                    for (int i = 0; i < listaOrcamento.Items.Count; i++)
                    {
                        if ((listaOrcamento.Items[i].Text == CodProdutoOrcado))
                        {
                            listaOrcamento.Items.RemoveAt(i);
                            btnRemover.Enabled = false;
                            break;
                        }
                    }


                    // instânciar orçamentos
                    C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
                    orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
                    dtOrcamento = taOrcamento.PesquisaOrcamentoId(CodigoOrcamento);
                    
                    double Exc_Total = Convert.ToDouble(dtOrcamento.Rows[0]["total"].ToString());
                    Exc_Total = Exc_Total - Exc_SubTotal;
                    taOrcamento.Alterar_TotalDe_UmOrcamento(Convert.ToDecimal(Exc_Total), CodigoOrcamento);

                    btnTotal.Text = (String.Format("{0:C}", Exc_Total).ToString());
                    if (Exc_Total == 0)
                    {
                        //Exccluir cotacao
                        taOrcamento.Excluir_Orcamento(CodigoOrcamento);
                    }

                }
            }
        }


        public override bool Salvar()
        {
            bool bSalvar = false;
           
            if (listaOrcamento.Items.Count < 1)
            {
                MessageBox.Show(" Não existem produtos neste Orçamento...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bSalvar;
            }
            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();

            C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
            itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();

            if (Status == StatusCadastro.scInserindo || CodigoOrcamento < 1)
            {
                if (CodigoCliente < 1)
                {
                    MessageBox.Show(" Favor selecionar um Cliente antes de Salvar este Orçamento...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPesquisar.Focus();
                    return bSalvar;
                }
                if (MessageBox.Show(" Deseja realmente salvar este Orçamento ? ", "Confirmando Operação", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return bSalvar;
                }

                bSalvar = (taOrcamento.Insert(CodigoCliente, DateTime.Today, Total, 0) > 0);

                if (bSalvar)
                {
                    //pegar o ultimo id inserido acima na tabela de orçamentos
                    string iOrcamento = "", iProduto, iQuantidade, iPreco;
                    int f, cont;
                    dtOrcamento = taOrcamento.ListarTodosOrcamentos();
                    cont = dtOrcamento.Rows.Count;
                    if (cont > 0)
                    {
                        for (f = 0; f < cont; f++)
                        {
                            iOrcamento = dtOrcamento.Rows[f]["Id"].ToString();  //rotina que pega o último orçamento realizado
                        }
                    }

                    //MessageBox.Show(" Ultimo => " + iCotacao);

                    for (int i = 0; i < listaOrcamento.Items.Count; i++)   // salvando itens cotados
                    {
                        //idcotacao , idproduto , quantidade , valor_Custo

                        iProduto = (listaOrcamento.Items[i].SubItems[0].Text);
                        iProduto = iProduto.TrimStart('0');

                        iQuantidade = (listaOrcamento.Items[i].SubItems[2].Text);
                        iQuantidade = iQuantidade.Replace(",000", "");

                        iPreco = (listaOrcamento.Items[i].SubItems[3].Text);
                        iPreco = iPreco.Replace("R$ ", "0");
                        //MessageBox.Show(iCotacao + "   " + iProduto + "   " + iQuantidade + "    " + iCusto);

                        taItensOrcados.Insert(int.Parse(iOrcamento), int.Parse(iProduto), Convert.ToDouble(iQuantidade), Convert.ToDouble(iPreco));
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
            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
            if (CodigoOrcamento > 0)
            {
                dtOrcamento = taOrcamento.PesquisaOrcamentoId(CodigoOrcamento);
                byte Verifica = Convert.ToByte(dtOrcamento.Rows[0]["aceito"].ToString());
                if (Verifica == 0)  // significa que a cotação ainda não se tornou um pedido de venda
                {
                    listaOrcamento.Enabled = true;
                    ListaProdutos.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" Este Orçamento já se tornou um pedido de Venda... Alteração não permitida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Status = StatusCadastro.scEditando;
            return bLocalizar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // se um orcamento se torna um pedido de venda não poderá ser excluído
            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
            dtOrcamento = taOrcamento.PesquisaOrcamentoId(CodigoOrcamento);
            
            if (int.Parse(dtOrcamento.Rows[0]["aceito"].ToString()) == 1)
            {
                MessageBox.Show(" Este Orçamento não poderá ser excluído! Se tornou um pedido de Vendas...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bExcluir;

            }

            C2W.c2wDataSet.itens_orcamentoDataTable dtItensOrcados = new c2wDataSet.itens_orcamentoDataTable();
            itens_orcamentoTableAdapter taItensOrcados = new itens_orcamentoTableAdapter();

            string iProduto;

            for (int i = 0; i < listaOrcamento.Items.Count; i++)   // excluindo itens cotados
            {
                iProduto = (listaOrcamento.Items[i].SubItems[0].Text);
                iProduto = iProduto.TrimStart('0');

                taItensOrcados.Excluir_Itens_Orcamento(CodigoOrcamento, int.Parse(iProduto));
            }



            bExcluir = (taOrcamento.Excluir_Orcamento(CodigoOrcamento) > 0);


            LimparControles();
            Close();
            return bExcluir;
        }


    }
}
