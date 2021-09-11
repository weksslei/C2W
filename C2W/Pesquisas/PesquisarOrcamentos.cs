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
    public partial class PesquisarOrcamentos : Form
    {
        int Opcao = 1;

        public PesquisarOrcamentos()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarOrcamentos_Load(object sender, EventArgs e)
        {
            btnGerarPedido.Enabled = false;
            txtPesquisar.Visible = false;
            btnVisualizar.Enabled = false;
            btnPesquisar.Enabled = false;
            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
            dtOrcamento = taOrcamento.OrcamentoNaoVendido();
            Carrega_Orcamentos(dtOrcamento);
           // txtPesquisar.Focus();
        }

        private void PesquisarOrcamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
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

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OpcaoPesquisa.Text == "Nome do Cliente")
            {
                Opcao = 1;
                cbClientes.Visible = false;
                txtPesquisar.Visible = true;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;
                txtPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Vendas não efetuadas")
            {
                Opcao = 2;
                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                mtbDataInicial.Visible = false;
                mtbDataFinal.Visible = false;
                btnPesquisar.Enabled = true;
                btnPesquisar.Focus();
            }
            if (OpcaoPesquisa.Text == "Período")
            {
                Opcao = 3;
                cbClientes.Visible = false;
                txtPesquisar.Visible = false;
                lblDataInicial.Visible = true;
                lblDataFinal.Visible = true;
                mtbDataInicial.Visible = true;
                mtbDataFinal.Visible = true;
                mtbDataInicial.Focus();
            }
            
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            if (e.KeyCode==Keys.Enter)
            {
              //  btnPesquisar.Enabled = true;
                txtPesquisar.Visible = false;
                cbClientes.Visible = true;
                dtCliente = taCliente.Filtrar_Cliente_Nome("%" + txtPesquisar.Text + "%");
               
                cbClientes.Items.Clear();
                if (dtCliente != null)
                {
                    for (int i = 0; i < dtCliente.Rows.Count; i++)
                    {
                        cbClientes.Items.Add(dtCliente.Rows[i]["id"].ToString().PadLeft(5, '0') + "   " + dtCliente.Rows[i]["nome"].ToString());
                    }
                }

                cbClientes.Focus();
            }
        }

        Frm_Base Funcao = new Frm_Base();
        public string DataI, DataF;

        private void mtbDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = mtbDataInicial.Text;
                if (!Funcao.ValidarData(data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataInicial.Focus();
                }
                else
                {
                    mtbDataFinal.Focus();
                }
            }
        }

        private void mtbDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

        private void mtbDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                mtbDataFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                DataF = mtbDataFinal.Text;
                if (!Funcao.ValidarData(DataF))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbDataFinal.Focus();
                }
                else
                {
                    mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // devolve a formatação
                    mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //              string DataI, DataF;
                    DataI = mtbDataInicial.Text;
                    DataF = mtbDataFinal.Text;

                    // MessageBox.Show(DataI + "   " + DataF);


                    if (Convert.ToDateTime(DataF) > Convert.ToDateTime(DataI))
                    {
                        btnPesquisar.Enabled = true;
                        btnPesquisar.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" Data Inválida...A data FINAL deverá ser superior a data INICIAL...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbDataFinal.Text = "";
                        mtbDataFinal.Focus();
                    }
                }
            }
        }

        private void mtbDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }
       

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //filtrar clientes
            C2W.c2wDataSet.clientesDataTable dtCliente = new c2wDataSet.clientesDataTable();
            clientesTableAdapter taCliente = new clientesTableAdapter();
            
            // instânciar orçamentos
            C2W.c2wDataSet.orcamentosDataTable dtOrcamento = new c2wDataSet.orcamentosDataTable();
            orcamentosTableAdapter taOrcamento = new orcamentosTableAdapter();
            if (Opcao == 1)   // Nome do Cliente
            {
                //dtCliente = taCliente.Filtrar_Cliente_Nome(NomeCliente);
                dtOrcamento = taOrcamento.OrcamentosDeUmCliente(CodigoCliente);
            }
            if (Opcao == 2)  // Vendas não efetuadas
            {
                dtOrcamento = taOrcamento.OrcamentoNaoVendido();
            }
            if (Opcao == 3)  // Período
            {
                mtbDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                mtbDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                dtOrcamento = taOrcamento.OrcamentosDeUmPeriodo(Convert.ToDateTime(mtbDataInicial.Text), Convert.ToDateTime(mtbDataFinal.Text));
            }
            

            if (dtOrcamento.Rows.Count > 0)
            {
                Carrega_Orcamentos(dtOrcamento);
            }
            else
            {
                ListaOrcamentos.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPesquisar.Enabled = false;
                mtbDataInicial.Text = "";
                mtbDataFinal.Text = "";
                txtPesquisar.Text = "";
                if(Opcao==1)
                {
                    txtPesquisar.Focus();
                }
                if (Opcao == 3)
                {
                    mtbDataInicial.Focus();
                }
            }

            

        }
               
        public string NomeCliente,CodigoOrcamento;
        public int CodigoCliente;

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            NomeCliente = cbClientes.SelectedItem.ToString();
            CodigoCliente = int.Parse(NomeCliente.Substring(0, 5));

            btnPesquisar.Enabled = true;
            btnPesquisar.Focus();
        }
      
        private void ListaOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnGerarPedido.Enabled = true;
                btnVisualizar.Enabled = true;
                CodigoOrcamento = ListaOrcamentos.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void ListaOrcamentos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoOrcamento = ListaOrcamentos.SelectedItems[0].Text;
                Orçamentos Or = new Orçamentos(CodigoOrcamento);
                Or.ShowDialog();
                PesquisarOrcamentos_Load(sender,e);
            }
            catch
            {

            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Orçamentos Or = new Orçamentos(CodigoOrcamento);
            Or.ShowDialog();
            PesquisarOrcamentos Po = new PesquisarOrcamentos();
            Po.ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Orçamentos Or = new Orçamentos("-1");
            Or.ShowDialog();
            PesquisarOrcamentos Po = new PesquisarOrcamentos();
            Po.ShowDialog();
        }

        private void btnGerarPedido_Click(object sender, EventArgs e)
        {
            Vendas Gerar = new Vendas(0,int.Parse(CodigoOrcamento));
            Gerar.ShowDialog();
        }

    }
}
