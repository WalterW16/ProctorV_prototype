using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
