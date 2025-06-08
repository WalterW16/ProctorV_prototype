using UserManagment;
using ProctorV_prototype.Core;
namespace ProctorV_prototype
{
    internal class RoleDispatcher
    {
        private IUserManager _userManager;
        private string mode;
        private ExaminerFacade Efacade;
        private CandidateFacade Cfacade;
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
