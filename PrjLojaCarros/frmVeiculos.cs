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
        String connectionString = @"Server=DBLocadora.mssql.somee.com;Database=DBLocadora; User Id=NicolasLeme_SQLLogin_1;Password=wb8xp3tusi;";
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

        private void carregaTudoTipos()
        {
            dtTipos = new DataTable();
            string sql = "Select * from tblTipoVeiculo";
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

        private void carregaTudoMarca()
        {
            dtMarcas = new DataTable();
            string sql = "Select * from tblMarca";
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

        private void carregaComboTipo()
        {
            dtTipos = new DataTable();
            string sql = "Select * from tblTipoVeiculo Where codTipoVeiculo=" +
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            txtModelo.Enabled = true;
            txtModelo.Clear();
            txtAno.Enabled = true;
            txtAno.Clear();
            cmBoxTipo.Enabled = true;
            cmBoxTipo.SelectedIndex = 0;
            cmBoxMarca.Enabled = true;
            cmBoxMarca.SelectedIndex = 0;

            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnExcluir.Enabled = false;
            carregaTudoTipos();
            carregaTudoMarca();
            cmBoxMarca.SelectedIndex = 0;
            btnAlterar.Enabled = false;
            txtCodVeiculo.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (novo)
            {
                string sql = "insert into tblVeiculo (modeloVeiculo, " +
                    "anoVeiculo, codTipoVeiculo, codMarca) values (' " +
                    txtModelo.Text + " ' , " + txtAno.Text +
                    ",  " + cmBoxTipo.SelectedValue.ToString() +
                    " , ' " + cmBoxMarca.SelectedValue.ToString() + " ')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Veículo cadastrado com sucesso!");
                        this.Form1_Load(this, e);
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
                txtCodVeiculo.Enabled = false;
                txtAno.Enabled = false;
                cmBoxTipo.Enabled = false;
                cmBoxMarca.Enabled = false;

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
                string sql = "update tblVeiculo set modeloVeiculo='" + txtModelo.Text +
                    " ', anoVeiculo= " + txtAno.Text +
                    ", codTipoVeiculo=" + cmBoxTipo.SelectedValue.ToString() +
                    ", codMarca='" + cmBoxMarca.SelectedValue.ToString() + "' where codVeiculo=" + txtCodVeiculo.Text;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Veículo alterado com sucesso");
                        this.Form1_Load(this, e);
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
                txtCodVeiculo.Enabled = false;
                txtAno.Enabled = false;
                cmBoxTipo.Enabled = false;
                cmBoxMarca.Enabled = false;

                btnSalvar.Enabled = false;
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

                btnPrimeiro.Enabled = true;
                btnAnterior.Enabled = true;
                btnProximo.Enabled = true;
                btnUltimo.Enabled = true;
                dtVeiculos = new DataTable();
                Form1_Load(this, e);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblVeiculo WHERE codVeiculo=" + txtCodVeiculo.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Veículo apagado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally { con.Close(); }
            dtVeiculos = new DataTable();
            this.Form1_Load(this, e);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            novo = false;
            txtModelo.Enabled = true;
            txtAno.Enabled = true;
            cmBoxTipo.Enabled = true;
            cmBoxMarca.Enabled = true;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnExcluir.Enabled = false;
            carregaTudoTipos();
            carregaTudoMarca();
            btnAlterar.Enabled = false;
        }
    }
}
