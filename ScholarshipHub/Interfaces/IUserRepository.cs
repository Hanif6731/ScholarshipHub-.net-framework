using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarshipHub.Interfaces
{
    interface IUserRepository:IRepository<User>
    {
        int Get(User user);
        User GetUser(User user);
    }
}
