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
    public partial class ScheduleTestForm : Form
    {
        private RoleDispatcher _roleDispatcher;
        public ScheduleTestForm()
        {
            InitializeComponent();
        }
        internal ScheduleTestForm( RoleDispatcher RoleDispatcher)
        {
            InitializeComponent();
            _roleDispatcher = RoleDispatcher;
        }
    }
}
