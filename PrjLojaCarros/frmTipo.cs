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
    public partial class frmTipo : Form
    {
        int registroAtual = 0;
        int totalRegistros = 0;
        DataTable dtTipos = new DataTable();
        String connectionString = @"Server=darnassus\motorhead;Database=db_230570; User Id=230570;Password=fodase123;";
        bool novo;
        public frmTipo()
        {
            InitializeComponent();
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {

        }
    }
}
