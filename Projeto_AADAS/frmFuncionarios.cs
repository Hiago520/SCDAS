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
    public partial class frmFuncionarios : Form
    {
        int Codigo = 0;

        public frmFuncionarios()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja retornar ao Menu Principal?", "Info", MessageBoxButtons.YesNo))
            {
                Close();
            }
        }

        private void gbDadosFuncionario_Enter(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            
             
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (txtNome.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha o nome do Funcionário");
                }
                else if (txtCPF.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha com o CPF do Funcionário");
                }
                else if (mskCel.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha com o Celular do Funcionário");
                }
                else if (txtPrograma.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha com o Programa do Funcionário");
                }
                else if (txtCargo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha com o Cargo do Funcionário");
                }
                else if (cbPermissao.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a Permissão");
                }
                else if (txtLogin.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha o Login do Funcionário");
                }
                else if (txtPassword.Text.Trim().Length > 8 || txtPassword.Text.Trim().Length < 6)
                {
                    MessageBox.Show("A senha precisa ter de 6 a 8 caracteres");
                }
                else if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Preencha com o email do Funcionário");
                }
                else
                {
                    Classes.Conexao.Conectar();
                    string sql = @"Select * from funcionarios where Login = @Login";
                    MySqlCommand cmd = new MySqlCommand(sql, Classes.Conexao.conn);
                    cmd.Parameters.AddWithValue("Login", txtLogin.Text);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("Já existe um funcionário com esse login");
                    }
                    else
                    {
                        Classes.Conexao.Conectar();
                        string sql1 = @"Select * from funcionarios where cpf = @cpf";
                        MySqlCommand cmd1 = new MySqlCommand(sql1, Classes.Conexao.conn);
                        cmd1.Parameters.AddWithValue("cpf", txtCPF.Text);

                        MySqlDataReader dr1 = cmd1.ExecuteReader();

                        if (dr1.HasRows)
                        {
                            MessageBox.Show("Já existe um funcionario com este cpf");
                        }
                        else
                        {
                            Classes.Conexao.Conectar();
                            Classes.Funcionarios.inserir(txtNome.Text, txtPrograma.Text, mskCel.Text, txtCargo.Text, txtLogin.Text, txtPassword.Text, txtEmail.Text, cbPermissao.Text, txtCPF.Text);
                            MessageBox.Show("Funcionario Cadastrado !!!");
                            Limpar();

                            dr1.Close();

                            
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
            finally
            {
                Classes.Conexao.desconectar();
                Limpar();
            }
        }
        public void Limpar()
        {
            txtNome.Clear();
            txtCPF.Clear();
            mskCel.Clear();
            txtPrograma.Clear();
            txtCargo.Clear();
            cbPermissao.SelectedIndex = -1;
            txtLogin.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtCPFConsulta.Clear();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(txtCPFConsulta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Preencha com o CPF");
                txtCPFConsulta.Focus();
            }
            else
            {
                try
                {
                    string sql = @"select * from funcionarios where cpf like '" + txtCPFConsulta.Text + "%' ";



                    Classes.Conexao.Conectar();
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand(sql, Classes.Conexao.conn);
                    dt.Load(cmd.ExecuteReader());

                    dataGridView1.DataSource = dt;

                    Codigo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtPrograma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtCPF.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtCargo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtLogin.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtPassword.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    txtEmail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    cbPermissao.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    txtCPF.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnCadastrar.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro :" + ex.Message);
                }
                finally
                {
                    Classes.Conexao.desconectar();
                    
                }
            }
        }

        private void frmFuncionários_Load(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.Conexao.Conectar();
                Classes.Funcionarios.atualizar(txtNome.Text, txtPrograma.Text, mskCel.Text, txtCargo.Text, txtLogin.Text, txtPassword.Text, txtEmail.Text, cbPermissao.Text, txtCPF.Text, Codigo);
                MessageBox.Show("Funcionário Atualizado");
                Limpar();

            }catch(Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
            finally
            {
                Classes.Conexao.desconectar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult op = MessageBox.Show("Deseja excluir o registro", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (op == DialogResult.Yes)
            {
                try
                {
                    Classes.Conexao.Conectar();
                    Classes.Funcionarios.excluir(Codigo);
                    MessageBox.Show("Funcionário Excluído");
                    btnLimpar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro :" + ex.Message);
                }
                finally
                {
                    Classes.Conexao.desconectar();
                }
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}












