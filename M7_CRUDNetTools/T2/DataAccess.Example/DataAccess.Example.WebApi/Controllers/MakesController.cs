using DataAccess.Example.Core;
using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IQueryExample _queries;

        public MakesController(IQueryExample queries,IWebHostEnvironment web)
        {
            _queries = queries;
        }

        [HttpGet]
        public IEnumerable<Make> Get()
        {
            var result = _queries.GetMakes();
            return result;
        }

        [HttpGet(nameof(GetByPrice))]
        public IEnumerable<Vehicles> GetByPrice()
        {
            var result = _queries.GetVehiclesByPrice(80000, 150000);
            return result;
        }
    }
}
