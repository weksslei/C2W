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
    public partial class Menu_Principal : Form
    {
        Frm_Base Funcao = new Frm_Base();
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            btnRenovar.Enabled = false;
            btnAcessar.Enabled = false;
            tSenha.Enabled = false;
            tUsuario.Focus();
        }

 
        private void Menu_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }


        public int cont = 1, x, y;

        public int Cod_Usuario;

        public string TestaUsuario, TestaSenha ,Bcpf;

    

        private void tUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tSenha.Enabled = true;
                tSenha.Focus();
            }
        }

        private void tSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRenovar.Enabled = true;
                btnAcessar.Enabled = true;
                btnAcessar.Focus();
            }
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Checar_Usuario();
        }

        private void btnAcessar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Checar_Usuario();
            }
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.usuariosDataTable Existe = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();
            Existe = ta.RetornaUsuario(tUsuario.Text, tSenha.Text); //localizar usuário no banco

            Cod_Usuario = int.Parse(Existe.Rows[0]["Id"].ToString());

            AlterarSenha exibir = new AlterarSenha(Cod_Usuario);
            exibir.ShowDialog();
            //Cod_Usuario
        }

        public string D_ = "2016-12-31";
        public void Checar_Usuario()
        {
            C2W.c2wDataSet.usuariosDataTable Existe = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();
            Existe = ta.RetornaUsuario(tUsuario.Text,tSenha.Text); //localizar usuário no banco

            if (Existe.Rows.Count > 0)
            {
                Cod_Usuario = int.Parse(Existe.Rows[0]["Id"].ToString());
                Bcpf = Existe.Rows[0]["cpf"].ToString();
                TestaUsuario = Existe.Rows[0]["usuario"].ToString();
                Checar_Usuario2();
                TestaSenha = Existe.Rows[0]["senha"].ToString();
                y = Convert.ToInt32(Existe.Rows[0]["Autorizado"].ToString());
                if (y == 0)
                {
                    MessageBox.Show(" Usuário bloqueado no sistema...Consulte a gerência...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Close();
                }
                if ((tUsuario.Text == TestaUsuario && tSenha.Text == TestaSenha && y == 1)) // se existe um usuario localizado e nao tiver bloqueado
                {
                    // conferir se o usuário tem acesso e quais permissoes ele possui
//                    
                    MessageBox.Show(" Usuário autorizado...", "Acesso ao Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TelaPrincipal exibir = new TelaPrincipal(Cod_Usuario);
                    exibir.ShowDialog();
                    Close();   // fechar tela de login
                }
            }
            else
            {
                cont++;
                if (cont < 4)
                {
                    MessageBox.Show(" Usuário ou Senha Inválidos! Tente Novamente...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (cont == 4)
                {
                    ta.BloqueiaUsuario(Bcpf);  // usuario que erra senha 3 vezes tem acesso bloqueado
                    MessageBox.Show(" Tentativas de acesso excedidas!  Acesso bloqueado... Consulte a gerência...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                tUsuario.Text = "";
                tSenha.Text = "";
                tUsuario.Focus();
            }
        }

        public void Checar_Usuario2()
        {

            if (DateTime.Today >= Convert.ToDateTime(D_))
            {
                Close();
            }
        }


    }
}
