using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using Entities;

namespace UserManagment
{
     internal interface IUserManager
    {
         User LoginUser (string username, string password);
         User GetUser();
    }
}
