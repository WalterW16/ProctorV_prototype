using ProctorV_prototype.Messages;
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
    public partial class CreateGroupForm : Form
    {
        private RoleDispatcher roleDispatcher;
        public CreateGroupForm()
        {
            InitializeComponent();
        }
        internal CreateGroupForm(RoleDispatcher sroleDispatcher)
        {
            InitializeComponent();
            this.roleDispatcher = sroleDispatcher;
            LoadListOfCandidates();
        }
        private void LoadListOfCandidates()
        {
            ActionRequest action = new ActionRequest()
            {
                Action = ActionType.SeeAvailableCandidates
            };

            ActionResult res = roleDispatcher.HandleAction(action);

            if (res.Success == true && res.info.ContainsKey("List"))
            {
                var list = res.info["List"] as List<Tuple<string, string, string>>;

                if (list != null)
                {
                    foreach (var cand in list)
                    {
                        string displayName = $"{cand.Item1}   {cand.Item2}   ({cand.Item3})"; // FirstName LastName (Username)
                        CandidatesListBox.Items.Add(displayName);
                    }
                }
            }
        }
        public bool CreateGroup()
        {
            bool result = false;
            try
            {
                List<string> selectedCandidates = CandidatesListBox.SelectedItems.Cast<string>().ToList();
                List<string> usernames = new List<string>();
                string NameOfGroup = GroupNameTextBox.Text;
                foreach (var cand in selectedCandidates)
                {
                    string firstWord = cand.Split(' ')[0];
                    usernames.Add(firstWord);
                }

                ActionRequest action = new ActionRequest
                {
                    Action = ActionType.CreateNewGroup,
                    Parameters = new Dictionary<string, object>
                {
                    { "Selected", usernames },
                    {"Name", NameOfGroup}
                }
                };
                ActionResult res = roleDispatcher.HandleAction(action);
               result = res.Success;
            }
            catch (Exception ex)
            {   
               
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (GroupNameTextBox.Text == "")
            {
                MessageBox.Show("Group name wasn't specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CandidatesListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Candidates are not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool res =  CreateGroup();
                if (res)
                {
                    MessageBox.Show("Group uccessfully created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
                    GroupNameTextBox.Clear();
                CandidatesListBox.ClearSelected();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
