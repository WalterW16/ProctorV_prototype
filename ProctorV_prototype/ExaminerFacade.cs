using Entities;
using Org.BouncyCastle.Tls;
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
            ActionResult result = new ActionResult();
           try
            {
                string name = request.Parameters["Name"] as string;
                List<string> usernames = request.Parameters["Selected"] as List<string>;    
                _groupManager.CreateGroup(name);
                foreach (var h in usernames)
                    _groupManager.AddCandidateToGroup(h, name);
                result.Success = true;
            }
            catch (Exception ex) {
                result.Success=false;
                throw ex;
            }
            return result;
        }
        private ActionResult ShowAvailableCandidates(ActionRequest request)
        {
            List<User> cand = _groupManager.GetCandidates();
            List<Tuple<string, string, string>> UserInfo = new List<Tuple<string, string, string>>();
            foreach (var user in cand) {
                UserInfo.Add(new Tuple<string, string, string>(user.Username, user.FirstName, user.LastName));
            }
            ActionResult result = new ActionResult();
            result.Success = true;
            result.info.Add("List", UserInfo);    
            return result;
        }
       
    }
}
