using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class ApplicationToOrganizationRepository : Repository<ApplicationsToOrganization>, IApplicationToOrganizationRepository
    {
        public IEnumerable<ApplicationsToOrganization> GetApp()
        {
            return context.Set<ApplicationsToOrganization>().Where(x => x.AplicationStatus == null);
        }

        public IEnumerable<ApplicationsToOrganization> GetApprove()
        {
            return context.Set<ApplicationsToOrganization>().Where(x => x.AplicationStatus == 1);
        }
    }



}