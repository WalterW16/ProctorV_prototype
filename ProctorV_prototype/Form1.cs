using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagment;

namespace ProctorV_prototype
{
    public partial class LoginForm : Form
    {
        private IUserManager userManager = new UserManager(); 
        internal User CurrentUser {  get;  set; }
        public LoginForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentUser = userManager.LoginUser(UserNameTextBox.Text, PasswordTextBox.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
    }
}
