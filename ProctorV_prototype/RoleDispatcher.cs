using UserManagment;
using ProctorV_prototype.Core;
using ProctorV_prototype.Messages;

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
            mode = _userManager.GetUser().Role;
            
            Cfacade = new CandidateFacade();
        }        
        public string getMode()
        {
            return mode;
        }
       public ActionResult HandleAction(ActionRequest actionRequest)
        {
            if (mode == "examiner")
            {
                return Efacade.Perform(actionRequest);
            }
            else
            {
                return Cfacade.Perform(actionRequest);
            }
        }
    }
}
