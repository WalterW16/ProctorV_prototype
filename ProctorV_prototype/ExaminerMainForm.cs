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
    public partial class ExaminerMainForm : Form
    {
        public ExaminerMainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            TestSubpanel.Visible = false;
            GroupSubpanel.Visible = false;
            StatisticSubpanel.Visible = false;
        }
        private void hideSubMenu()
        {
            if (TestSubpanel.Visible == true)
                TestSubpanel.Visible = false;
            if (GroupSubpanel.Visible == true)
                GroupSubpanel.Visible = false;
            if (StatisticSubpanel.Visible == true)
                StatisticSubpanel.Visible = false;
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

        private void TestsButton_Click(object sender, EventArgs e)
        {
            showSubMenu(TestSubpanel);
        }

        private void ScheduleTestbutton_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void ChangeParamButton_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            showSubMenu(GroupSubpanel);
        }

        private void CreateGroupButton_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void GroupOptButton_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void StatButton_Click(object sender, EventArgs e)
        {
            showSubMenu(StatisticSubpanel);
        }

        private void SeeStatButton_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

    }
}
