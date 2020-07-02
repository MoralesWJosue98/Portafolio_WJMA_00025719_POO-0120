using System;
using System.Windows.Forms;
using PREPARCIAL2.CONTROLADOR;
using PREPARCIAL2.MODELO;

namespace PREPARCIAL2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        private void FillControl()
        {
            cmbUser.DataSource = null;
            cmbUser.ValueMember = "user_password";
            cmbUser.DisplayMember = "user_name";
            cmbUser.DataSource = UserDAO.getLista();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Encriptador.CompararMD5(txtPassword.Text, cmbUser.SelectedValue.ToString()))
            {
                User u = (User) cmbUser.SelectedItem;

                MessageBox.Show("Welcome!", "DISTRIBUIDORA 'LA SULTANA'" , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
                frmPrincipal window = new frmPrincipal(u);
                
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Warning! INCORRECT PASSWORD", "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }
        
        
    }
}