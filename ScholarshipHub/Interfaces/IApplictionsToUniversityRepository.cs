using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarshipHub.Interfaces
{
    interface IApplictionsToUniversityRepository : IRepository<ApplictionsToUniversity>
    {
        IEnumerable<ApplictionsToUniversity> GetAll(int uniId);

    }
}
