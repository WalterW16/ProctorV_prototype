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
        }
        private void LoadListOfCandidates()
        {
            ActionRequest action = new ActionRequest() {
                Action = ActionType.SeeAvailableCandidates
            };
            ActionResult res = roleDispatcher.HandleAction(action);
        }
    }
}
