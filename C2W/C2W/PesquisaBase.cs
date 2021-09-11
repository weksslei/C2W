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
    public partial class PesquisaBase : Form
    {
        public string CopiaCodigo;

        public PesquisaBase()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisaBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

     
        private void ListaPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CopiaCodigo = ListaPesquisa.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CopiaCodigo = ListaPesquisa.SelectedItems[0].Text;
                Close();
                DialogResult = DialogResult.OK;
            }
            catch
            {

            }
        }

        private void PesquisaBase_Load(object sender, EventArgs e)  
        {
            btnOK.Enabled = false;
        }

        public virtual void Pesquisar()
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {            
            Pesquisar();
            PesquisaMessage.Text = " Foram encontrados " + ListaPesquisa.Items.Count + " registros com a palavra " + txtPesquisar.Text;
            //btnOK.Enabled = ListaPesquisa.Items.Count > 0;
            //if (btnOK.Enabled)
            //{
            //    ListaPesquisa.Focus();
            //}
        }

        public void RetornarItensPesquisa(DataTable dt)
        {
            ListaPesquisa.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[5].ToString());

                ListaPesquisa.Items.Add(item);
            }
        }

        private void ListaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CopiaCodigo = ListaPesquisa.SelectedItems[0].Text;
         //       DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaPesquisa.Focused)
                {
                    CopiaCodigo = ListaPesquisa.SelectedItems[0].Text;
                }
            }
          
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaPesquisa.Focused)
                {
                    CopiaCodigo = ListaPesquisa.SelectedItems[0].Text;
                }
            }
            
            //Close();
        }


        //fim da pesquisa base
    }
}
