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
    public partial class Frm_Base : Form
    {
        public Frm_Base()
        {
            InitializeComponent();
        }

        private void Frm_Base_Load(object sender, EventArgs e)
        {
            Status = StatusCadastro.scNavegando;
            LimparControles();
            HabilitarMenu(false);
         
        }

        public enum StatusCadastro
        {
            scInserindo , scNavegando , scEditando
        }

        public StatusCadastro Status;

        private void tsbSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Base_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        public void LimparControles()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is MaskedTextBox)
                    (ctr as MaskedTextBox).Text = "";
                if (ctr is TextBox)
                    (ctr as TextBox).Text = "";
                if (ctr is ComboBox)
                    (ctr as ComboBox).SelectedIndex = -1;
                if (ctr is ListBox)
                    (ctr as ListBox).SelectedIndex = -1;
                if (ctr is RadioButton)
                    (ctr as RadioButton).Checked = false;
                if (ctr is CheckBox)
                    (ctr as CheckBox).Checked = false;
                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items)
                        item.SelectedIndex = -1;
                }
                if (ctr is GroupBox)
                {
                    for(int i=0;i<ctr.Controls.Count;i++)
                    {
                        if(ctr.Controls[i] is TextBox)
                        {
                            (ctr.Controls[i] as TextBox).Text = "";
                        }
                    }
                }
            }
        }

        public virtual bool Salvar()
        {
            return false;
        }

        public virtual bool Excluir()
        {
            return false;
        }

        public virtual bool Localizar()
        {
            return false;
        }

        public virtual void CarregaValores()
        {

        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if( Salvar() )
            {
                Status = StatusCadastro.scNavegando;
                LimparControles();
                MessageBox.Show(" Informações Salvas com sucesso...", "Aviso ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja excluir estes dados ? ", "Excluir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Excluir())
                {
                    Status = StatusCadastro.scNavegando;
                    LimparControles();
                    HabilitarMenu(false);
                    MessageBox.Show(" Informações Excluídas com sucesso....", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(" Operação cancelada...", "Alerta ao Usuário !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Status = StatusCadastro.scInserindo;
            LimparControles();
        }
        
        private void tsbLocalizar_Click(object sender, EventArgs e)
        {
            if (Localizar())
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();  
            }

        }

        
        public void HabilitarMenu(bool Bvalue)
        {
            foreach(Control ctr in this.Controls)
            {
                if (ctr is MaskedTextBox)
                    continue;

                if (ctr is ToolStrip)
                    continue;

                if (ctr is TextBox)
                    continue;

                if (ctr is GroupBox)
                    continue;

                if (ctr is Label)
                    continue;

                if (ctr is RadioButton)
                    continue;

                if (ctr is CheckBox)
                    continue;

                if (ctr is CheckedListBox)
                    continue;

                if (ctr is Button)
                    continue;

                ctr.Enabled = Bvalue;
            }

            tsbNovo.Enabled = ( Status == StatusCadastro.scNavegando);

            tsbSalvar.Enabled = (Status == StatusCadastro.scNavegando || Status == StatusCadastro.scInserindo
                || Status == StatusCadastro.scEditando);

            tsbExcluir.Enabled = (Status == StatusCadastro.scEditando);

            tsbLocalizar.Enabled = (Status == StatusCadastro.scNavegando || Status == StatusCadastro.scEditando
                || Status == StatusCadastro.scInserindo);

            tsbSair.Enabled = true;
        }

        public int CodigoGererico;

        public int Autorizacao;

        public void restringe_teclas(KeyPressEventArgs e)   // usada no evento KeyPress
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08) //  && char.IsWhiteSpace(e.KeyChar))  // so aceita numeros e backspace
            {
                e.Handled = true;  //Atribui True no Handled para cancelar o evento
            }
        }

        public void BloquearEspaco(KeyEventArgs e)  // para evento keydow
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
        }

        //public void TiraEspaco(KeyPressEventArgs e)   // para evento keypress
        //{
        //    if(char.IsWhiteSpace(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        public bool ValidarCPF(string Copia_CPF,string Codigo,DataTable dt)
        {
            bool CPF_Valido = false;
            string c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10;  // variáveis usadas para ler cada dígito do cpf
            if (Copia_CPF.Length < 11)
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                return CPF_Valido;
            }
            else
            {
                c0 = Copia_CPF.Substring(0, 1);  // verificar cada digito dO CPF. Se for encontrado dígito
                c1 = Copia_CPF.Substring(1, 1);  // nulo, uma mensagem é reportada ao usuário avisando do erro
                c2 = Copia_CPF.Substring(2, 1);  // do CPF informado.
                c3 = Copia_CPF.Substring(3, 1);  // 
                c4 = Copia_CPF.Substring(4, 1);  //
                c5 = Copia_CPF.Substring(5, 1);  //
                c6 = Copia_CPF.Substring(6, 1);  //
                c7 = Copia_CPF.Substring(7, 1);  //___________________________________________________________
                c8 = Copia_CPF.Substring(8, 1);  // 
                c9 = Copia_CPF.Substring(9, 1);  //
                c10 = Copia_CPF.Substring(10, 1);  //
                if (c0 == " " || c1 == " " || c2 == " " || c3 == " " || c4 == " " || c5 == " "
                              || c6 == " " || c7 == " " || c8 == " " || c9 == " " || c10 == " ")
                {
                    return CPF_Valido;
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (Status == StatusCadastro.scInserindo)
                {
                    return CPF_Valido;
                }
                else
                {
                    if ( Codigo != dt.Rows[0]["id"].ToString())
                    {
                        return CPF_Valido;
                    }
                }
            }
            int v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, soma, resto1, resto2, DigitoFinal1, DigitoFinal2;
            v1 = 10 * int.Parse(c0);
            v2 = 9 * int.Parse(c1);
            v3 = 8 * int.Parse(c2);
            v4 = 7 * int.Parse(c3);
            v5 = 6 * int.Parse(c4);
            v6 = 5 * int.Parse(c5);
            v7 = 4 * int.Parse(c6);
            v8 = 3 * int.Parse(c7);
            v9 = 2 * int.Parse(c8);
            soma = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9;
            resto1 = (soma - ( (soma/11)*11 ) );   
            if(resto1<2)
            {
                DigitoFinal1 = 0;
            }
            else
            {
                DigitoFinal1 = 11 - resto1;
            }
            v1 = 11 * int.Parse(c0);
            v2 = 10 * int.Parse(c1);
            v3 = 9 * int.Parse(c2);
            v4 = 8 * int.Parse(c3);
            v5 = 7 * int.Parse(c4);
            v6 = 6 * int.Parse(c5);
            v7 = 5 * int.Parse(c6);
            v8 = 4 * int.Parse(c7);
            v9 = 3 * int.Parse(c8);
            v10 = 2 * DigitoFinal1;
            soma = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9 +v10;
            resto2 = (soma - ((soma / 11) * 11));
            if (resto2 < 2)
            {
                DigitoFinal2 = 0;
            }
            else
            {
                DigitoFinal2 = 11 - resto2;
            }
            if (DigitoFinal1 ==int.Parse(c9) && DigitoFinal2==int.Parse(c10))
            {
                CPF_Valido = true;
            }
            //MessageBox.Show(" Final do CPF => " + DigitoFinal1 + DigitoFinal2);
            return CPF_Valido;
        }

        public bool ValidarData(String Data)
        {
            bool Data_Valida = false;
            string d0, d1, d2, d3, d4, d5, d6, d7;  // variáveis usadas para ler cada dígito da data
            string p1, p2, p3;  // variáveis p1 = dia    -   p2 = mês   -   p3 = ano
            if (Data.Length < 8)
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                return Data_Valida;
            }
            else
            {
                d0 = Data.Substring(0, 1);  // verificar cada digito da data. Se for encontrado dígito
                d1 = Data.Substring(1, 1);  // nulo, uma mensagem é reportada ao usuário avisando do erro
                d2 = Data.Substring(2, 1);  // da data de nascimento informada.
                d3 = Data.Substring(3, 1);  // 
                d4 = Data.Substring(4, 1);  //
                d5 = Data.Substring(5, 1);  //
                d6 = Data.Substring(6, 1);  //
                d7 = Data.Substring(7, 1);  //___________________________________________________________
                if (d0 == " " || d1 == " " || d2 == " " || d3 == " " || d4 == " " || d5 == " " || d6 == " " || d7 == " ")
                {
                    return Data_Valida;
                }
                p1 = Data.Substring(0, 2);  //p1 é a variável que controla o dia do mes
                p2 = Data.Substring(2, 2);  //p2 controla o numero do mes
                p3 = Data.Substring(4, 4);   //p3 controla o numero do ano
                if (int.Parse(p3) < 1900  || int.Parse(p3) > 2016)
                {
                    return Data_Valida;
                }
                else
                {
                    if (int.Parse(p2) < 1 || int.Parse(p2) > 12)
                    {
                        return Data_Valida;
                    }
                    else
                    {
                        if (int.Parse(p1) < 1 || int.Parse(p1) > 31)
                        {
                            return Data_Valida;
                        }
                    }
                }
            }
            Data_Valida = true;
            return Data_Valida;
        }
        // fim da validação de uma Data  xxx______________________

        public bool ValidarCnpj(string Copia_CNPJ, string Codigo, DataTable dt)
        {
            bool CNPJ_Valido = false;

            // 11.444.777 / 0001 - XX.

            string c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10,c11,c12,c13;  // variáveis usadas para ler cada dígito do cpf
            if (Copia_CNPJ.Length < 14)
            {
                if (Status == StatusCadastro.scEditando)
                {
                    CarregaValores();
                }
                return CNPJ_Valido;
            }
            else
            {
                c0 = Copia_CNPJ.Substring(0, 1);  // verificar cada digito dO CNPJ. Se for encontrado dígito
                c1 = Copia_CNPJ.Substring(1, 1);  // nulo, uma mensagem é reportada ao usuário avisando do erro
                c2 = Copia_CNPJ.Substring(2, 1);  // do CNPJ informado.
                c3 = Copia_CNPJ.Substring(3, 1);  // 
                c4 = Copia_CNPJ.Substring(4, 1);  //
                c5 = Copia_CNPJ.Substring(5, 1);  //
                c6 = Copia_CNPJ.Substring(6, 1);  //
                c7 = Copia_CNPJ.Substring(7, 1);  //___________________________________________________________
                c8 = Copia_CNPJ.Substring(8, 1);  // 
                c9 = Copia_CNPJ.Substring(9, 1);  //
                c10 = Copia_CNPJ.Substring(10, 1);  //
                c11 = Copia_CNPJ.Substring(11, 1);  //
                c12 = Copia_CNPJ.Substring(12, 1);  //
                c13 = Copia_CNPJ.Substring(13, 1);  //
                if (c0 == " " || c1 == " " || c2 == " " || c3 == " " || c4 == " " || c5 == " " || c6 == " " || c7 == " "
                              || c8 == " " || c9 == " " || c10 == " " || c11 == " " || c12 == " " || c13 == " ")
                {
                    return CNPJ_Valido;
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (Status == StatusCadastro.scInserindo)
                {
                    return CNPJ_Valido;
                }
                else
                {
                    if (Codigo != dt.Rows[0]["id"].ToString())
                    {
                        return CNPJ_Valido;
                    }
                }
            }
            // 5,4,3,2,9,8,7,6,5,4,3,2 PESOS PARA CÁLCULO
            int v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, soma, resto1, resto2, DigitoFinal1, DigitoFinal2;
            v1 = 5 * int.Parse(c0);
            v2 = 4 * int.Parse(c1);
            v3 = 3 * int.Parse(c2);
            v4 = 2 * int.Parse(c3);
            v5 = 9 * int.Parse(c4);
            v6 = 8 * int.Parse(c5);
            v7 = 7 * int.Parse(c6);
            v8 = 6 * int.Parse(c7);
            v9 = 5 * int.Parse(c8);
            v10 = 4 * int.Parse(c9);
            v11 = 3 * int.Parse(c10);
            v12 = 2 * int.Parse(c11);

            soma = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9 + v10 + v11 + v12;

            resto1 = (soma - ((soma / 11) * 11));
            if (resto1 < 2)
            {
                DigitoFinal1 = 0;
            }
            else
            {
                DigitoFinal1 = 11 - resto1;
            }

            v1 = 6 * int.Parse(c0);
            v2 = 5 * int.Parse(c1);
            v3 = 4 * int.Parse(c2);
            v4 = 3 * int.Parse(c3);
            v5 = 2 * int.Parse(c4);
            v6 = 9 * int.Parse(c5);
            v7 = 8 * int.Parse(c6);
            v8 = 7 * int.Parse(c7);
            v9 = 6 * int.Parse(c8);
            v10 = 5 * int.Parse(c9);
            v11 = 4 * int.Parse(c10);
            v12 = 3 * int.Parse(c11);
            v13 = 2 * DigitoFinal1;

            soma = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9 + v10 + v11 + v12 + v13;
            resto2 = (soma - ((soma / 11) * 11));
            if (resto2 < 2)
            {
                DigitoFinal2 = 0;
            }
            else
            {
                DigitoFinal2 = 11 - resto2;
            }
            if (DigitoFinal1 == int.Parse(c12) && DigitoFinal2 == int.Parse(c13))
            {
                CNPJ_Valido = true;
            }
            MessageBox.Show(" Final do CNPJ => " + DigitoFinal1 + DigitoFinal2);
        
            return CNPJ_Valido;
        }
        // fim do documento base
    }
}
