using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class UniversityOfferRepository : Repository<UniversityOffer>, IUniversityOfferRepository
    {
        public IEnumerable<UniversityOffer> GetAll(int id)
        {
            return context.Set<UniversityOffer>().Where(u => u.UniversityId == id).ToList();
        }
    }
}