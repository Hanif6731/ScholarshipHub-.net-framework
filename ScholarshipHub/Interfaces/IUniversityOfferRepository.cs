using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarshipHub.Interfaces
{
    interface IUniversityOfferRepository:IRepository<UniversityOffer>
    {
        IEnumerable<UniversityOffer> GetAll(int id);

    }
}
