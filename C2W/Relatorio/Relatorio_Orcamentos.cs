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
    public partial class Relatorio_Orcamentos : Form
    {
        public Relatorio_Orcamentos()
        {
            InitializeComponent();
        }

        private void Relatorio_Orcamentos_KeyDown(object sender, KeyEventArgs e)
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

        private void Relatorio_Orcamentos_Load(object sender, EventArgs e)
        {
            btnEmitir.Enabled = false;
            Anos.Enabled = false;
            Meses.Focus();
        }

        private void Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anos.Enabled = true;
            Anos.Focus();
        }

        private void Anos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEmitir.Enabled = true;
            btnEmitir.Focus();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            string Mes = "";
            DateTime Data1, Data2;
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
            if (Anos.Text == "ANO")
            {
                Anos.Text = "2010";
            }

            string Periodo = (Anos.Text + "-" + Mes + "-" + "01");

            Data1 = Convert.ToDateTime(Periodo);

            if (int.Parse(Mes) == 12)
            {
                Data2 = Convert.ToDateTime((int.Parse(Anos.Text) + 1) + "-" + "01" + "-" + "01");
            }
            else
            {
                Data2 = Convert.ToDateTime(Anos.Text + "-" + (int.Parse(Mes) + 1) + "-" + "01");
            }

            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
            dtOrcamento = taOrcamento.OrcamentosDeUmPeriodo(Data1,Data2);
            
           
            if (dtOrcamento.Rows.Count < 1)
            {
                ListaOrcamentos.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Carrega_Orcamentos(dtOrcamento);

        }

        public void Carrega_Orcamentos(DataTable dt)
        {
            string Teste;
            // buscar clientes
            C2W.c2wDataSet.clientesDataTable dtClientes = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taClientes = new clientesTableAdapter();
            ListaOrcamentos.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString().PadLeft(5, '0');
                dtClientes = taClientes.PesquisaClienteId(int.Parse(dr[1].ToString()));
                item.SubItems.Add(dtClientes.Rows[0]["nome"].ToString()); // nome do cliente
                item.SubItems.Add(string.Format("{0:d}", dr[2]).ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[3]).ToString)());   // preço formato moeda
                if (int.Parse(dr[4].ToString()) == 1)
                {
                    Teste = "Sim";
                }
                else
                {
                    item.BackColor = Color.Peru; // parei aqui
                    Teste = "Não";
                }
                item.SubItems.Add(Teste);
                ListaOrcamentos.Items.Add(item);
            }
        }

    }
}
