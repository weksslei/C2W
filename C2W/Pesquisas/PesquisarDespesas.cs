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

        public int Opcao = 1, CodigoFornecedor;

        public string CopiaCodigo; // recebe o código da conta a pagar

        private void PesquisarDespesas_Load(object sender, EventArgs e)
        {
            Meses.Visible = false;
            Anos.Visible = false;
            lblOpcoes.Visible = false;
            cbFornecedores.Visible = false;
            btnOK.Enabled = false;
            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();
            dtContas = taContas.ListarContas_A_Pagar();
            Retorna_Despesas(dtContas);
            PesquisaMessage.Text = " Existem " + ListaDespesas.Items.Count + " contas a pagar.";
            txtPesquisar.Visible = false;

            Meses.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Retorna_Despesas(DataTable dt)
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
                item.SubItems.Add( (String.Format("{0:C}", dr[4]).ToString)() );  // campo valor formatado para moeda
                item.SubItems.Add(String.Format("{0:d}", dr[5]).ToString()); // data sem hora

              
                item.SubItems.Add(String.Format("{0:d}", dr[6]).ToString()); // data sem hora vencimento

                byte Situacao=Convert.ToByte(dr[9].ToString());
                if(Situacao==0)
                {
                    item.SubItems.Add(" em aberto");
                }
                else
                {
                    item.SubItems.Add(" Quitado ");
                }
                if ((Convert.ToDateTime(dr[6].ToString()) < DateTime.Today) && Situacao == 0 )
                {
                    item.BackColor = Color.Peru;
                }
                item.SubItems.Add(dr[2].ToString());

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
           
            C2W.c2wDataSet.contas_a_pagarDataTable dtContas = new c2wDataSet.contas_a_pagarDataTable();
            contas_a_pagarTableAdapter taContas = new contas_a_pagarTableAdapter();

           
            if (Opcao == 1)
            {
                dtContas = taContas.ListarContas_A_Pagar();
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem contas a pagar...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (Opcao == 2)
            {
                dtContas = taContas.ListarContas_A_Pagar_Por_Fornecedor(CodigoFornecedor);
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem contas a pagar selecionadas para este Fornecedor...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (Opcao == 3)
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

                dtContas = taContas.ContasQuitadas(Data1,Data2);
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (Opcao == 4)
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
                //MessageBox.Show("=> " + Periodo + " teste data: " + Data1  + "  " + Data2);

                //SELECT * FROM tabela WHERE DATA BETWEEN '2006-04-25' AND '2006-04-30' 

                dtContas = taContas.PesquisarVencimento(Data1, Data2);
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem contas a pagar selecionadas para este período...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            if (Opcao == 5)
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
                //MessageBox.Show("=> " + Periodo + " teste data: " + Data1  + "  " + Data2);

                //SELECT * FROM tabela WHERE DATA BETWEEN '2006-04-25' AND '2006-04-30' 
                dtContas = taContas.Contas_A_Pagar_Periodo(Data1, Data2);
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem contas a pagar selecionadas para este período...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (Opcao == 6)
            {
                dtContas = taContas.PesquisarNF(txtPesquisar.Text);
                if (dtContas.Rows.Count < 1)
                {
                    ListaDespesas.Items.Clear();
                    MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Retorna_Despesas(dtContas);
            PesquisaMessage.Text = " Foram encontrados " + ListaDespesas.Items.Count + " registros com a palavra " + txtPesquisar.Text;

        }

        public string X_Serie, X_Fornecedor, X_Parcela;

        private void ListaDespesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = true;
                CopiaCodigo = ListaDespesas.SelectedItems[0].Text;
                X_Serie = ListaDespesas.SelectedItems[0].SubItems[1].Text;
                X_Fornecedor = ListaDespesas.SelectedItems[0].SubItems[8].Text;
                X_Parcela = ListaDespesas.SelectedItems[0].SubItems[3].Text;
                //MessageBox.Show("" + CopiaCodigo + X_Serie + X_Fornecedor + X_Parcela);
            }
            catch
            {

            }
           
        }

        private void ListaDespesas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CopiaCodigo = ListaDespesas.SelectedItems[0].Text;
                X_Serie = ListaDespesas.SelectedItems[0].SubItems[1].Text;
                X_Fornecedor = ListaDespesas.SelectedItems[0].SubItems[8].Text;
                X_Parcela = ListaDespesas.SelectedItems[0].SubItems[3].Text;
                Despesas exibir = new Despesas(CopiaCodigo, X_Serie, X_Fornecedor, X_Parcela);
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
                    X_Serie = ListaDespesas.SelectedItems[0].SubItems[1].Text;
                    X_Fornecedor = ListaDespesas.SelectedItems[0].SubItems[8].Text;
                    X_Parcela = ListaDespesas.SelectedItems[0].SubItems[3].Text;
                }
            }
            Despesas exibir = new Despesas(CopiaCodigo,X_Serie,X_Fornecedor,X_Parcela);
            exibir.ShowDialog();
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
                    X_Serie = ListaDespesas.SelectedItems[0].SubItems[1].Text;
                    X_Fornecedor = ListaDespesas.SelectedItems[0].SubItems[8].Text;
                    X_Parcela = ListaDespesas.SelectedItems[0].SubItems[3].Text;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Despesas Nova = new Despesas("-1","0","0","0");
            Nova.ShowDialog();
            PesquisarDespesas te = new PesquisarDespesas();
            te.ShowDialog();
        }

        private void Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anos.Focus();
        }

        private void Anos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = true;
        }

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDespesas.Items.Clear();
            if (OpcaoPesquisa.Text == "Todas a Pagar")
            {
                lblOpcoes.Visible = false;
                cbFornecedores.Visible = false;
                txtPesquisar.Visible = false;
                Anos.Visible = false;
                Meses.Visible = false;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
                Opcao = 1;
            }
            if (OpcaoPesquisa.Text == "Fornecedor")
            {
                cbFornecedores.Visible = false;
                Anos.Visible = false;
                Meses.Visible = false;
                lblOpcoes.Visible = true;
                lblOpcoes.Text = "Insira nome da empresa:";
                txtPesquisar.Enabled = true;
                txtPesquisar.Visible = true;
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 2;
            }
            if (OpcaoPesquisa.Text == "Quitadas")
            {
                btnPesquisar.Enabled = false;
                lblOpcoes.Visible = true;
                lblOpcoes.Text = " Mês:                       Ano:";
                cbFornecedores.Visible = false;
                txtPesquisar.Visible = false;
                Anos.Visible = true;
                Meses.Visible = true;
                Meses.Focus();
                Opcao = 3;
            }
            if (OpcaoPesquisa.Text == "Vencimento")
            {
                btnPesquisar.Enabled = false;
                lblOpcoes.Visible = true;
                lblOpcoes.Text = " Mês:                       Ano:";
                cbFornecedores.Visible = false;
                txtPesquisar.Visible = false;
                Anos.Visible = true;
                Meses.Visible = true;
                Meses.Focus();
                Opcao = 4;
            }
            if (OpcaoPesquisa.Text == "A Pagar por período")
            {
                btnPesquisar.Enabled = false;
                lblOpcoes.Visible = true;
                lblOpcoes.Text = " Mês:                       Ano:";

                cbFornecedores.Visible = false;
                txtPesquisar.Visible = false;
                Anos.Visible = true;
                Meses.Visible = true;
                Meses.Focus();
                Opcao = 5;
            }
            if (OpcaoPesquisa.Text == "Nota Fiscal")
            {
                lblOpcoes.Visible = true;
                lblOpcoes.Text = "Insira número NF: ";

                cbFornecedores.Visible = false;
                txtPesquisar.Visible = true;
                Anos.Visible = false;
                Meses.Visible = false;
                txtPesquisar.Text = "";
                txtPesquisar.Focus();

                Opcao = 6;
            }
            //
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Opcao == 2)
                {
                    C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
                    fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
                    dtEmpresa = taEmpresa.FiltrarFornecedores("%" + txtPesquisar.Text + "%");
                    txtPesquisar.Visible = false;
                    //carregar combo box
                    cbFornecedores.Visible = true;
                    cbFornecedores.Enabled = true;

                    lblOpcoes.Text = "Selecione Fornecedor:";

                    cbFornecedores.Items.Clear();
                    if (dtEmpresa != null)
                    {
                        for (int i = 0; i < dtEmpresa.Rows.Count; i++)
                        {
                            cbFornecedores.Items.Add(dtEmpresa.Rows[i]["nome_empresa"].ToString());
                        }
                    }

                    cbFornecedores.Focus();
                }
                if(Opcao==6)
                {
                    btnPesquisar.Enabled = true;
                    btnPesquisar.Focus();
                }
            }
        }

        private void cbFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = true;
            C2W.c2wDataSet.fornecedoresDataTable dtEmpresa = new c2wDataSet.fornecedoresDataTable();
            fornecedoresTableAdapter taEmpresa = new fornecedoresTableAdapter();
            dtEmpresa = taEmpresa.FiltrarFornecedores(cbFornecedores.SelectedItem.ToString());
          //  dtGrupos = taGrupos.GrupoEscolhido(cbGrupo.SelectedItem.ToString());
            if (dtEmpresa.Rows.Count == 1)
            {
                CodigoFornecedor = int.Parse(dtEmpresa.Rows[0]["id"].ToString());
                //           MessageBox.Show("  id escolhido => " + CodigoGrupo);
            }
        }
    }
}
