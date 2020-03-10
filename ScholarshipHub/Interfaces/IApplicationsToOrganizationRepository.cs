using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarshipHub.Interfaces
{
    interface IApplicationsToOrganizationRepository : IRepository<ApplicationsToOrganization>
    {
        IEnumerable<ApplicationsToOrganization> GetAll(int uniId);
        IEnumerable<ApplicationsToOrganization> GetStudentsApplicationToOrganization(int id);
    }
}
