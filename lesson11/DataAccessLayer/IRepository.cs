using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        List<T> GetAll(BaseQueryParams queryParams);

    }
}
