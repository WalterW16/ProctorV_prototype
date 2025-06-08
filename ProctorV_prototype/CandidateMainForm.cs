using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProctorV_prototype
{
    public partial class CandidateMainForm : Form
    {
        private RoleDispatcher _roleDispatcher;
        public CandidateMainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        internal CandidateMainForm(RoleDispatcher roleDispatcher)
        {
            this._roleDispatcher = roleDispatcher;
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            ProfileSubPanel.Visible = false;
            TestSubPanel.Visible = false;              
        }
        private void hideSubMenu()
        {
            if (TestSubPanel.Visible == true)
                TestSubPanel.Visible = false;
            if(ProfileSubPanel.Visible == true)
                ProfileSubPanel.Visible = false;
        }
        private void showSubMenu(Panel sub)
        {
            if (sub.Visible == false)
            {
                hideSubMenu();
                sub.Visible = true;
            }
            else
            {
                sub.Visible = false;
            }
        }

        private void TestsBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(TestSubPanel);
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(ProfileSubPanel);
        }

        private void TakeTestBtn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void MyDataBtn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.Close();
        }
    }
}
