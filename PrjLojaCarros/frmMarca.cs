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
        String connectionString = @"Server=DBLocadora.mssql.somee.com;Database=DBLocadora; User Id=NicolasLeme_SQLLogin_1;Password=wb8xp3tusi;";
        bool novo;
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            txtCodMarca.Enabled = false;
            txtMarca.Enabled = false;


            string sql = "SELECT * FROM tblMarca";
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
                    totalRegistros = dtMarcas.Rows.Count;
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

        private void navegar()
        {
            txtCodMarca.Text = dtMarcas.Rows[registroAtual][0].ToString();
            txtMarca.Text = dtMarcas.Rows[registroAtual][1].ToString();

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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            txtMarca.Enabled = true;
            txtMarca.Clear();

            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            txtCodMarca.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (novo)
            {
                string sql = "insert into tblMarca (marcaVeiculo " + ") values (' " + txtMarca.Text + " ')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Marca cadastrada com sucesso!");
                        this.frmMarca_Load(this, e);
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
                txtCodMarca.Enabled = false;
                txtMarca.Enabled = false;


                btnSalvar.Enabled = false;
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

                btnPrimeiro.Enabled = true;
                btnAnterior.Enabled = true;
                btnProximo.Enabled = true;
                btnUltimo.Enabled = true;
            }
            else
            {
                string sql = "update tblMarca set MarcaVeiculo='" + txtMarca.Text +
                     "' where codMarca=" + txtCodMarca.Text;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Marca alterada com sucesso");
                        this.frmMarca_Load(this, e);
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
                txtCodMarca.Enabled = false;
                txtMarca.Enabled = false;

                btnSalvar.Enabled = false;
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

                btnPrimeiro.Enabled = true;
                btnAnterior.Enabled = true;
                btnProximo.Enabled = true;
                btnUltimo.Enabled = true;
                dtMarcas = new DataTable();
                frmMarca_Load(this, e);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblMarca WHERE codMarca=" + txtCodMarca.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Marca apagada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally { con.Close(); }
            dtMarcas = new DataTable();
            this.frmMarca_Load(this, e);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            novo = false;
            txtMarca.Enabled = true;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
        }
    }
}
