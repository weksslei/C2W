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
    public partial class PesquisarDespesas : Form
    {
        public PesquisarDespesas()
        {
            InitializeComponent();
        }

        public string CopiaCodigo;

        private void PesquisarDespesas_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            C2W.c2wDataSet.despesasDataTable dt = new c2wDataSet.despesasDataTable();
            despesasTableAdapter ta = new despesasTableAdapter();
            dt = ta.ListarDespesas();
            Retorna_Despesas(dt);
            PesquisaMessage.Text = " Existem " + ListaDespesas.Items.Count + " despesas cadastradas.";
            txtPesquisar.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Retorna_Despesas(DataTable dt)
        {
            ListaDespesas.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add( (String.Format("{0:C}", dr[2]).ToString)() );  // campo valor formatado para moeda
                item.SubItems.Add(dr[3].ToString());
                ListaDespesas.Items.Add(item);
            }
        }

        private void PesquisarDespesas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            C2W.c2wDataSet.despesasDataTable dt = new c2wDataSet.despesasDataTable();
            despesasTableAdapter ta = new despesasTableAdapter();
            dt = ta.Pesquisa_Nome("%" + txtPesquisar.Text + "%");
            Retorna_Despesas(dt);
            PesquisaMessage.Text = " Foram encontrados " + ListaDespesas.Items.Count + " registros com a palavra " + txtPesquisar.Text;

        }

        private void ListaDespesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CopiaCodigo = ListaDespesas.SelectedItems[0].Text;
            }
            catch
            {

            }
           
        }

        private void ListaDespesas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //btnOK.Enabled = true;
                CopiaCodigo = ListaDespesas.SelectedItems[0].Text;

                Despesas exibir = new Despesas(CopiaCodigo);
                exibir.ShowDialog();
                PesquisarDespesas_Load(sender, e);
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaDespesas.Focused)
                {
                    CopiaCodigo = ListaDespesas.SelectedItems[0].Text;
                }
            }
           
            Despesas exibir = new Despesas(CopiaCodigo);
            exibir.ShowDialog();

            //    MessageBox.Show("  testando    ");

            PesquisarDespesas te = new PesquisarDespesas();
            te.ShowDialog();
        
        }


        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (CopiaCodigo == "")
            {
                if (ListaDespesas.Focused)
                {
                    CopiaCodigo = ListaDespesas.SelectedItems[0].Text;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Despesas Nova = new Despesas("-1");
            Nova.ShowDialog();
            //  PesquisarDespesas_Load(sender,e);
            PesquisarDespesas te = new PesquisarDespesas();
            te.ShowDialog();
        }
    }
}
