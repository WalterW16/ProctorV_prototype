using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagment;

namespace ProctorV_prototype
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);     
           
            var userManager = GetUserManager();
            RoleDispatcher roleDispatcher = new RoleDispatcher(userManager);

            if (roleDispatcher.getMode() != null)
            {
                if (roleDispatcher.getMode() == "examiner")
                {
                    Application.Run(new ExaminerMainForm());
                    
                }
                else
                {
                    Application.Run(new CandidateMainForm());
                }
            }
        }
        private static IUserManager GetUserManager()
        {
            LoginForm loginForm = new LoginForm();
       

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                return loginForm.manager;
            }

            return null;
        }
    }
}
