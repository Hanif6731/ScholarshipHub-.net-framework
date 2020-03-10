using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class ApplictionsToUniversityRepository : Repository<ApplictionsToUniversity>, IApplictionsToUniversityRepository
    {
        public IEnumerable<ApplictionsToUniversity> GetAll(int uniOfferId)
        {
            return context.Set<ApplictionsToUniversity>().Where(u => u.UniversityOfferID == uniOfferId).ToList();
        }
        public IEnumerable<ApplictionsToUniversity> GetStudentsApplicationToUniversity(int studentId)
        {
            return context.Set<ApplictionsToUniversity>().Where(u =>u.StudentId==studentId).ToList();
        }
    }
}