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
    
    
    public partial class frmVeiculos : Form
    {
        int registroAtual = 0;
        int totalRegistros = 0;
        DataTable dtVeiculos = new DataTable();
        String connectionString = @"Server=darnassus\motorhead;Database=db_230570; User Id=230570;Password=fodase123;";
        bool novo;
        DataTable dtTipos = new DataTable();
        DataTable dtMarcas = new DataTable();

        public frmVeiculos()
        {
            InitializeComponent();
        }

        private void navegar()
        {
            carregaComboMarca();
            carregaComboTipo();
            txtCodVeiculo.Text = dtVeiculos.Rows[registroAtual][0].ToString();
            txtAno.Text = dtVeiculos.Rows[registroAtual][1].ToString();
            txtModelo.Text = dtVeiculos.Rows[registroAtual][2].ToString();
            
        }

        private void carregaComboTipo()
        {
            dtTipos = new DataTable();
            string sql = "Select * from tblTipoVeiculo Where codTipoVeiculo=" +
                dtVeiculos.Rows[registroAtual][4].ToString();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    dtTipos.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            cmBoxTipo.DataSource = dtTipos;
            cmBoxTipo.DisplayMember = "tipoVeiculo";
            cmBoxTipo.ValueMember = "codTipoVeiculo";
        }

        private void carregaComboMarca()
        {
            dtMarcas = new DataTable();
            string sql = "Select * from tblMarca Where codMarca=" +
                dtVeiculos.Rows[registroAtual][3].ToString();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    dtMarcas.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            cmBoxMarca.DataSource = dtMarcas;
            cmBoxMarca.DisplayMember = "marcaVeiculo";
            cmBoxMarca.ValueMember = "codMarca";
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (registroAtual > 0)
            {
                registroAtual = 0;
                navegar();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (registroAtual > 0)
            {
                registroAtual--;
                navegar();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (registroAtual < totalRegistros - 1)
            {
                registroAtual++;
                navegar();
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (registroAtual < totalRegistros - 1)
            {
                registroAtual = totalRegistros - 1;
                navegar();
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            txtCodVeiculo.Enabled = false;
            txtAno.Enabled = false;
            txtModelo.Enabled = false;
            cmBoxMarca.Enabled = false;
            cmBoxTipo.Enabled = false;

            string sql = "SELECT * FROM tblVeiculo";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    dtVeiculos.Load(reader);
                    totalRegistros = dtVeiculos.Rows.Count;
                    registroAtual = 0;
                    navegar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }
    }
}
