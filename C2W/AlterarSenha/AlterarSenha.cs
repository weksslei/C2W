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
    public partial class AlterarSenha : Form
    {
        public int cod;

        public AlterarSenha(int x)
        {
            InitializeComponent();
            cod = x;
        }

      
        private void AlterarSenha_Load(object sender, EventArgs e)
        {
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();
            dt = ta.PesquisaId(cod); // pesquisar usuario obter seu registro
            lblNome.Text = dt.Rows[0]["Nome"].ToString();

            txtUsuarioAtual.Focus();
            txtNovoUsuario.Enabled = false;
            txtRepetirNovoUsuario.Enabled = false;
            txtNovaSenha.Enabled = false;
            txtRepetirNovaSenha.Enabled = false;
            btnOK.Enabled = false;
        }

        private void txtUsuarioAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenhaAtual.Focus();
            }
        }

        public string tUsuario, tSenha;

      
        private void txtSenhaAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // validar usuario
                C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
                usuariosTableAdapter ta = new usuariosTableAdapter();
                dt = ta.PesquisaId(cod); // pesquisar usuario obter seu registro
                tUsuario = dt.Rows[0]["usuario"].ToString();
                tSenha = dt.Rows[0]["senha"].ToString();

                if (txtUsuarioAtual.Text == tUsuario && txtSenhaAtual.Text == tSenha)
                {
                    txtUsuarioAtual.Enabled = false;
                    txtSenhaAtual.Enabled = false;
                    txtNovoUsuario.Enabled = true;
                    txtRepetirNovoUsuario.Enabled = true;
                    txtNovoUsuario.Focus();
                }
                else
                {
                    MessageBox.Show(" Usuario ou Senha Informados são Inválidos! Repita o processo...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuarioAtual.Text = "";
                    txtSenhaAtual.Text = "";
                    txtUsuarioAtual.Focus();
                }
            }
        }

        private void txtNovoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepetirNovoUsuario.Focus();
            }
        }

        private void txtRepetirNovoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNovoUsuario.Text == txtRepetirNovoUsuario.Text)
                {
                    txtNovaSenha.Enabled = true;
                    txtRepetirNovaSenha.Enabled = true;
                    txtNovaSenha.Focus();
                }
                else
                {
                    MessageBox.Show(" Repita o processo... Dados inconsistentes...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRepetirNovoUsuario.Text = "";
                    txtNovoUsuario.Text = "";
                    txtNovoUsuario.Focus();
                }
            }
        }

        private void txtNovaSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepetirNovaSenha.Focus();
            }
        }

       
        private void txtRepetirNovaSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNovaSenha.Text == txtRepetirNovaSenha.Text)
                {
                    btnOK.Enabled = true;
                    btnOK.Focus();
                }
                else
                {
                    MessageBox.Show(" Repita o processo... Dados inconsistentes...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRepetirNovaSenha.Text = "";
                    txtNovaSenha.Text = "";
                    txtNovaSenha.Focus();
                }
            }
        }

        private void AlterarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();
            ta.AtualizarUsuarioSenha(txtNovoUsuario.Text,txtNovaSenha.Text , cod);
            MessageBox.Show(" Usuário e Senha alterados com sucesso...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }





    }
}
