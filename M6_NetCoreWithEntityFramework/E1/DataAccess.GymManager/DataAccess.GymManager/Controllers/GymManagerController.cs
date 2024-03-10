using DataAccess.GymManager.Core;
using DataAccess.GymManager.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataAccess.GymManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymManagerController : ControllerBase
    {
        private readonly IQuerrysGymManager _queries;

        public GymManagerController(IQuerrysGymManager queries)
        {
            _queries = queries;
        }

        [HttpGet("members-last-week")]
        public IActionResult GetMembersLastWeek()
        {
            var members = _queries.GetMembersLastWeek();
            return Ok(members);
        }

        [HttpGet("products-in-stock-by-type")]
        public IActionResult GetProductsInStockByType()
        {
            var products = _queries.GetProductsInStockByType();
            return Ok(products);
        }

        public class SaleRequest
        {
            public int ProductId { get; set; }
            public int UserId { get; set; }
        }

        [HttpPost("register-sale")]
        public IActionResult RegisterSale([FromBody] SaleRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request body.");
            }

            _queries.RegisterSale(request.ProductId, request.UserId);
            return Ok("Sale registered successfully.");
        }
    }
}
