using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment;
namespace ProctorV_prototype
{
    internal class RoleDispatcher
    {
        private IUserManager _userManager;
        private string mode;
        public RoleDispatcher(IUserManager manager)
        {
            _userManager = manager;
            mode = manager.GetUser().Role;
        }        
        public string getMode()
        {
            return mode;
        }
    }
}
