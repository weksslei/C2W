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
    public partial class Usuarios : C2W.Frm_Base
    {
       
        public Usuarios(string Cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(Cod);
        }

        public byte p1, p2, p3, p4, p5, p6, p7, p8, p9;
        public int VeAut; // VerificarAutorizacao

        private void Usuarios_Load(object sender, EventArgs e)
        {
            if (CodigoGererico > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                txtNome.Enabled = false;
                txtCpf.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
            }
            else
            {
                txtNome.Focus();
            }
        }

        public override void CarregaValores()
        {
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();

            dt = ta.PesquisaId(CodigoGererico);


            if (dt.Rows.Count > 0)
            {
                lbCodUsuario.Text = dt.Rows[0]["Id"].ToString();
                txtNome.Text = dt.Rows[0]["Nome"].ToString();
                txtCpf.Text = dt.Rows[0]["cpf"].ToString();
                txtUsuario.Text = dt.Rows[0]["usuario"].ToString();
                txtSenha.Text = dt.Rows[0]["senha"].ToString();
                VeAut = int.Parse(dt.Rows[0]["Autorizado"].ToString());
                if (VeAut == 0)
                {
                    rbNao.Checked = true;
                    rbSim.Checked = false;
                }
                if (VeAut == 1)
                {
                    rbNao.Checked = false;
                    rbSim.Checked = true;
                }
            }


            // carregar permissoes do usuario
            C2W.c2wDataSet.permissoesDataTable dtp = new c2wDataSet.permissoesDataTable();
            permissoesTableAdapter tap = new permissoesTableAdapter();
            dtp = tap.PermitidoOperar(int.Parse(lbCodUsuario.Text));
            p1 = Convert.ToByte(dtp.Rows[0]["at_gerenciais"].ToString());
            p2 = Convert.ToByte(dtp.Rows[0]["clientes"].ToString());
            p3 = Convert.ToByte(dtp.Rows[0]["produtos"].ToString());
            p4 = Convert.ToByte(dtp.Rows[0]["orcamentos"].ToString());
            p5 = Convert.ToByte(dtp.Rows[0]["pedidos"].ToString());
            p6 = Convert.ToByte(dtp.Rows[0]["entregas"].ToString());
            p7 = Convert.ToByte(dtp.Rows[0]["requisicoes"].ToString());
            p8 = Convert.ToByte(dtp.Rows[0]["despesas"].ToString());
            p9 = Convert.ToByte(dtp.Rows[0]["backup"].ToString());

            if (p1 == 1) { cbAtividadesGerenciais.Checked = true; } else { cbAtividadesGerenciais.Checked = false; }   // mostrar permissoes
            if (p2 == 1) { cbClientes.Checked = true; } else { cbClientes.Checked = false; }   // que o gerente concedeu
            if (p3 == 1) { cbProdutos.Checked = true; } else { cbProdutos.Checked = false; }   //  para este usuário
            if (p4 == 1) { cbOrcamentos.Checked = true; } else { cbOrcamentos.Checked = false; }   // que está inserido
            if (p5 == 1) { cbPedidos.Checked = true; } else { cbPedidos.Checked = false; }   // na base de dados.
            if (p6 == 1) { cbEntregas.Checked = true; } else { cbEntregas.Checked = false; }   // de p1 a p9 temos todas as 
            if (p7 == 1) { cbRequisicoes.Checked = true; } else { cbRequisicoes.Checked = false; }   // permissoes possíveis de serem
            if (p8 == 1) { cbDespesas.Checked = true; } else { cbDespesas.Checked = false; }   // concedidas.
            if (p9 == 1) { cbBackup.Checked = true; } else { cbBackup.Checked = false; }   // ____Alterar se quiser__________//


        }

      
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show(" Favor informar Nome... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else
                {
                    txtCpf.Enabled = true;
                    txtCpf.Focus();
                }
            }
        }
       
        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
            
        }

        private void txtCpf_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            txtCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCpf.Text == "" || txtCpf.Text.Length < 11)
                {
                    MessageBox.Show(" Favor informar CPF... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpf.Focus();
                }
                else
                {
                    txtUsuario.Enabled = true;
                    txtUsuario.Focus();
                }
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Enabled = true;
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbSim.Focus();
            }
        }

       
        public int CopiaIdUsuario;

   
        public override bool Salvar()
        {
            bool bsalvar = false;
            // instanciar usuarios 
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();

           
            // instanciar permissoes de usuarios
            C2W.c2wDataSet.permissoesDataTable dtp = new c2wDataSet.permissoesDataTable();
            permissoesTableAdapter tap = new permissoesTableAdapter();

            if (txtNome.Text == "" || txtCpf.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
            {
                if (Status == StatusCadastro.scEditando)
                {
                    MessageBox.Show(" Alteração não permitida... Preencher campos Obrigatórios...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CarregaValores();
                    return bsalvar;
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show(" Favor informar Nome... Campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return bsalvar;
            }

            //__________ Validando CPF

            dt = ta.PesquisaCPF(txtCpf.Text);
            if (!ValidarCPF(txtCpf.Text, lbCodUsuario.Text, dt))   // chama no form base a função que valida ou não o CPF
            {
                MessageBox.Show(" Campo Obrigatório... CPF Inválido ou já existente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Focus();
                return bsalvar;
            }

            if (txtUsuario.Text == "")
            {
                MessageBox.Show(" Usuário é campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return bsalvar;
            }



            if (txtSenha.Text == "")
            {
                MessageBox.Show(" Senha é campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return bsalvar;
            }

            if (cbAtividadesGerenciais.Checked == true) { p1 = 1; } else { p1 = 0; }   // checar permissoes
            if (cbClientes.Checked == true) { p2 = 1; } else { p2 = 0; }   // que o gerente deseja
            if (cbProdutos.Checked == true) { p3 = 1; } else { p3 = 0; }   // conceder para este usuário
            if (cbOrcamentos.Checked == true) { p4 = 1; } else { p4 = 0; }   // que está sendo inserido
            if (cbPedidos.Checked == true) { p5 = 1; } else { p5 = 0; }   // na base de dados.
            if (cbEntregas.Checked == true) { p6 = 1; } else { p6 = 0; }   // de p1 a p9 temos todas as 
            if (cbRequisicoes.Checked == true) { p7 = 1; } else { p7 = 0; }   // permissoes possíveis de serem
            if (cbDespesas.Checked == true) { p8 = 1; } else { p8 = 0; }   // concedidas.
            if (cbBackup.Checked == true) { p9 = 1; } else { p9 = 0; }   // ___________________________//

           
            if (rbSim.Checked == true)
            {
                Autorizacao = 1;
            }
            if (rbNao.Checked == true)
            {
                Autorizacao = 0;
            }

            if (Status == StatusCadastro.scInserindo || lbCodUsuario.Text == "-1")
            {
                dt = ta.Pesquisa_Usuario(txtUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(" Usuário já existente... Defina outro para validar...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return bsalvar;
                }

                if (txtNome.Text == "" || txtCpf.Text == "")
                {
                    MessageBox.Show(" Nome ou CPF inválidos... Campos Obrigatórios...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else
                {
                    bsalvar = (ta.Insert(txtNome.Text, txtCpf.Text, txtUsuario.Text, txtSenha.Text, Convert.ToByte(Autorizacao)) > 0);

                    // gravar permissoes de usuarios
                    dt = ta.Pesquisa_Nome_Usuario(txtNome.Text);
                    CopiaIdUsuario = int.Parse(dt.Rows[0]["Id"].ToString());

                    if (bsalvar)
                    {
                        tap.Insert(CopiaIdUsuario, p1, p2, p3, p4, p5, p6, p7, p8, p9);
                    }
                }
                
            }

            if (Status == StatusCadastro.scEditando)
            {
                dt = ta.VerificaPossivelAlterarUsuario(txtUsuario.Text, CodigoGererico);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(" Usuário já existente... Defina outro para validar...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return bsalvar;
                }

                bsalvar = (ta.Alterando(txtNome.Text, txtCpf.Text, txtUsuario.Text, txtSenha.Text, Autorizacao, CodigoGererico) > 0);
                // alterar permissoes de usuarios
                if (bsalvar)
                {
                    tap.AlterarPermissoes(p1,p2,p3,p4,p5,p6,p7,p8,p9,CodigoGererico);
                }
            }
            if (bsalvar)
            {
                lbCodUsuario.Text = "-1";
                LimparControles();
                Close();
            }
            
            return bsalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // instanciar usuarios 
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();
            bExcluir = (ta.ExcluirUsuario(CodigoGererico) > 0);
            if (bExcluir)
            {
                // instanciar permissoes de usuarios
                //pensar que quando deletar registro do usuário devo automaticamente deletar registro que contém
                //permissoes para este usuário.
                C2W.c2wDataSet.permissoesDataTable dtp = new c2wDataSet.permissoesDataTable();
                permissoesTableAdapter tap = new permissoesTableAdapter();
                tap.ExcluirPermissoes(CodigoGererico);
            }
            lbCodUsuario.Text = "-1";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            Close();
            return bExcluir;
        }


 

        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            return bLocalizar;
        }






        //FIM DE MANTER USUÁRIOS

    }



}
