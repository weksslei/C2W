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
    public partial class Produtos : C2W.Frm_Base
    {
        public Produtos(string Cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(Cod);
        }

        public int Cont=0;
        public string Descricao1;

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(Status==StatusCadastro.scNavegando)
                {
                    if (Cont == 0)
                    {
                        Descricao1 = txtNome.Text;
                        MessageBox.Show(" Favor digitar novamente o nome do produto para confirmar...");
                        txtNome.Text = "";
                        txtNome.Focus();
                    }
                    if (Cont==1)
                    {
                        if (Descricao1 == txtNome.Text)
                        {
                            txtValor.Focus();
                        }
                        else
                        {
                            MessageBox.Show("  Nome do produto não foi validado para continuar... Refaça a operação...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNome.Text = "";
                            Descricao1 = "";
                            txtNome.Focus();
                        }
                    }
                }
                Cont++;
                if(Cont==2)
                {
                    Cont = 0;
                }
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtNivel.Focus();
            }
        }

        private void txtNivel_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtEstoque.Focus();
            }
        }

        private void txtEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                cbGrupo.Focus();
            }
        }

        public int Teste = 1;

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Status == StatusCadastro.scEditando && Teste == 1)
            {
                txtValor.Text = "";
                Teste = 0;
            }
            //funcao
            FormatarMoeda(sender,e);
        }

        private void txtNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        public void Popular_CBox()
        {
            cbGrupo.Items.Clear();
            cbUnidade.Items.Clear();
            //popular combobox grupo e unidade de medida
            C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
            gruposTableAdapter taGrupos = new gruposTableAdapter();
            dtGrupos = taGrupos.ListarGrupos();
            if (dtGrupos != null)
            {
                for (int i = 0; i < dtGrupos.Rows.Count; i++)
                {
                    cbGrupo.Items.Add(dtGrupos.Rows[i]["nome"].ToString());
                }
            }

            C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
            unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();
            dtUM = taUM.ListarUnidadesMedida();
            if (dtUM != null)
            {
                for (int i = 0; i < dtUM.Rows.Count; i++)
                {

                    cbUnidade.Items.Add(dtUM.Rows[i]["Nome"].ToString());
                }
            }
        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            Popular_CBox();
            if (CodigoGererico > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                txtNome.Enabled = false;
                txtValor.Enabled = false;
                txtNivel.Enabled = false;
                txtEstoque.Enabled = false;
                cbGrupo.Enabled = false;
                cbUnidade.Enabled = false;
                btnManterGrupos.Enabled = false;
            }
            else
            {
                txtNome.Focus();
            }
        }

        public override void CarregaValores()
        {
            C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
            gruposTableAdapter taGrupos = new gruposTableAdapter();

            C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
            unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();

            // instanciar produtos
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();
            dt = ta.PesquisaProdutoId(CodigoGererico);
            if (dt.Rows.Count > 0)
            {
                lbCodProduto.Text = dt.Rows[0]["Id"].ToString();
                txtNome.Text = dt.Rows[0]["Nome"].ToString();
                txtNivel.Text = dt.Rows[0]["nivel"].ToString();
                txtValor.Text = dt.Rows[0]["valor_venda"].ToString();
                txtEstoque.Text = dt.Rows[0]["volume_Estocado"].ToString();

                //pesquisa grupo
                dtGrupos=taGrupos.PesquisaGrupoId(int.Parse(dt.Rows[0]["IdGrupo"].ToString()));
                if (dtGrupos.Rows.Count > 0)
                {
                    cbGrupo.Text = dtGrupos.Rows[0]["Nome"].ToString();
                }

                //pesquisa unidade
                dtUM = taUM.PesquisaUnidadeId(int.Parse(dt.Rows[0]["IdUM"].ToString()));
                if (dtUM.Rows.Count > 0)
                {
                    cbUnidade.Text = dtUM.Rows[0]["Nome"].ToString();
                }
            }
        }

        public override bool Salvar()
        {
            bool bsalvar = false;

            // instanciar produtos
            C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            produtosTableAdapter ta = new produtosTableAdapter();

            
            // Validar valor de venda de um produto
            if (txtValor.Text == "" || txtValor.Text == ",")
            {
                txtValor.Text= "0";
            }
            // Validar nível mínimo de estoque de um produto
            if (txtNivel.Text == "")
            {
                txtNivel.Text = "0";
            }
            // Validar Estoque inicial de um produto
            if (txtEstoque.Text == "" || txtValor.Text == ",")
            {
                txtEstoque.Text = "0";
            }
            if(CodigoGrupo < 1)
            {
                MessageBox.Show(" Selecione um Grupo...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbGrupo.Focus();
                return bsalvar;
            }
            if(CodigoUnidade < 1)
            {
                MessageBox.Show(" Selecione uma Unidade de Medida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbUnidade.Focus();
                return bsalvar;
            }
            if (Status == StatusCadastro.scInserindo || lbCodProduto.Text == "-1")
            {
                if (txtNome.Text == "" || txtNome.Text != Descricao1)
                {
                    MessageBox.Show(" Nome do produto em branco ou inválido... Refaça a operação...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbUnidade.Text = "";
                    cbGrupo.Text = "";
                    CodigoGrupo = 0;
                    CodigoUnidade = 0;
                    Popular_CBox();

                    Cont = 0;
                    Descricao1 = "";
                    txtNome.Text = "";
                    txtNome.Focus();
                    return bsalvar;
                }
                else
                {
                    bsalvar = (ta.Insert(txtNome.Text, int.Parse(txtNivel.Text), Convert.ToDouble(txtValor.Text), Convert.ToDouble(txtEstoque.Text), CodigoGrupo, CodigoUnidade) > 0);
                }
            }
            if (Status == StatusCadastro.scEditando)
            {
                bsalvar = (ta.AlterarProduto( int.Parse(txtNivel.Text), Convert.ToDecimal(txtValor.Text), CodigoGrupo, CodigoUnidade, CodigoGererico) > 0);
                // alterar produto
            }
            if (bsalvar)
            {
                lbCodProduto.Text = "-1";
                LimparControles();
                Close();
            }
            return bsalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;

            MessageBox.Show(" Exclusão de Produtos desativada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //   // instanciar produtos
            //   C2W.c2wDataSet.produtosDataTable dt = new c2wDataSet.produtosDataTable();
            //   produtosTableAdapter ta = new produtosTableAdapter();

            ////   bExcluir = (ta.ExcluirProduto(CodigoGererico) > 0);

            lbCodProduto.Text = "-1";
            LimparControles();
            Close();
            return bExcluir;
        }

        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtNivel.Enabled = true;
            txtValor.Enabled = true;
            cbGrupo.Enabled = true;
            cbUnidade.Enabled = true;
            btnManterGrupos.Enabled = true;
            return bLocalizar; 
        }

        public int CodigoGrupo, CodigoUnidade, Contado=0;
        public string Descricao2;

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pegar o codigo do grupo
            C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
            gruposTableAdapter taGrupos = new gruposTableAdapter();
            dtGrupos = taGrupos.GrupoEscolhido(cbGrupo.SelectedItem.ToString());
            if(dtGrupos.Rows.Count == 1)
            {
                CodigoGrupo = int.Parse(dtGrupos.Rows[0]["id"].ToString());
     //           MessageBox.Show("  id escolhido => " + CodigoGrupo);
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pegar o codigo da unidade de medida
            C2W.c2wDataSet.unidademedidasDataTable dtUM = new c2wDataSet.unidademedidasDataTable();
            unidademedidasTableAdapter taUM = new unidademedidasTableAdapter();
            dtUM = taUM.UnidadeEscolhida(cbUnidade.SelectedItem.ToString());
            if (dtUM.Rows.Count == 1)
            {
                CodigoUnidade = int.Parse(dtUM.Rows[0]["id"].ToString());
                //          MessageBox.Show("  id escolhido => " + CodigoUnidade);
            }
        }

        public bool NovoGrupoValido = false;

        private void txtNovoGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ValidarGrupo();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNovoGrupo.Text = "";
            Descricao2 = "";
            Contador = 0;
            NovoGrupo.Visible = false;
        }

        private void btnSalvarNovoGrupo_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.gruposDataTable dtGrupos = new c2wDataSet.gruposDataTable();
            gruposTableAdapter taGrupos = new gruposTableAdapter();

            dtGrupos = taGrupos.GrupoEscolhido(txtNovoGrupo.Text);
            if (txtNovoGrupo.Text != "")
            {
                if (NovoGrupoValido)
                {
                    if (dtGrupos.Rows.Count == 0)
                    {

                        taGrupos.Insert(txtNovoGrupo.Text);
                        MessageBox.Show(" Informações Salvas com sucesso...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NovoGrupo.Visible = false;
                        Popular_CBox();
                        NovoGrupoValido = false;
                        cbGrupo.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" Grupo já existente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ValidarGrupo();
                }
            }
            else
            {
                MessageBox.Show(" Informe nome para novo grupo...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNovoGrupo.Focus();
            }
        }

        private void btnManterGrupos_Click(object sender, EventArgs e)
        {
            // inserir novo grupos
            NovoGrupo.Visible = true;
            txtNovoGrupo.Focus();
        }

        public void ValidarGrupo()
        {
            if (Contado == 0)
            {
                Descricao2 = txtNovoGrupo.Text;
                MessageBox.Show(" Favor digitar novamente o nome do grupo para confirmar...");
                txtNovoGrupo.Text = "";
                txtNovoGrupo.Focus();
            }
            if (Contado == 1)
            {
                if (Descricao2 == txtNovoGrupo.Text)
                {
                    NovoGrupoValido = true;
                    btnSalvarNovoGrupo.Focus();
                }
                else
                {
                    MessageBox.Show("  Nome do grupo não foi validado para continuar... Refaça a operação...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNovoGrupo.Text = "";
                    Descricao2 = "";
                    txtNovoGrupo.Focus();
                }
            }
            Contado++;
            if (Contado == 2)
            {
                Contado = 0;
            }
        }

    }
}
