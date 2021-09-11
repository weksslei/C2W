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
    public partial class PesquisarProdutos : Form
    {
        public PesquisarProdutos()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        public void Carrega_Produtos(DataTable dt)
        {
            //listaClientes.Items.Clear();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.Text = dr[0].ToString();
            //    item.SubItems.Add(dr[1].ToString());
            //    item.SubItems.Add(dr[2].ToString());
            //    item.SubItems.Add(dr[3].ToString());
            //    item.SubItems.Add(dr[4].ToString());
            //    item.SubItems.Add(dr[5].ToString());
            //    item.SubItems.Add(dr[6].ToString());
            //    listaClientes.Items.Add(item);
            //}
        }








        private void btnNovo_Click(object sender, EventArgs e)
        {
            Produtos Novo = new Produtos("-1");
            Novo.ShowDialog();

            PesquisarProdutos Pp = new PesquisarProdutos();
            Pp.ShowDialog();
        }
    }
}
