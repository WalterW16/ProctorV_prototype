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
        internal IUserManager manager { set; get; }       
        public LoginForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            manager = new UserManager();
        }
       

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                manager.LoginUser(UserNameTextBox.Text, PasswordTextBox.Text);
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
