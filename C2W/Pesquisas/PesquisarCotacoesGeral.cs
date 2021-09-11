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
    public partial class PesquisarCotacoesGeral : Form
    {
        public PesquisarCotacoesGeral()
        {
            InitializeComponent();
        }

        public Frm_Base Funcao = new Frm_Base();

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            PesquisaCotacoes Pc = new PesquisaCotacoes();
            Pc.ShowDialog();
        }

        private void PesquisarCotacoesGeral_Load(object sender, EventArgs e)
        {
            btnAnalisarCotacoes.Enabled = false;
            btnOK.Enabled = false;
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            dtCotacao = taCotacao.CotacoesNaoCompradas();
            Carrega_Cotacoes(dtCotacao);
            mtbDataInicial.Focus();
        }

        private void rbComprasNaoEfetuadas_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            mtbDataFinal.Enabled = false;
            mtbDataInicial.Enabled = false;
            // instânciar cotações
            C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
            cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
            dtCotacao = taCotacao.CotacoesNaoCompradas();
            if (dtCotacao.Rows.Count > 0)
            {
                Carrega_Cotacoes(dtCotacao);
            }
            else
            {
                ListaCotacoes.Items.Clear();
                MessageBox.Show(" Não existem Cotações a apresentar...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPeriodo_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = true;
            mtbDataFinal.Enabled = true;
            mtbDataInicial.Enabled = true;
            ListaCotacoes.Items.Clear();
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

        private void mtbDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        public string DataI, DataF;

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

        private void mtbDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        public void Carrega_Cotacoes(DataTable dt)
        {
            string Teste;
            //Fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            //dt = ta.PesquisaFornecedorId(CodFornecedor);

            ListaCotacoes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');

                dtEmpresa = taEmpresa.PesquisaFornecedorId(int.Parse(dr[1].ToString()));
                item.SubItems.Add(dtEmpresa.Rows[0]["nome_empresa"].ToString()); //idforncedor
             //   item.SubItems.Add(dr[1].ToString()); //idforncedor

                item.SubItems.Add(string.Format("{0:d}", dr[2]).ToString());  // data sem hora
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda

                if (int.Parse(dr[4].ToString()) == 1)
                {
                    Teste = "Sim";
                }
                else
                {
                    Teste = "Não";
                }
                item.SubItems.Add(Teste);
                ListaCotacoes.Items.Add(item);
            }
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
                ListaCotacoes.Items.Clear();
                // Pesquisa será por período onde será informada data inicial e final...
                // instânciar cotações
                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                string DtInicial, DtFinal;
                mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação


                DtInicial = mtbDataInicial.Text;
                DtFinal = mtbDataFinal.Text;

                // MessageBox.Show(DtInicial + "   " + DtFinal);

                dtCotacao = taCotacao.CotacoesDeUmPeriodo(Convert.ToDateTime(DtInicial), Convert.ToDateTime(DtFinal));

                if (dtCotacao.Rows.Count > 0)
                {
                    Carrega_Cotacoes(dtCotacao);
                }
                else
                {
                    MessageBox.Show(" Não existem informações a apresentar para este período...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public string CodigoCotacao;
        public int Cont=0;
        public int[] Selecao = new int[20];

        private void ListaCotacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoCotacao = ListaCotacoes.SelectedItems[0].Text;
                
                ListaCotacoes.SelectedItems[0].BackColor = Color.Aquamarine;

                if (!Selecao.Contains(int.Parse(CodigoCotacao))) // preencher array para analise
                {
                    Cont = Cont + 1;
                    Selecao[Cont - 1] = int.Parse(CodigoCotacao); 
                }
                else // remove cotação da análise
                {
                      //descobrir localizacao no vetor array
                    int j = 0, Localizacao = 0;
                    for (j = 0; j < Cont; j++)
                    {
                        if (Selecao[j] == int.Parse(CodigoCotacao))
                        {
                            //MessageBox.Show(" Posicao => " + j + "   cod: " + CodigoCotacao);
                            Localizacao = j;
                            break;
                        }
                    }
                    Cont--;
                    if(Cont<2)
                    {
                        btnAnalisarCotacoes.Enabled = false;
                    }
                    for (int posicao = Localizacao; posicao < Cont; posicao++)
                    {
                        Selecao[posicao] = Selecao[posicao + 1];
                    }
                    ListaCotacoes.SelectedItems[0].BackColor = Control.DefaultBackColor;


                }

                if (Cont > 1)
                {
                    btnAnalisarCotacoes.Enabled = true;
                }
               
                //carregar itens cotados
                // instânciar itens cotados
                C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
                itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
                dtItensCotados = taItensCotados.ItensCotados(int.Parse(CodigoCotacao));
                Carrega_Itens_Cotados(dtItensCotados);
            }
            catch
            {

            }
        }

        public void Carrega_Itens_Cotados(DataTable dt)
        {
            //produtos
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();
            //            dtProduto = taProduto.PesquisaProdutoId(int.Parse(CodProduto));
  
            listaProdutosCotados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();

                //item.Text = dr[1].ToString().PadLeft(5, '0');
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dr[1].ToString()));
                item.Text = dtProduto.Rows[0]["nome"].ToString();
                item.SubItems.Add((String.Format("{0:f}", dr[2])).ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());  // preço formato moeda   

                listaProdutosCotados.Items.Add(item);
            }
        }

        public string CodigoFornecedor;

        private void ListaCotacoes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //mandar para editar
            try
            {
                CodigoCotacao = ListaCotacoes.SelectedItems[0].Text;
                ExibeCotacao();
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //mandar para editar
            ExibeCotacao();
        }

        public void ExibeCotacao()
        {
            if (int.Parse(CodigoCotacao) > 0)
            {
                // instânciar cotações
                C2W.c2wDataSet.cotacoesDataTable dtCotacao = new c2wDataSet.cotacoesDataTable();
                cotacoesTableAdapter taCotacao = new cotacoesTableAdapter();
                dtCotacao = taCotacao.PesquisaCotacaoID(int.Parse(CodigoCotacao));
                CodigoFornecedor = dtCotacao.Rows[0]["IdFornecedor"].ToString();
                //pegar fornecedor
                Cotacoes Editar = new Cotacoes(CodigoFornecedor, int.Parse(CodigoCotacao));
                Editar.ShowDialog();

                //this.ListaCotacoes.Refresh();

                dtCotacao = taCotacao.ListarTodasCotacoes();
                Carrega_Cotacoes(dtCotacao);

                //  Close();
            }
        }

        private void PesquisarCotacoesGeral_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnAnalisarCotacoes_Click(object sender, EventArgs e)
        {
            // array Selecao contém codigos de cotações selecionadas para análise...
            AnaliseDeCotacoes Ac = new AnaliseDeCotacoes(Selecao,Cont);
            Ac.ShowDialog();

            PesquisarCotacoesGeral Pcg = new PesquisarCotacoesGeral();
            Pcg.ShowDialog();
        }
        


    }
}
