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
    public partial class Fornecedores : C2W.Frm_Base
    {
        public Fornecedores(string Cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(Cod);
        }

      

        private void Fornecedores_Load(object sender, EventArgs e)
        {
            if (CodigoGererico > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                txtEmpresa.Enabled = false;
                txtCnpj.Enabled = false;
                txtInscricao.Enabled = false;
                txtRepresentante.Enabled = false;
                txtEmail.Enabled = false;
                txtFone1.Enabled = false;
                txtFone2.Enabled = false;
                txtCep.Enabled = false;
                txtEndereco.Enabled = false;
                txtComplemento.Enabled = false;
                txtBairro.Enabled = false;
                txtCidade.Enabled = false;
                cbEstado.Enabled = false;
                txtObservacao.Enabled = false;
            }
            else
            {
                txtEmpresa.Focus();
            }
        }

        public override void CarregaValores()
        {
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();
            
            dt = ta.PesquisaFornecedorId(CodigoGererico);

            if (dt.Rows.Count > 0)
            {
                lbCodUsuario.Text = dt.Rows[0]["Id"].ToString();
                txtEmpresa.Text = dt.Rows[0]["nome_Empresa"].ToString();
                txtCnpj.Text = dt.Rows[0]["cnpj"].ToString();
                txtInscricao.Text = dt.Rows[0]["inscricao_estadual"].ToString();
                txtRepresentante.Text = dt.Rows[0]["nome_vendedor"].ToString();
                txtEmail.Text = dt.Rows[0]["e_mail"].ToString();
                txtFone1.Text = dt.Rows[0]["fone1"].ToString();
                txtFone2.Text = dt.Rows[0]["fone2"].ToString();
                txtCep.Text = dt.Rows[0]["cep"].ToString();
                txtEndereco.Text = dt.Rows[0]["endereco"].ToString();
                txtComplemento.Text = dt.Rows[0]["complemento"].ToString();
                txtBairro.Text = dt.Rows[0]["bairro"].ToString();
                txtCidade.Text = dt.Rows[0]["cidade"].ToString();
                cbEstado.Text = dt.Rows[0]["estado"].ToString();
                txtObservacao.Text = dt.Rows[0]["observacao"].ToString();
            }
        }

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtEmpresa.Text == "AUTONOMO")
                {
                    txtRepresentante.Focus();
                }
                else
                {
                    if (txtEmpresa.Text == "")
                    {
                        txtEmpresa.Text = "AUTONOMO";
                        txtRepresentante.Focus();
                    }
                    else
                    {
                        txtCnpj.Focus();
                    }
                }
            }
        }

        private void txtCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtInscricao.Focus();
            }

        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtInscricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtRepresentante.Focus();
            }
        }

        private void txtInscricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtRepresentante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtRepresentante.Text == "")
                {
                    MessageBox.Show(" Entre com a informação solicitada... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRepresentante.Focus();
                }
                else
                {
                    txtEmail.Focus();
                }
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtFone1.Focus();
            }
        }

        private void txtFone1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtFone2.Focus();
            }
        }

        private void txtFone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtFone2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtCep.Focus();
            }
        }

        private void txtFone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtEndereco.Focus();
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtComplemento.Focus();
            }
        }

        private void txtComplemento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtBairro.Focus();
            }
        }

        private void txtBairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtCidade.Focus();
            }
        }

        private void txtCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
               cbEstado.Focus();
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObservacao.Focus();
        }

        

        public override bool Salvar()
        {
            bool bSalvar = false;
            // instanciar fornecedores
            C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter ta = new fornecedoresTableAdapter();


            //tratar cnpj
            txtCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação

            dt = ta.PesquisaCNPJ(txtCnpj.Text);
            if (!ValidarCnpj(txtCnpj.Text, lbCodUsuario.Text, dt))
            {
                MessageBox.Show(" CNPJ Inválido ou já Cadastrado...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCnpj.Focus();
                return bSalvar;
            }
            if (txtRepresentante.Text == "")
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                MessageBox.Show(" Representante é um campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepresentante.Focus();
                return bSalvar;
            }
            if (txtFone1.Text == "")
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                MessageBox.Show(" Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFone1.Focus();
                return bSalvar;
            }
           
            if (Status == StatusCadastro.scInserindo || lbCodUsuario.Text == "-1")
            {
                bSalvar = (ta.Insert(txtEmpresa.Text, txtCnpj.Text, txtInscricao.Text, txtRepresentante.Text,
                   txtEmail.Text, txtFone1.Text, txtFone2.Text,txtCep.Text, txtEndereco.Text, txtComplemento.Text,
                    txtBairro.Text, txtCidade.Text, cbEstado.Text,txtObservacao.Text) > 0);
            }
            // alterarando dados de clientes
            if (Status == StatusCadastro.scEditando)
            {
                bSalvar = (ta.AlterarFornecedor(txtEmpresa.Text, txtCnpj.Text, txtInscricao.Text, txtRepresentante.Text,
                        txtEmail.Text, txtFone1.Text, txtFone2.Text, txtCep.Text, txtEndereco.Text, txtComplemento.Text,
                        txtBairro.Text, txtCidade.Text, cbEstado.Text, txtObservacao.Text, CodigoGererico) > 0);
            }
            if (bSalvar)
            {
                LimparControles();
                lbCodUsuario.Text = "-1";
                Close();
            }
            return bSalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;

            MessageBox.Show(" Exclusão de Fornecedores desativada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //// instanciar fornecedores
            //C2W.c2wDataSet.fornecedoresDataTable dt = new c2wDataSet.fornecedoresDataTable();
            //fornecedoresTableAdapter ta = new fornecedoresTableAdapter();

            //bExcluir = (ta.ExcluirFornecedor(CodigoGererico) > 0);

            //LimparControles();
            //lbCodUsuario.Text = "-1";
            //txtEmail.Text = "";
            //txtFone1.Text = "";
            //txtFone2.Text = "";
            //txtCep.Text = "";
            //txtEndereco.Text = "";
            //txtComplemento.Text = "";
            //txtBairro.Text = "";
            //txtCidade.Text = "";
            ////cbEstado.Text = "";
            //txtObservacao.Text = "";
            Close();

            return bExcluir;
        }

        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtEmpresa.Enabled = true;
            txtCnpj.Enabled = true;
            txtInscricao.Enabled = true;
            txtRepresentante.Enabled = true;
            txtEmail.Enabled = true;
            txtFone1.Enabled = true;
            txtFone2.Enabled = true;
            txtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
            txtObservacao.Enabled = true;
            return bLocalizar;
        }

        
    }
}
