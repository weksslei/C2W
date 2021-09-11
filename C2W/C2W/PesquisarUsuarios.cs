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
    public partial class PesquisarUsuarios : Form
    {
        public PesquisarUsuarios()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PesquisarUsuarios_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            // instanciar usuarios 
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();

            dt = ta.TodosUsuarios();
            CarregaUsuarios(dt);
            PesquisaMessage.Text = " Existem " + ListaPesquisa.Items.Count + " Usuarios cadastrados.";
            txtPesquisar.Focus();
        }

        public string Teste;

        public void CarregaUsuarios(DataTable dt)
        {
            ListaPesquisa.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                if(int.Parse(dr[5].ToString())==1)
                {
                    Teste = "Sim";
                }
                else
                {
                    Teste = "Não";
                }
                item.SubItems.Add(Teste); //dr[5].ToString()

                ListaPesquisa.Items.Add(item);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // instanciar usuarios 
            C2W.c2wDataSet.usuariosDataTable dt = new c2wDataSet.usuariosDataTable();
            usuariosTableAdapter ta = new usuariosTableAdapter();

            dt = ta.Pesquisa_Nome_Usuario("%" + txtPesquisar.Text + "%");
            CarregaUsuarios(dt);
            PesquisaMessage.Text = " Foram encontrados " + ListaPesquisa.Items.Count + " registros com a palavra " + txtPesquisar.Text;
            
        }

        public string CodigoUsuario;

        private void ListaPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoUsuario = ListaPesquisa.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoUsuario = ListaPesquisa.SelectedItems[0].Text;
                Usuarios exibir = new Usuarios(CodigoUsuario);
                exibir.ShowDialog();
                PesquisarUsuarios_Load(sender, e);
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CodigoUsuario == "")
            {
                if (ListaPesquisa.Focused)
                {
                    CodigoUsuario = ListaPesquisa.SelectedItems[0].Text;
                }
            }

            Usuarios exibir = new Usuarios(CodigoUsuario);
            exibir.ShowDialog();
            PesquisarUsuarios Pu = new PesquisarUsuarios();
            Pu.ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Usuarios exibir = new Usuarios("-1");
            exibir.ShowDialog();
            PesquisarUsuarios Pu = new PesquisarUsuarios();
            Pu.ShowDialog();
        }
    }
}
