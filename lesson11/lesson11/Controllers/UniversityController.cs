using Common;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        IUniversityRepo universityRepo;
        public UniversityController(IUniversityRepo universityRepo)
        {
            this.universityRepo = universityRepo;
        }

        [HttpGet]
        public ActionResult<List<University>> GetAll([FromQuery]UniversityQueryParams queryParams)
        {
            return universityRepo.GetAll(queryParams);
        }

    }
}
