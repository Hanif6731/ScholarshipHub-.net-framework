using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public University GetUniversity(string username)
        {
            return context.Set<University>().SingleOrDefault(u => u.username == username);
        }
    }
}