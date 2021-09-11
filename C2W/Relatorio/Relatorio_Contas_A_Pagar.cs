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
    public partial class Relatorio_Contas_A_Pagar : Form
    {
        public Relatorio_Contas_A_Pagar()
        {
            InitializeComponent();
        }

        private void Relatorio_Contas_A_Pagar_Load(object sender, EventArgs e)
        {
            Anos.Enabled = false;
            btnEmitir.Enabled = false;
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
            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();

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

            dtContas = taContas.PesquisarVencimento(Data1, Data2);
            if (dtContas.Rows.Count < 1)
            {
                ListaDespesas.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Carrega_Despesas(dtContas);
        }

        public void Carrega_Despesas(DataTable dt)
        {
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            int IdEmpresa = 0;
            ListaDespesas.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());

                IdEmpresa = int.Parse(dr[2].ToString());
                dtEmpresa = taEmpresa.PesquisaFornecedorId(IdEmpresa);
                string NomeEmpresa = dtEmpresa.Rows[0]["nome_empresa"].ToString();
                item.SubItems.Add(NomeEmpresa);

                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add((String.Format("{0:C}", dr[4]).ToString)());  // campo valor formatado para moeda
                item.SubItems.Add(String.Format("{0:d}", dr[5]).ToString()); // data sem hora


                item.SubItems.Add(String.Format("{0:d}", dr[6]).ToString()); // data sem hora vencimento

                byte Situacao = Convert.ToByte(dr[9].ToString());
                if (Situacao == 0)
                {
                    item.SubItems.Add(" em aberto");
                }
                else
                {
                    item.SubItems.Add(" Quitado ");
                }
                if ((Convert.ToDateTime(dr[6].ToString()) < DateTime.Today) && Situacao == 0)
                {
                    item.BackColor = Color.Peru;
                }
                item.SubItems.Add(dr[2].ToString());

                ListaDespesas.Items.Add(item);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Relatorio_Contas_A_Pagar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

      
    }
}
