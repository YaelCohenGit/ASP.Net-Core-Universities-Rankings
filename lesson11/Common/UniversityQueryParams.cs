using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UniversityQueryParams:BaseQueryParams
    {
        public int CountryId { get; set; }
        public int Year { get; set; }
        public int UniversityID { get; set; }
    }
}
