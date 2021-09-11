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
    public partial class AnaliseDeCotacoes : Form
    {
        public int[] Selecao = new int[20];
        public int Cont=0;

        public int CodCotacao, CodProduto, CodFornecedor;
        public double X_Quantidade, X_Custo;
        public string N_Produto, N_Fornecedor;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnaliseDeCotacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        public AnaliseDeCotacoes(int[] CopiaArray, int Nvezes)
        {
            InitializeComponent();
            Selecao = CopiaArray;
            Cont = Nvezes;
        }

        private void AnaliseDeCotacoes_Load(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
           
            // instânciar itens cotados
            C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
            itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();

            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            //Fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();

            C2W.c2wDataSet.analise_cotacaoDataTable dtAnalise = new c2wDataSet.analise_cotacaoDataTable();
            analise_cotacaoTableAdapter taAnalise = new analise_cotacaoTableAdapter();
            taAnalise.ExcluirAnalise();  // limpar analise

            for (int i = 0; i < Cont; i++)
            {
                //MessageBox.Show(" =>  " + Selecao[i]);

                CodCotacao = Selecao[i];
                dtCotacao = taCotacao.PesquisaCotacaoID(Selecao[i]);  // pega a cotacao

                CodFornecedor = int.Parse(dtCotacao.Rows[0]["idfornecedor"].ToString());
                dtEmpresa = taEmpresa.PesquisaFornecedorId(CodFornecedor);
                N_Fornecedor = dtEmpresa.Rows[0]["nome_empresa"].ToString();

                //// pega os itens da cotacao acima
                dtItensCotados = taItensCotados.ItensCotados(int.Parse(dtCotacao.Rows[0]["id"].ToString()));  
                                
                for(int j=0; j < dtItensCotados.Rows.Count;j++)
                {
                    //MessageBox.Show(" =>  " + dtItensCotados.Rows[j]["idproduto"].ToString());

                    CodProduto = int.Parse(dtItensCotados.Rows[j]["idproduto"].ToString());
                    X_Quantidade = Convert.ToDouble(dtItensCotados.Rows[j]["quantidade"].ToString());
                    X_Custo = Convert.ToDouble(dtItensCotados.Rows[j]["valor_Custo"].ToString());

                    dtProduto = taProduto.PesquisaProdutoId(CodProduto);
                    N_Produto = dtProduto.Rows[0]["nome"].ToString();

                    //MessageBox.Show(" =>  " + CodCotacao + "  -  " + CodProduto + "  -  " + N_Produto + "  -  " + X_Quantidade + "  -  " + X_Custo + "  -  " + CodFornecedor + "  -  " + N_Fornecedor);

                    taAnalise.Insert(CodCotacao,CodProduto,N_Produto,X_Quantidade,X_Custo,CodFornecedor,N_Fornecedor);
                    //insert aqui
                }
            }
            dtAnalise = taAnalise.OrdenaAnalise();
            if(dtAnalise.Rows.Count == 0)
            {
                Close();
            }
            Carrega_Itens_Analisados(dtAnalise);

        }

        public void Carrega_Itens_Analisados(DataTable dt)
        {
            int N1=0, N2=0;
            ListaAnaliseCotacoes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                //    item.SubItems.Add(dr[1].ToString().PadLeft(5,'0'));

                             
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:f3}", dr[3])).ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[4]).ToString)());  // preço formato moeda   
            //    item.SubItems.Add(dr[5].ToString().PadLeft(5, '0'));
                item.SubItems.Add(dr[6].ToString());

                N2 = int.Parse(dr[1].ToString());

                if (N1 == 0 || N1 != N2)
                {
                    N1 = int.Parse(dr[1].ToString());
                    //muda cor do item
                    item.SubItems.Add(" Melhor opção de compra!");
                    item.BackColor = Color.Aquamarine;
                }

                ListaAnaliseCotacoes.Items.Add(item);
            }
        }

        public string CodigoCotacao, CodigoFornecedor;

        private void ListaAnaliseCotacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoCotacao = ListaAnaliseCotacoes.SelectedItems[0].Text;
                btnNovo.Enabled = true;
                // instânciar cotações
                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));
                CodigoFornecedor = dtCotacao.Rows[0]["idFornecedor"].ToString();
            }
            catch
            {

            }
        }

        private void ListaAnaliseCotacoes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoCotacao = ListaAnaliseCotacoes.SelectedItems[0].Text;
                Close();
                C2W.c2wDataSet.analise_cotacaoDataTable dtAnalise = new c2wDataSet.analise_cotacaoDataTable();
                analise_cotacaoTableAdapter taAnalise = new analise_cotacaoTableAdapter();
                taAnalise.ExcluirAnalise();  // limpar analise
                // instânciar cotações
                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));
                CodigoFornecedor = dtCotacao.Rows[0]["idFornecedor"].ToString();

                Compras Nova = new Compras(CodigoCotacao, CodigoFornecedor, "0"); //compra nova manda 0 para indicar novo registro
                Nova.ShowDialog();
                int j = 0, Localizacao = 0;
                for (j = 0; j < Cont; j++)
                {
                    if (Selecao[j] == int.Parse(CodigoCotacao))
                    {
                        Localizacao = j;
                    }
                }
                // refresh no banco
                dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));
                if (Convert.ToByte(dtCotacao.Rows[0]["aceita"].ToString()) == 1)
                {
                    Cont--;
                    for (int posicao = Localizacao; posicao < Cont; posicao++)
                    {
                        Selecao[posicao] = Selecao[posicao + 1];
                    }
                }
                AnaliseDeCotacoes Ac = new AnaliseDeCotacoes(Selecao, Cont);
                Ac.ShowDialog();
               
            }
            catch
            {

            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Close();

            C2W.c2wDataSet.analise_cotacaoDataTable dtAnalise = new c2wDataSet.analise_cotacaoDataTable();
            analise_cotacaoTableAdapter taAnalise = new analise_cotacaoTableAdapter();
            taAnalise.ExcluirAnalise();  // limpar analise
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));
            CodigoFornecedor = dtCotacao.Rows[0]["idFornecedor"].ToString();

            Compras Nova = new Compras(CodigoCotacao, CodigoFornecedor, "0"); //compra nova manda 0 para indicar novo registro
            Nova.ShowDialog();

            int j = 0, Localizacao = 0;
            for (j = 0; j < Cont; j++)
            {
                if (Selecao[j] == int.Parse(CodigoCotacao))
                {
                    //MessageBox.Show(" Posicao => " + j + "   cod: " + CodigoCotacao);
                    Localizacao = j;
                }
            }


            // refresh no banco
            dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));

            if (Convert.ToByte(dtCotacao.Rows[0]["aceita"].ToString()) == 1)
            {
                Cont--;
                //Ordenar_Selecao(j,Cont);
                //MessageBox.Show(" Comprou a cotacao=>  " + CodigoCotacao); // na posicao j
                //MessageBox.Show(" cont: " + Cont);
                //Ordenar_Selecao(j,Cont);
                for (int posicao = Localizacao; posicao < Cont; posicao++)
                {
                    //MessageBox.Show(" posicao  =>  " + posicao + "  _  " + Selecao[posicao]);
                    Selecao[posicao] = Selecao[posicao + 1];
//                    MessageBox.Show(" posicao  =>  " + posicao + "  recebe =>_  " + Selecao[posicao]);
                }
            }
            else
            {
                //MessageBox.Show(" nao comprou nada...  ");
            }

            //for (int u = 0; u < Cont; u++)
            //{

            //    MessageBox.Show(" posicao => " + u + "  =  " + Selecao[u]);

            //}
            AnaliseDeCotacoes Ac = new AnaliseDeCotacoes(Selecao, Cont);
            Ac.ShowDialog();
        }

        private void btnEliminarResíduos_Click(object sender, EventArgs e)
        {
            // se uma cotação se torna um pedido de compra não poderá ser excluída
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();

            C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
            itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
            int IdCotacao = 0,IdProduto=0,i, N_ItensCotados;
            for (int u = 0; u < Cont; u++)
            {
//                MessageBox.Show(" posicao => " + u + "  =  " + Selecao[u]);
                IdCotacao = Selecao[u];

                dtCotacao = taCotacao.PesquisaCotacaoID(IdCotacao);
                dtItensCotados = taItensCotados.ItensCotados(IdCotacao);

                N_ItensCotados = dtItensCotados.Rows.Count;
                for (i = 0; i < N_ItensCotados; i++)   // excluindo itens cotados
                {
                    IdProduto = int.Parse(dtItensCotados.Rows[i]["idproduto"].ToString());
                    
                    taItensCotados.Excluir_Itens_Cotados(IdCotacao, IdProduto);
                }
                taCotacao.ExcluirCotacao(IdCotacao);
            }
            MessageBox.Show(" Cotações Excluídas com sucesso!", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }


    }
}
