using Common;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace lesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityRankingController : ControllerBase
    {
        IUniversityRankingRepo universityRankingRepo;
        public UniversityRankingController(IUniversityRankingRepo universityRankingRepo)
        {
            this.universityRankingRepo = universityRankingRepo;
        }

        [HttpGet]
        public List<UniversityRankingYear> GetRankingYearList([FromQuery] UniversityQueryParams queryParams)
        {
            return universityRankingRepo.GetAll(queryParams);
        }
    }
}
