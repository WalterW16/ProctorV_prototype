using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace UserRepo
{
    internal interface IUserRepository
    {
        bool VerifyUsername(string username);
        bool VerifyPassword(string username, string password);
        string GetRole(string username);
        string GetEmail(string username);
        string GetPhoneNumber(string username);
        string GetLastname(string username);
        string GetFirstname(string username);
        string GetUserName(string phoneNumber, string firstName);
        User GetUserByUsername(string username);
        GroupOfCandidates GetGroupOfCandidates(string groupname);
        List<string> GetGroupsName();
        List<User>GetCandidates();
        void AddGroup(string groupname);
        void RemoveGroup(string groupname);
        void UpdateGroup(GroupOfCandidates group);
    }
}
