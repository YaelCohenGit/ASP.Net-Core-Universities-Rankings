using Common;
using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace lesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController
    {
        ICountryRepo countryRepo;
        public CountryController(ICountryRepo countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        [HttpGet]
        public ActionResult<List<Country>> GetAll([FromQuery] UniversityQueryParams queryParams)
        {
            return countryRepo.GetAll(queryParams);
        }
    }
}
