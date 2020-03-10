using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class OrgMessegeRepository : Repository<Messege>, IOrgMessegeRepository
    {
        public IEnumerable<Messege> GetMessege(string email)
        {
            return context.Set<Messege>().Where(x=> x.ToUser==email).ToList();
        }

        public IEnumerable<Messege> GetMessegeset(string email)
        {
            return context.Set<Messege>().Where(x => x.FromUser == email).ToList();
        }
    }
}