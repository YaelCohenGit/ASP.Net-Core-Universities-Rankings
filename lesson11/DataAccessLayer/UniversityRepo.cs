using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccessLayer
{
    public class UniversityRepo : IUniversityRepo
    {
        AcademyContext context;
        public UniversityRepo(AcademyContext context)
        {
            this.context = context;
        }

        public List<University> GetAll(BaseQueryParams queryParams)
        {
            var universityParams = queryParams as UniversityQueryParams;
            if (universityParams == null)
            {
                throw new Exception($"Invalid query params, expected UniversityQueryParams and got {queryParams.GetType()}");
            }


            var queryable = context.Universities.AsQueryable();
            if (universityParams.CountryId > 0)
            {
                queryable = queryable.Where(u => u.CountryId == universityParams.CountryId);
            }

            return queryable.ToList();
        }
    }
}
