﻿using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class MessegeRepository : Repository<Messege>, IMessegeRepository
    {
        public IEnumerable<Messege> GetAll(string email)
        {
            return context.Set<Messege>().Where(u => u.ToUser == email || u.FromUser==email);
        }
    }
}