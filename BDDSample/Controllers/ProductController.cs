using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace CancellationTokenSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private IApplicationDbContext _context;
        public ProductController(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext; 
        }


        [HttpGet("Get-All-Products")]
        public async Task<ActionResult> GetWithEFQueryCancelation()
        {
            var result = await _context.GetProductsAsync(HttpContext.RequestAborted);

            return Ok(result);
        }
    }
}