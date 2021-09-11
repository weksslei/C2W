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
    public partial class PesquisarClientes : Form
    {
        public PesquisarClientes()
        {
            InitializeComponent();
        }

       

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        public void Retorna_Clientes(DataTable dt)
        {
            listaClientes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                
                listaClientes.Items.Add(item);
            }
        }

        private void PesquisarClientes_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            // instanciar clientes
            C2W.c2wDataSet.clientesDataTable dt = new c2wDataSet.clientesDataTable();
            clientesTableAdapter ta = new clientesTableAdapter();

            dt = ta.ListarTodosClientes();

            Retorna_Clientes(dt);
            PesquisaMessage.Text = " Existem " + listaClientes.Items.Count + " Clientes cadastrados.";
            txtPesquisar.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dt = new c2wDataSet.clientesDataTable();
            clientesTableAdapter ta = new clientesTableAdapter();

            dt = ta.Filtrar_Cliente_Nome("%" + txtPesquisar.Text + "%");
            Retorna_Clientes(dt);
            PesquisaMessage.Text = " Foram encontrados " + listaClientes.Items.Count + " registros com a palavra " + txtPesquisar.Text;

        }

        public string CodigoCliente;

      

        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoCliente = listaClientes.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void listaClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CodigoCliente = listaClientes.SelectedItems[0].Text;
                Clientes Novo = new Clientes(CodigoCliente);
                Novo.ShowDialog();
                PesquisarClientes_Load(sender, e);

            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CodigoCliente == "")
            {
                if (listaClientes.Focused)
                {

                    CodigoCliente = listaClientes.SelectedItems[0].Text;
                }
            }

            Clientes Novo = new Clientes(CodigoCliente);
            Novo.ShowDialog();

            Close();
            PesquisarClientes Pc = new PesquisarClientes();
            Pc.ShowDialog();

        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (CodigoCliente == "")
            {
                if (listaClientes.Focused)
                {
                    CodigoCliente = listaClientes.SelectedItems[0].Text;
                    
                }
            }
            
        }

        private void listaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    CodigoCliente = listaClientes.SelectedItems[0].Text;
            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            Clientes Novo = new Clientes("-1");
            Novo.ShowDialog();

            PesquisarClientes Pc = new PesquisarClientes();
            Pc.ShowDialog();
         
        }

       


        //fim de pesquisa clientes
    }
}
