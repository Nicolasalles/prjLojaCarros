using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLojaCarros
{
    public partial class frmMarca : Form
    {
        int registroAtual = 0;
        int totalRegistros = 0;
        DataTable dtMarcas = new DataTable();
        String connectionString = @"Server=darnassus\motorhead;Database=db_230570; User Id=230570;Password=fodase123;";
        bool novo;
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
