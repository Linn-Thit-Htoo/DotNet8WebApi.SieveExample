using DotNet8WebApi.SieveExample.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace DotNet8WebApi.SieveExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly SieveProcessor _sieveProcessor;

        public ProductController(AppDbContext context, SieveProcessor sieveProcessor)
        {
            _context = context;
            this._sieveProcessor = sieveProcessor;
        }

        // https://localhost:7153/api/Product?Filters=Name%40%3DCPU
        // https://localhost:7153/api/Product?Filters=Name&Sorts=Id&Page=1&PageSize=3
        [HttpGet]
        public IActionResult GetProducts([FromQuery] SieveModel model)
        {
            var products = _context.Products.AsQueryable();
            products = _sieveProcessor.Apply(model, products);

            return Ok(products);
        }
    }
}
