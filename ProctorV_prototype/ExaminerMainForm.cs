using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProctorV_prototype.Messages;

namespace ProctorV_prototype
{
    public partial class ExaminerMainForm : Form
    {
        internal RoleDispatcher _roleDispatcher;
        private ScheduleTestForm scheduleTestForm;
        private CreateGroupForm createGroupForm;
        private void ShowChildForm(Form form)
        {
            if (MainPanel.Controls.Count > 0)
                MainPanel.Controls[0].Hide(); 

            if (!MainPanel.Controls.Contains(form))
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                MainPanel.Controls.Add(form);
            }

            form.Show();
            form.BringToFront();
        }


        public ExaminerMainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
         internal ExaminerMainForm(RoleDispatcher roleDispatcher)
        {
            this._roleDispatcher = roleDispatcher;
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            TestSubpanel.Visible = false;
            GroupSubpanel.Visible = false;
            StatisticSubpanel.Visible = false;
            ProfileSubpanel.Visible = false;
        }
        private void hideSubMenu()
        {
            if (TestSubpanel.Visible == true)
                TestSubpanel.Visible = false;
            if (GroupSubpanel.Visible == true)
                GroupSubpanel.Visible = false;
            if (StatisticSubpanel.Visible == true)
                StatisticSubpanel.Visible = false;
            if(ProfileSubpanel.Visible == true) 
                ProfileSubpanel.Visible = false;
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
            if(scheduleTestForm==null || scheduleTestForm.IsDisposed)
                scheduleTestForm = new ScheduleTestForm(_roleDispatcher);
            ShowChildForm(scheduleTestForm);
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
            if (createGroupForm == null || createGroupForm.IsDisposed)
                createGroupForm = new CreateGroupForm(_roleDispatcher);
            ShowChildForm(createGroupForm);
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

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(ProfileSubpanel);
        }

        private void MyDataBtn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.Close();
        }
    }
}
