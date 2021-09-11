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
    public partial class Ofertas : C2W.Frm_Base
    {
        public int CodigoOferta,Teste=1;
        public string CodigoProduto;

        public Ofertas(string CodOferta)
        {
            InitializeComponent();
            CodigoOferta = int.Parse(CodOferta);
        }




        //analisar query listar todos os produtos? OU APENAS COM ESTOQUE X MAIS ALTO
        // seria interessante estipular um critério?
        // perguntar ao márcio

        private void Ofertas_Load(object sender, EventArgs e)
        {
            if (CodigoOferta > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
            }
            txtInicioOferta.Enabled = false;
            txtFimOferta.Enabled = false;
            txtValorOfertado.Enabled = false;
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.ListarProdutos();
            Carrega_Produtos(dt);
            if (Status == StatusCadastro.scEditando)
            {
                txtPesquisar.Enabled = false;
                btnPesquisar.Enabled = false;
                ListaProdutos.Enabled = false;
                txtInicioOferta.Focus();
            }
            else
            {
                ListaProdutos.Enabled = true;
                txtPesquisar.Focus();
            }
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar.Focus();
            }
        }

        public override void CarregaValores() //da oferta
        {
            C2W.c2wDataSet.produtosDataTable dtProduto = new c2wDataSet.produtosDataTable();
            produtosTableAdapter taProduto = new produtosTableAdapter();

            // instanciar ofertas
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();
            dtOferta = taOferta.PesquisaOfertaId(CodigoOferta);
            if (dtOferta.Rows.Count > 0)
            {
                lbCodOferta.Text = dtOferta.Rows[0]["Id"].ToString();
                dtProduto = taProduto.PesquisaProdutoId(int.Parse(dtOferta.Rows[0]["idproduto"].ToString()));
                lblProduto.Text = dtProduto.Rows[0]["Nome"].ToString();
                txtInicioOferta.Text = dtOferta.Rows[0]["dataInicial"].ToString();
                txtFimOferta.Text = dtOferta.Rows[0]["dataFinal"].ToString();
                lblValorVenda.Text = dtOferta.Rows[0]["valor_venda"].ToString();
                txtValorOfertado.Text = dtOferta.Rows[0]["valor_oferta"].ToString();
            }
        }

        public void Carrega_Produtos(DataTable dt)
        {
            ListaProdutos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
               // item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                item.SubItems.Add((String.Format("{0:f3}", dr[4]).ToString)());  //estoque com 3 casas decimais

                ListaProdutos.Items.Add(item);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.PesquisaNome("%" + txtPesquisar.Text + "%");
            if (dt.Rows.Count > 0)
            {
                Carrega_Produtos(dt);
            }
            else
            {
                MessageBox.Show(" Não há informações a serem exibidas para esta pesquisa...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                ExibirProduto();
            }
            catch
            {

            }
        }

        private void ListaProdutos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoProduto = ListaProdutos.SelectedItems[0].Text;
                ExibirProduto();
            }
            catch
            {

            }
        }

        
        
        // antes de exibir o produto selecionado pensei em pesquisar o idproduto para saber se já existe 
        // alguma oferta em andamento, porém a mesma poderá estar vencida.
        // Então surge a questão: É viável essa consulta ou não?
        // discutir em reunião...

        public void ExibirProduto()
        {
            C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
            unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();

            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.PesquisaProdutoId(int.Parse(CodigoProduto));
            if (dt.Rows.Count > 0)
            {
//                Carrega_Produtos(dt);
                lblProduto.Text = dt.Rows[0]["nome"].ToString();
                lblValorVenda.Text = dt.Rows[0]["valor_venda"].ToString();
                
                dtUM = taUM.PesquisaUnidadeId(int.Parse(dt.Rows[0]["IdUM"].ToString()));

                lblEstoqueAtual.Text = dt.Rows[0]["volume_estocado"].ToString() + "  " + dtUM.Rows[0]["Nome"].ToString() + "  (s)";

                txtInicioOferta.Text = "";
                txtFimOferta.Text = "";
                txtValorOfertado.Text = "";
                txtPesquisar.Text = "";
                ListaProdutos.Enabled = false;
                txtInicioOferta.Enabled = true;
                txtFimOferta.Enabled = true;
                txtValorOfertado.Enabled = true;
                txtInicioOferta.Focus();
            }
        }
                
        private void ListaProdutos_MouseClick(object sender, MouseEventArgs e)
        {
            ListaProdutos.Enabled = true;
        }

        private void txtInicioOferta_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);

            //MessageBox.Show(e.KeyCode.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                txtInicioOferta.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = txtInicioOferta.Text;
                if (!ValidarData(data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInicioOferta.Focus();
                }
                else
                {
                    txtFimOferta.Focus();
                }
            }
        }

        private void txtInicioOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        public string DataI, DataF;

        private void txtFimOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }
     
        private void txtFimOferta_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtFimOferta.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                DataF = txtFimOferta.Text;
                if (!ValidarData(DataF))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFimOferta.Focus();
                }
                else
                {
                    txtInicioOferta.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // devolve a formatação
                    txtFimOferta.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //              string DataI, DataF;
                    DataI = txtInicioOferta.Text;
                    DataF = txtFimOferta.Text;

                    // MessageBox.Show(DataI + "   " + DataF);


                    if (Convert.ToDateTime(DataF) > Convert.ToDateTime(DataI))
                    {
                        txtValorOfertado.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" Data Inválida...A data FINAL deverá ser superior a data INICIAL da Oferta...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFimOferta.Text = "";
                        txtFimOferta.Focus();
                    }
                }
            }
        }

        private void txtValorOfertado_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
        }

        private void txtValorOfertado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Status == StatusCadastro.scEditando && Teste == 1)
            {
                txtValorOfertado.Text = "";
                Teste = 0;
            }
            // Campo valor configurado para aceitar somente números, uma vírgula e duas casas decimais.
            FormatarMoeda(sender, e);
        }

        public override bool Salvar()
        {
            bool bsalvar = false;

            // instanciar ofertas
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();

                  
            //__________ Validando Datas inseridas
            txtInicioOferta.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            DataI = txtInicioOferta.Text;
            if (!ValidarData(DataI))     // chama no form base a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInicioOferta.Focus();
                return bsalvar;
            }
            txtInicioOferta.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

            txtFimOferta.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            DataF = txtFimOferta.Text;
            if (!ValidarData(DataF))     // chama no form base a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFimOferta.Focus();
                return bsalvar;
            }
            txtFimOferta.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

            DataI = txtInicioOferta.Text;
            DataF = txtFimOferta.Text;

            if (Status == StatusCadastro.scInserindo || lbCodOferta.Text == "-1")
            {

                if (DateTime.Today > Convert.ToDateTime(DataI))
                {
                    MessageBox.Show(" A Data informada para início de oferta é Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInicioOferta.Text = "";
                    txtInicioOferta.Focus();
                    return bsalvar;
                }
            }
            if (Convert.ToDateTime(DataF) < Convert.ToDateTime(DataI))
            {
                MessageBox.Show(" Data Inválida...A data FINAL deverá ser superior a data INICIAL da Oferta...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFimOferta.Text = "";
                txtFimOferta.Focus();
                return bsalvar;
            }
            // fim da validação da data ______________________________________________


            double Taxa,ValorOferta,ValorVenda;
            ValorVenda = Convert.ToDouble(lblValorVenda.Text);

            if(txtValorOfertado.Text=="" || txtValorOfertado.Text==",")
            {
                txtValorOfertado.Text = "0";
            }
            ValorOferta = Convert.ToDouble(txtValorOfertado.Text);
           
            // Validar valor da oferta
            if (txtValorOfertado.Text == "" || txtValorOfertado.Text == "," || ValorOferta < 0.01 || ValorOferta >= ValorVenda)
            {
                MessageBox.Show(" Valor de Oferta Inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValorOfertado.Focus();
                return bsalvar;
            }
           

            Taxa = (100 - (ValorOferta / ValorVenda) * 100);

           // MessageBox.Show(" Taxa de desconto na Oferta =>  " + Taxa);

            if (Status == StatusCadastro.scInserindo || lbCodOferta.Text == "-1")
            {
                bsalvar = (taOferta.Insert(int.Parse(CodigoProduto), Convert.ToDateTime(txtInicioOferta.Text), Convert.ToDateTime(txtFimOferta.Text), Convert.ToDouble(lblValorVenda.Text), Convert.ToDouble(txtValorOfertado.Text),Taxa) > 0);
            }
            if (Status == StatusCadastro.scEditando)
            {
                bsalvar = (taOferta.AlterarOferta(Convert.ToDateTime(txtInicioOferta.Text), Convert.ToDateTime(txtFimOferta.Text), Convert.ToDecimal(txtValorOfertado.Text), Convert.ToDecimal(Taxa), CodigoOferta) > 0);
                // alterar oferta
            }
            if (bsalvar)
            {
                lbCodOferta.Text = "-1";
                LimparControles();
                Close();
            }
            return bsalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // instanciar ofertas
            C2W.c2wDataSet.ofertasDataTable dtOferta = new c2wDataSet.ofertasDataTable();
            ofertasTableAdapter taOferta = new ofertasTableAdapter();

            bExcluir = (taOferta.ExcluirOferta(CodigoOferta) > 0);

            lbCodOferta.Text = "-1";
            LimparControles();
            Close();
            return bExcluir;
        }

        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtInicioOferta.Enabled = true;
            txtFimOferta.Enabled = true;
            txtValorOfertado.Enabled = true;
            return bLocalizar;
        }





    }
}
