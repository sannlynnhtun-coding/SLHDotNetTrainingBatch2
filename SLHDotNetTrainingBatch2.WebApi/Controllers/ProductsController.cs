using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SLHDotNetTrainingBatch2.WebApi.Controllers
{
    // api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // process
            // data
            return Ok("Get");
        }

        [HttpPost]
        public IActionResult Create()
        {
            // process
            // data
            return Ok("Create");
        }

        [HttpPut]
        public IActionResult Upsert()
        {
            // process
            // data
            return Ok("Upsert");
        }

        [HttpPatch]
        public IActionResult Update()
        {
            // process
            // data
            return Ok("Update");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            // process
            // data
            return Ok("Delete");
        }
    }
}
