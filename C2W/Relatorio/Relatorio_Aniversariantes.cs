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
    public partial class Relatorio_Aniversariantes : Form
    {
        public Relatorio_Aniversariantes()
        {
            InitializeComponent();
        }

        private void Relatorio_Aniversariantes_Load(object sender, EventArgs e)
        {
            btnEmitir.Enabled = false;
            Meses.Focus();
        }

        private void Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEmitir.Enabled = true;
            btnEmitir.Focus();
        }

       

        private void Relatorio_Aniversariantes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taClientes = new clientesTableAdapter();

            string Mes = "";

            switch (Meses.Text)
            {
                case "JANEIRO":
                    Mes = "01";
                    break;
                case "FEVEREIRO":
                    Mes = "02";
                    break;
                case "MARÇO":
                    Mes = "03";
                    break;
                case "ABRIL":
                    Mes = "04";
                    break;
                case "MAIO":
                    Mes = "05";
                    break;
                case "JUNHO":
                    Mes = "06";
                    break;
                case "JULHO":
                    Mes = "07";
                    break;
                case "AGOSTO":
                    Mes = "08";
                    break;
                case "SETEMBRO":
                    Mes = "09";
                    break;
                case "OUTUBRO":
                    Mes = "10";
                    break;
                case "NOVEMBRO":
                    Mes = "11";
                    break;
                case "DEZEMBRO":
                    Mes = "12";
                    break;
                default:
                    Mes = "01";
                    break;
            }
            dtClientes = taClientes.Pesquisa_Aniversariantes(Convert.ToDecimal(Mes));
            if(dtClientes.Rows.Count < 1)
            {
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Carrega_Clientes(dtClientes);
        }

        public void Carrega_Clientes(DataTable dt)
        {
            listaClientes.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                item.SubItems.Add(dr[1].ToString());
                // formatar campo mostrar somente data
                item.SubItems.Add(string.Format("{0:d}", dr[2]).ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                listaClientes.Items.Add(item);
            }
        }



    }
}
