using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2W
{
    public partial class AtividadesGerenciais : Form
    {
        public AtividadesGerenciais()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AtividadesGerenciais_Load(object sender, EventArgs e)
        {
           
        }

        private void AtividadesGerenciais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnGerarRelatorios_Click(object sender, EventArgs e)
        {
            GerarRelatorios gr = new GerarRelatorios();
            gr.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // chamar formulario que herda menu CRUD ( inserir, alterar, excluir, localizar)
            PesquisarUsuarios Pu = new PesquisarUsuarios();
            Pu.ShowDialog();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            PesquisarFornecedores Pf = new PesquisarFornecedores();
            Pf.ShowDialog();
        }


    }
}
