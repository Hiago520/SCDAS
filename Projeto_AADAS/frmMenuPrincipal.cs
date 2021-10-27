using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_AADAS
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        



        private void atendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void atendidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPesquisa frmPesquisa = new frmPesquisa();
            frmPesquisa.btnEditar.Visible = false;
            frmPesquisa.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionarios frmFuncionários = new frmFuncionarios();
            frmFuncionários.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisa frmPesquisa = new frmPesquisa();
            frmPesquisa.btnEditar.Visible = false;
            frmPesquisa.ShowDialog();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            frmFuncionarios frmFuncionários = new frmFuncionarios();
            frmFuncionários.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            
            
        }

        private void ferramentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup frmBackup = new frmBackup();
            frmBackup.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            frmBackup frmBackup = new frmBackup();
            frmBackup.ShowDialog();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();

        }

        private void sairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja Sair do Sistema?", "Info", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmMenuPrincipal_LocationChanged(object sender, EventArgs e)
        {
            
        }
    }
}
