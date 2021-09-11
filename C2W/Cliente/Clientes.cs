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
    public partial class Clientes : C2W.Frm_Base
    {
        public Clientes(string cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(cod);
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            
            if (CodigoGererico > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                txtNome.Enabled = false;
                txtNasceu.Enabled = false;
                txtCpf.Enabled = false;
                txtEmail.Enabled = false;
                txtFone1.Enabled = false;
                txtFone2.Enabled = false;
                txtCep.Enabled = false;
                txtEndereco.Enabled = false;
                txtComplemento.Enabled = false;
                txtBairro.Enabled = false;
                txtCidade.Enabled = false;
                cbEstado.Enabled = false;
                txtReferencia.Enabled = false;
                
            }
            else
            {
                txtNome.Focus();
            }
        }

        public override void CarregaValores()
        {
            // instanciar clientes
            C2W.c2wDataSet.clientesDataTable dtn = new c2wDataSet.clientesDataTable();
            clientesTableAdapter ta = new clientesTableAdapter();
            dtn = ta.PesquisaClienteId(CodigoGererico);
            if (dtn.Rows.Count > 0)
            {
                lbCodUsuario.Text = dtn.Rows[0]["Id"].ToString();
                txtNome.Text = dtn.Rows[0]["Nome"].ToString();
                txtNasceu.Text = dtn.Rows[0]["DT_Nasc"].ToString();
                txtCpf.Text = dtn.Rows[0]["cpf"].ToString();
                txtEmail.Text = dtn.Rows[0]["e_mail"].ToString();
                txtFone1.Text = dtn.Rows[0]["fone1"].ToString();
                txtFone2.Text = dtn.Rows[0]["fone2"].ToString();
                txtCep.Text = dtn.Rows[0]["cep"].ToString();
                txtEndereco.Text = dtn.Rows[0]["endereco"].ToString();
                txtComplemento.Text = dtn.Rows[0]["complemento"].ToString();
                txtBairro.Text = dtn.Rows[0]["bairro"].ToString();
                txtCidade.Text = dtn.Rows[0]["cidade"].ToString();
                cbEstado.Text = dtn.Rows[0]["estado"].ToString();
                txtReferencia.Text = dtn.Rows[0]["referencia"].ToString();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
              //  txtNome.Text = txtNome.Text.ToUpper();
                if (txtNome.Text == "")
                {
                    MessageBox.Show(" Entre com a informação solicitada... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else
                {
                    txtNasceu.Focus();
                }
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtNome.Text = txtNome.Text.ToUpper();
        }

        public string data;

        private void txtNasceu_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);

            if (e.KeyCode == Keys.Enter  )
            {
                txtNasceu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                data = txtNasceu.Text;
                if (data.Length < 8)
                {
                    MessageBox.Show(" Entre com a informação solicitada... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNasceu.Focus();
                }
                else
                {
                    txtCpf.Focus();
                }
            }
            //DateTime dt = DateTime.ParseExact(txtNasceu.Text, "dd/MM/yyyy", null);
            //MessageBox.Show("data: " + txtNasceu.Text + "   numero de caracters informados  " + data.Length);
            //    txtNasceu.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

            
            //    else
            //    {
            //        p1 = txtNasceu.Text.Substring(0, 2);  //p1 é a variável que controla o dia do mes
            //        p2 = txtNasceu.Text.Substring(2, 2);  //p2 controla o numero do mes
            //        p3 = txtNasceu.Text.Substring(4, 4);   //p3 controla o numero do ano
            //        if ( int.Parse(p3) < 1900)
            //        {
            //            MessageBox.Show(" Ano de nascimento inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            txtNasceu.Focus();
            //        }
            //        else
            //        {
            //            if ( int.Parse(p2) < 1 || int.Parse(p2) > 12)
            //            {
            //                MessageBox.Show(" Mês de nascimento inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                txtNasceu.Focus();
            //            }
            //            else
            //            {
            //                if (int.Parse(p1) < 1 || int.Parse(p1) > 31 )
            //                {
            //                    MessageBox.Show(" Dia de nascimento inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    txtNasceu.Focus();
            //                }
            //                else
            //                {

            //                    txtCpf.Focus();
            //                }
            //            }
            //        }
            //    }

        }

        private void txtCpf_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);

            //    txtCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCpf.Text == "" || txtCpf.Text.Length < 11)
                {
                    MessageBox.Show(" Entre com a informação solicitada... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpf.Focus();
                }
                else
                {
                    txtEmail.Focus();
                }
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFone1.Focus();                               
            }
        }

        private void txtFone1_KeyDown(object sender, KeyEventArgs e)
        {
            txtFone1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            if (e.KeyCode == Keys.Enter)
            {
                txtFone2.Focus();
            }
        }

        private void txtFone2_KeyDown(object sender, KeyEventArgs e)
        {
            txtFone2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            if (e.KeyCode == Keys.Enter)
            {
                txtCep.Focus();
            }
        }

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            txtCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            if (e.KeyCode == Keys.Enter)
            {
                txtEndereco.Focus();
            }
        }

        private void txtEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComplemento.Focus();
            }
        }

        private void txtComplemento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBairro.Focus();
            }
        }

        private void txtBairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCidade.Focus();
            }
        }

        private void txtCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbEstado.Focus();
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReferencia.Focus();
        }

       

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }
 
        private void txtNasceu_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
           
        }

        private void txtFone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtFone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        public string d0, d1, d2, d3, d4, d5, d6, d7;  // variáveis usadas para ler cada dígito da data

       

        public override bool Salvar()
        {
            bool bSalvar = false;
            // instanciar clientes
            C2W.c2wDataSet.clientesDataTable dt = new c2wDataSet.clientesDataTable();
            clientesTableAdapter ta = new clientesTableAdapter();
 
            //__________ Validando CPF

            dt = ta.PesquisaCliente_PeloCPF(txtCpf.Text);
            if (!ValidarCPF(txtCpf.Text, lbCodUsuario.Text, dt))   // chama no form base a função que valida ou não o CPF
            {
                MessageBox.Show(" Campo Obrigatório... CPF Inválido ou já existente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Focus();
                return bSalvar;
            }

            //__________ Validando Data inserida
            txtNasceu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            data = txtNasceu.Text;
            if(!ValidarData(data))     // chama no form base a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNasceu.Focus();
                return bSalvar;
            }
            // fim da validação da data de nascimento...______________________________________________

            txtNasceu.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
            if (Status == StatusCadastro.scInserindo || lbCodUsuario.Text == "-1")
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show(" Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else
                {
                    bSalvar = (ta.Insert(txtNome.Text, Convert.ToDateTime( txtNasceu.Text ), txtCpf.Text, txtEmail.Text, txtFone1.Text, txtFone2.Text,
                        txtCep.Text, txtEndereco.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text,
                        txtReferencia.Text) > 0);  
                }
            }
            // alterarando dados de clientes
            if (Status == StatusCadastro.scEditando)
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show(" Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                    CarregaValores();
                }
                else
                {
                    bSalvar = (ta.AlterarClientes(txtNome.Text, Convert.ToDateTime(txtNasceu.Text), txtCpf.Text, txtEmail.Text, txtFone1.Text, txtFone2.Text,
                    txtCep.Text, txtEndereco.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text,
                    txtReferencia.Text, CodigoGererico) > 0);
                }
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

            MessageBox.Show(" Exclusão de Clientes temporariamente desativada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // // instanciar clientes
            // C2W.c2wDataSet.clientesDataTable dt = new c2wDataSet.clientesDataTable();
            // clientesTableAdapter ta = new clientesTableAdapter();
            // bExcluir = (ta.ExcluirCliente(CodigoGererico) > 0);
            // txtEmail.Text = "";
            // txtFone1.Text = "";
            // txtFone2.Text = "";
            // txtCep.Text = "";
            // txtEndereco.Text = "";
            // txtComplemento.Text = "";
            // txtBairro.Text = "";
            // txtCidade.Text = "";
            //// txtEstado.Text = "";
            // txtReferencia.Text = "";
            LimparControles();
            lbCodUsuario.Text = "-1";
            Close();
            return bExcluir;
        }
  
        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtNome.Enabled = true;
            txtNasceu.Enabled = true;
            txtCpf.Enabled = true;
            txtEmail.Enabled = true;
            txtFone1.Enabled = true;
            txtFone2.Enabled = true;
            txtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
            txtReferencia.Enabled = true;
            return bLocalizar;
        }
      // fim da rotina clientes...
    }
}
