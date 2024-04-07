using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccessLayer
{
    public class CountryRepo : ICountryRepo
    {
        AcademyContext context;
        public CountryRepo(AcademyContext context)
        {
            this.context = context;
        }

        public List<Country> GetAll(BaseQueryParams queryParams)
        {
            return context.Countries.ToList();
        }
    }


}
