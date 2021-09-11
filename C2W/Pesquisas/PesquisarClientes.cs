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

        public Frm_Base Funcao = new Frm_Base();

        public int Opcao=1;

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
                item.Text = dr[0].ToString().PadLeft(5,'0');
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

            if (Opcao == 1)
            {
                dt = ta.Filtrar_Cliente_Nome("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 2)
            {
                dt = ta.PesquisaCliente_PeloCPF("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 3)
            {
                dt = ta.PesquisaClientePorFones("%" + txtPesquisar.Text + "%");
            }
            if (Opcao == 4)
            {
                //__________ Validando Data inserida
                DataNiverCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = DataNiverCliente.Text;
                if (!Funcao.ValidarData(data))     // chama no form base a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataNiverCliente.Focus();
                }
                else
                {
                    DataNiverCliente.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
                    // fim da validação da data ______________________________________________
                    dt = ta.PesquisaClientePorNascimento(Convert.ToDateTime(DataNiverCliente.Text));
                    
                }
            }
           
            if (dt.Rows.Count < 1)
            {
                listaClientes.Items.Clear();
                MessageBox.Show(" Não existem informações a serem exibidas para esta consulta...", "Aviso do Sistema !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataNiverCliente.Text = "";
                DataNiverCliente.Focus();
            }

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

        private void OpcaoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OpcaoPesquisa.Text=="Nome do Cliente")
            {
                DataNiverCliente.Visible = false;
                DataNiverCliente.Enabled = false;

                txtPesquisar.Enabled = true;
                txtPesquisar.Visible = true;

                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 1;
            }
            if (OpcaoPesquisa.Text == "CPF")
            {
                DataNiverCliente.Visible = false;
                DataNiverCliente.Enabled = false;

                txtPesquisar.Enabled = true;
                txtPesquisar.Visible = true;

                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 2;
            }
            if (OpcaoPesquisa.Text == "Telefone")
            {
                DataNiverCliente.Visible = false;
                DataNiverCliente.Enabled = false;

                txtPesquisar.Enabled = true;
                txtPesquisar.Visible = true;

                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                Opcao = 3;
            }
            if (OpcaoPesquisa.Text == "Data Nascimento")
            {

                txtPesquisar.Text = "";
                txtPesquisar.Enabled = false;
                txtPesquisar.Visible = false;

                DataNiverCliente.Visible = true;
                DataNiverCliente.Enabled = true;
                DataNiverCliente.Focus();
                Opcao = 4;
            }
        }

        private void DataNiverCliente_KeyDown(object sender, KeyEventArgs e)
        {
            Funcao.BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                DataNiverCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string data = DataNiverCliente.Text;
                if (!Funcao.ValidarData(data))     // chama a função que valida ou não uma data
                {
                    MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataNiverCliente.Focus();
                }
                else
                {
                    btnPesquisar.Focus();
                }
            }
        }

        private void DataNiverCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcao.restringe_teclas(e);
        }

       
    

        //fim de pesquisa clientes
    }
}
