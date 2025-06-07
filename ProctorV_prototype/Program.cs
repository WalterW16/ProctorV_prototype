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

            var currentUser = GetUserCredentials();
            if (currentUser != null)
            {
                if (currentUser.Role == "examiner")
                {
                    Application.Run(new ExaminerMainForm());
                    
                }
                else
                {
                    Application.Run(new CandidateMainForm());
                }
            }
        }
        private static User GetUserCredentials()
        {
            LoginForm loginForm = new LoginForm();
       

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                return loginForm.CurrentUser;
            }

            return null;
        }
    }
}
