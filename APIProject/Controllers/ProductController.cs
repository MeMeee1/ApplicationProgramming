using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "OK";
        }
    }
}
