using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C2W
{
    public partial class Produtos : C2W.Frm_Base
    {
        public Produtos(string Cod)
        {
            InitializeComponent();
            CodigoGererico = int.Parse(Cod);
        }
    }
}
