using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C2W.c2wDataSetTableAdapters;

namespace C2W
{
    public partial class Despesas : C2W.Frm_Base
    {
        public Despesas(string cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(cod);
        }
        
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValor.Focus();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
            if (e.KeyCode == Keys.Enter)
            {
                txtVenci.Focus();
            }
        }

        private void txtVenci_KeyDown(object sender, KeyEventArgs e)
        {
            BloquearEspaco(e);
        }

        public int Contador = 0,Teste=1;
        public bool Fim = false;

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // números 48 a 57   //0,1,2,3,4,5,6,7,8,9  onde 48 = 0 ...... e 57 = 9
           // MessageBox.Show("=> " + Contador + "    " + Fim.ToString());

            // Campo valor configurado para aceitar somente números, uma vírgula e duas casas decimais.
            if (Status==StatusCadastro.scEditando && Teste==1)
            {
                txtValor.Text = "";
                Teste = 0;
            }
            if (Contador > 1 && e.KeyChar != 08) // 08 = baskspace
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 44  )   
            {
                e.Handled = true;
                
            }
            if (e.KeyChar == 44)  // 44 = ,
            {
                Fim = true;
                if ((e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;      // aceitar a vírgula somente uma vez
                }
            }
            if (Fim)
            {
                if(e.KeyChar==08)
                {
                    if (Contador > -1)
                    {
                        Contador--;
                        if (Contador == -1 )
                        {
                            Fim = false;
                            Contador = 0;
                        }
                    }
                }
                if (e.KeyChar > 47 && e.KeyChar < 58)
                {
                    if (Contador < 2)
                    {
                        Contador++;
                    }
                }
            }
        }

        private void txtVenci_KeyPress(object sender, KeyPressEventArgs e)
        {
            restringe_teclas(e);
        }

        private void Despesas_Load(object sender, EventArgs e)
        {
            if(CodigoGererico>0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
                txtNome.Enabled = false;
                txtValor.Enabled = false;
                txtVenci.Enabled = false;
            }
        }

        public override void CarregaValores()
        {
            // instanciar despesas
            C2W.c2wDataSet.despesasDataTable dt = new c2wDataSet.despesasDataTable();
            despesasTableAdapter ta = new despesasTableAdapter();
            dt = ta.PesquisaId(CodigoGererico);
            if (dt.Rows.Count > 0)
            {
                lbCodDespesa.Text = dt.Rows[0]["Id"].ToString();
                txtNome.Text = dt.Rows[0]["Nome"].ToString();
                txtValor.Text = dt.Rows[0]["valor"].ToString();
                txtVenci.Text = dt.Rows[0]["vencimento"].ToString();
            }
        }
                     
        public override bool Salvar()
        {
            bool bsalvar = false;

            // instanciar despesas
            C2W.c2wDataSet.despesasDataTable dt = new c2wDataSet.despesasDataTable();
            despesasTableAdapter ta = new despesasTableAdapter();

            if (txtNome.Text == "")
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                MessageBox.Show(" Descrição da despesa é um campo Obrigatório...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return bsalvar;
            }


            // Validar valor da despesa
            if (txtValor.Text == "" || txtValor.Text == ",")
            {
                MessageBox.Show(" Valor de Despesa Inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValor.Focus();
                return bsalvar;
            }
            else
            {
                if (Convert.ToDouble(txtValor.Text) < 0.01)
                {
                    MessageBox.Show(" Valor de Despesa Inválido...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor.Focus();
                    return bsalvar;
                }
            }
            //__________ Validando Data inserida
            txtVenci.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
            string data = txtVenci.Text;
            if (!ValidarData(data))     // chama no form base a função que valida ou não uma data
            {
                MessageBox.Show(" Data Inválida...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVenci.Focus();
                return bsalvar;
            }
            txtVenci.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação
            // fim da validação da data ______________________________________________

            if (Status == StatusCadastro.scInserindo || lbCodDespesa.Text == "-1")
            {
                bsalvar = (ta.Insert(txtNome.Text, Convert.ToDouble(txtValor.Text), Convert.ToDateTime(txtVenci.Text)) > 0);
            }
            if (Status == StatusCadastro.scEditando)
            {
                bsalvar = (ta.AlterarDespesas(txtNome.Text, Convert.ToDecimal(txtValor.Text), Convert.ToDateTime(txtVenci.Text), CodigoGererico) > 0);
                // alterar despesas
            }
            if (bsalvar)
            {
                lbCodDespesa.Text = "-1";
                LimparControles();
                Close();
            }
            return bsalvar;
        }

        public override bool Excluir()
        {
            bool bExcluir = false;
            // instanciar despesas
            C2W.c2wDataSet.despesasDataTable dt = new c2wDataSet.despesasDataTable();
            despesasTableAdapter ta = new despesasTableAdapter();

            bExcluir = (ta.ExcluirDespesa(CodigoGererico) > 0);

            lbCodDespesa.Text = "-1";
            LimparControles();
            Close();
            return bExcluir;
        }

        public override bool Localizar()
        {
            bool bLocalizar = false;
            txtNome.Enabled = true;
            txtValor.Enabled = true;
            txtVenci.Enabled = true;
            return bLocalizar;
        }

       
    }
}
