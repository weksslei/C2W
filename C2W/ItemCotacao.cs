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
    public partial class ItemCotacao : Form
    {
        //TipoExecucao,CodProdutoCotado,a,c,NomeProduto
        public int CodigoCotacao, CodigoProduto, Quantidade;
        public double CustoItem;
        public ItemCotacao(int CodCotacao,string CodProduto,string Quant, string Custo, string NomeProduto)
        {
            InitializeComponent();
            CodigoCotacao = CodCotacao;
            CodigoProduto = int.Parse(CodProduto);
            Quantidade = int.Parse(Quant);
            CustoItem = Convert.ToDouble(Custo);
            lblNomeProduto.Text = NomeProduto;

            txtQuantidade.Text = Quant;
            txtValor.Text = Custo;
        }

        private void ItemCotacao_Load(object sender, EventArgs e)
        {
            // instânciar itens cotados
            //C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
            //itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
            //dtItensCotados = taItensCotados.Pesquisa_Excluir(CodigoCotacao,CodigoProduto);
            txtQuantidade.Focus();
        }






        //// instânciar itens cotados
        //C2W.c2wDataSet.itens_cotadosDataTable dtItensCotados = new c2wDataSet.itens_cotadosDataTable();
        //itens_cotadosTableAdapter taItensCotados = new itens_cotadosTableAdapter();
        //dtItensCotados = taItensCotados.ItensCotados(TipoExecucao);
        //            Carrega_Itens_Cotados(dtItensCotados);
        //btnTotal.Text = (String.Format("{0:C}", Somatoria).ToString());

    }
}
