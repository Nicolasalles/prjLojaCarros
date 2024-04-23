using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLojaCarros
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVeiculos veiculos = new frmVeiculos();
            veiculos.MdiParent = this;
            veiculos.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca marcas = new frmMarca();
            marcas.MdiParent = this;
            marcas.Show();
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo tipos = new frmTipo();
            tipos.MdiParent = this;
            tipos.Show();
        }
    }
}
