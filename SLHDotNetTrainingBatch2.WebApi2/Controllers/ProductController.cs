using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SLHDotNetTrainingBatch2.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            AppDbContextModels.AppDbContext db = new AppDbContextModels.AppDbContext();
            var lst = db.TblProducts.ToList();
            return Ok(lst);
        }
    }
}
