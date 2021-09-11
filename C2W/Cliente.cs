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
    public partial class Cliente : C2W.Frm_Base
    {
        public Cliente(string Cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(Cod);
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            if (CodigoGererico > 0)
            {
                Status = StatusCadastro.scEditando;
                HabilitarMenu(true);
                CarregaValores();
            }
        }








        
        public override void CarregaValores()
        {

            // instanciar clientes
            C2W.c2wDataSet.clientesDataTable dtn = new c2wDataSet.clientesDataTable();
            clientesTableAdapter ta = new clientesTableAdapter();

        
            dtn = ta.BuscarCliente(CodigoGererico);
            if (dtn.Rows.Count > 0)
            {
                lbCodUsuario.Text = dtn.Rows[0]["Id"].ToString();
                txtNome.Text = dtn.Rows[0]["Nome"].ToString();
                txtNasceu.Text = dtn.Rows[0]["DT_Nasc"].ToString();
                txtCpf.Text = dtn.Rows[0]["cpf"].ToString();
                txtEmail.Text = dtn.Rows[0]["e_mail"].ToString();
                txtFone1.Text = dtn.Rows[0]["fone1"].ToString();
                txtFone2.Text = dtn.Rows[0]["fone2"].ToString();
                txtCep.Text = dtn.Rows[0]["cep"].ToString();
                txtEndereco.Text = dtn.Rows[0]["endereco"].ToString();
                txtComplemento.Text = dtn.Rows[0]["complemento"].ToString();
                txtBairro.Text = dtn.Rows[0]["bairro"].ToString();
                txtCidade.Text = dtn.Rows[0]["cidade"].ToString();
                txtEstado.Text = dtn.Rows[0]["estado"].ToString();
                txtReferencia.Text = dtn.Rows[0]["referencia"].ToString();
            }
        }


        public override bool Localizar()
        {
            bool bLocalizar = false;
            if (!bLocalizar)
            {
                Close();
            }

            return bLocalizar;
        }

    }
}
