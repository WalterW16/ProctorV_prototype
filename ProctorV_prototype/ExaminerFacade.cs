using Entities;
using ProctorV_prototype.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorV_prototype.Core
{
    internal class ExaminerFacade
    {
        private IGroupManager _groupManager;

        public ExaminerFacade()
        {
            _groupManager = new GroupManager();
        }
        public ActionResult Perform(ActionRequest request)
        {
            var req = request.Action;
            switch (req)
            {
                case ActionType.CreateNewGroup:
                    return CreateGroup(request);
                case ActionType.SeeAvailableCandidates:
                    return ShowAvailableCandidates(request);
                default: return null;    
            }
        }
        private ActionResult CreateGroup(ActionRequest request)
        {
            return new ActionResult();
        }
        private ActionResult ShowAvailableCandidates(ActionRequest request)
        {
            List<User> cand = _groupManager.GetUsers();
            ActionResult result = new ActionResult();
            result.Success = true;
            result.info.Add("List", cand);    
            return result;
        }
    }
}
