using Microsoft.AspNetCore.Mvc;
using TestNETFrameworkClassLibrary;

namespace NuGetBug.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetMessageFromNuGetPackage()
        {
            return Json(TestClass.PublicString);
        }
    }
}
