using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment;

namespace ProctorV_prototype.Core
{
    internal interface IGroupManager
    {
        void CreateGroup(string name);
        void AddCandidateToGroup(string username, string groupName);
        List<User> GetUsers();
        void RemoveCandidate(string username, string groupName);
        void RemoveGroup(string name);
        void SaveAllGroups();

    }
}
