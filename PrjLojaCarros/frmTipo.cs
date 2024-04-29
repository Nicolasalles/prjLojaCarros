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
        String connectionString = @"Server=DBLocadora.mssql.somee.com;Database=DBLocadora; User Id=NicolasLeme_SQLLogin_1;Password=wb8xp3tusi;";
        bool novo;
        public frmTipo()
        {
            InitializeComponent();
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            txtCodTipo.Enabled = false;
            txtTipo.Enabled = false;


            string sql = "SELECT * FROM tblTipoVeiculo";
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
                    totalRegistros = dtTipos.Rows.Count;
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
            txtCodTipo.Text = dtTipos.Rows[registroAtual][0].ToString();
            txtTipo.Text = dtTipos.Rows[registroAtual][1].ToString();

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
            txtTipo.Enabled = true;
            txtTipo.Clear();

            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            txtCodTipo.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (novo)
            {
                string sql = "insert into tblTipoVeiculo (tipoVeiculo " + ") values (' " + txtTipo.Text + " ')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Tipo cadastrado com sucesso!");
                        this.frmTipo_Load(this, e);
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
                txtCodTipo.Enabled = false;
                txtTipo.Enabled = false;
              

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
                string sql = "update tblTipoVeiculo set tipoVeiculo='" + txtTipo.Text +
                     "' where codTipoVeiculo=" + txtCodTipo.Text;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Tipo alterado com sucesso");
                        this.frmTipo_Load(this, e);
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
                txtCodTipo.Enabled = false;
                txtTipo.Enabled = false;

                btnSalvar.Enabled = false;
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

                btnPrimeiro.Enabled = true;
                btnAnterior.Enabled = true;
                btnProximo.Enabled = true;
                btnUltimo.Enabled = true;
                dtTipos = new DataTable();
                frmTipo_Load(this, e);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblTipoVeiculo WHERE codTipoVeiculo=" + txtCodTipo.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Tipo apagado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally { con.Close(); }
            dtTipos = new DataTable();
            this.frmTipo_Load(this, e);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            novo = false;
            txtTipo.Enabled = true;
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
