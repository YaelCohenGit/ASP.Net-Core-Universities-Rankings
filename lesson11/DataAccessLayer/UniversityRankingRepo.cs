using Common;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public class UniversityRankingRepo : IUniversityRankingRepo
{
    AcademyContext context;
    public UniversityRankingRepo(AcademyContext context)
    {
        this.context = context;
    }


    public List<UniversityRankingYear> GetAll(BaseQueryParams queryParams)
    {
        var universityParams = queryParams as UniversityQueryParams;
        if (universityParams == null)
        {
            throw new Exception($"Invalid query params, expected UniversityQueryParams and got {queryParams.GetType()}");
        }


        var queryable = context.UniversityRankingYears.AsQueryable();
        if (universityParams.CountryId > 0)
        {
            queryable = queryable.Where(u => u.University.CountryId == universityParams.CountryId);
        }
        if (universityParams.UniversityID > 0)
        {
            queryable = queryable.Where(u => u.UniversityId == universityParams.UniversityID);
        }
        if (universityParams.Year > 2010)
        {
            queryable = queryable.Where(u => u.Year == universityParams.Year);
        }
        queryable = queryable.Include(u => u.University).Include(u => u.RankingCriteria).ThenInclude(u => u.RankingSystem);

        return PagedList<UniversityRankingYear>.ToPagedList(queryable, universityParams.PageNumber, universityParams.PageSize);

    }
}

