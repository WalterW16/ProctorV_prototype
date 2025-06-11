using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRepo;
using Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UserManagment
{
    internal class UserManager : IUserManager
    {
        private User user;
        private IUserRepository userRepository;
        public UserManager() { 
            userRepository = new UserRepository();
            user = new User();
        }

        public User GetUser()
        {
            return user;
        }

        public User LoginUser(string username, string password)
        {
            if (userRepository.VerifyUsername(username))
            {
                if(userRepository.VerifyPassword(username, password))
                {
                    user = userRepository.GetUserByUsername(username);
                    return user;
                }
                else
                {
                    throw new Exception("Invalid password");
                }
            }
            else
            {
                throw new Exception("Invalid User");
            }
        }
    }
}
