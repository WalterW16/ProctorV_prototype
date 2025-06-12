using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using UserRepo;

namespace ProctorV_prototype.Core
{
    internal class GroupManager: IGroupManager
    {
        private IUserRepository _userRepository;
       
        public GroupManager() 
        {
             _userRepository = new UserRepository();

        }

        public void AddCandidateToGroup(string username, string groupName)
        {
            GroupOfCandidates gr = _userRepository.GetGroupOfCandidates(groupName);
            User u = _userRepository.GetUserByUsername(username);
            if(!gr.Contains(u))
            {
              gr.AddCandidate(u);
              _userRepository.UpdateGroup(gr);
            }
            else
            {
                throw new Exception("Already in group!");
            }
           
        }

        public void CreateGroup(string name)
        {
            if (!_userRepository.GetGroupsName().Contains(name))
            { 
                _userRepository.AddGroup(name);
            }
            else
            {
                throw new Exception("Name for group is taken");
            }
        }

        public List<User> GetCandidates() => _userRepository.GetCandidates();

        public void RemoveCandidate(string username, string groupName)
        {
            GroupOfCandidates gr = _userRepository.GetGroupOfCandidates(groupName);
            User u = _userRepository.GetUserByUsername(username);
            if (gr.Contains(u)) 
            { 
                gr.RemoveCandidate(u);
            }
            else
            {
                throw new Exception("User is not in this group");
            }
        }

        public void RemoveGroup(string name)
        {
            if (_userRepository.GetGroupsName().Contains(name))
            {
                _userRepository.RemoveGroup(name);
            }
            else
            {
                throw new Exception("There is no such group");
            }
        }

        public void SaveAllGroups()
        {
            throw new NotImplementedException();
        }
    }
}
