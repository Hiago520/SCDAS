using MySql.Data.MySqlClient;
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

namespace Projeto_AADAS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            if (txtLogin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Login ou senha inválidos", "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtLogin.Clear();
                txtSenha.Clear();
                cbTipo.SelectedIndex = -1;
                txtLogin.Focus();

            }
            else if (txtSenha.Text.Trim().Length == 0)
            {
                MessageBox.Show("Login ou senha inválidos", "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtLogin.Clear();
                txtSenha.Clear();
                cbTipo.SelectedIndex = -1;
                txtLogin.Focus();

            }
            else if (cbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Tipo de Usuário", "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtLogin.Clear();
                txtSenha.Clear();
                cbTipo.SelectedIndex = -1;
                txtLogin.Focus();
            }

            else
            {
                try
                {

                    Classes.Conexao.Conectar();
                    string sql = @"Select * from funcionarios where Login = @Login and Senha = @Senha and tipo = @tipo";
                    MySqlCommand cmd = new MySqlCommand(sql, Classes.Conexao.conn);
                    cmd.Parameters.AddWithValue("Login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("Senha", txtSenha.Text);
                    cmd.Parameters.AddWithValue("tipo", cbTipo.SelectedItem);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (cbTipo.SelectedItem.ToString() == "Administrador")
                        {
                            this.Visible = false;
                            frmMenuPrincipal principal = new frmMenuPrincipal();
                            principal.ShowDialog();

                        }
                        else
                        {
                            this.Visible = false;
                            frmMenuPrincipal principal = new frmMenuPrincipal();
                            principal.btnBackup.Enabled = false;
                            principal.btnFuncionarios.Enabled = false;
                            principal.funcionáriosToolStripMenuItem.Enabled = false;
                            principal.backupToolStripMenuItem.Enabled = false;
                            principal.ShowDialog();


                        }

                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha inválidos", "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    Classes.Conexao.desconectar();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja Sair?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Clear();
            txtSenha.Clear();
            cbTipo.SelectedIndex = -1;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {


        }





        private void button1_Click_1(object sender, EventArgs e)
        {
            Classes.Conexao.Conectar();
            MessageBox.Show("TESTE");

        }
    }
}
