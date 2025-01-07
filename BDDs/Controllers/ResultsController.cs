using BDDs.ValidationService;
using Microsoft.AspNetCore.Mvc;

namespace BDDs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        [HttpPost("post-result/{name}")]
        public IActionResult Post(string name)
            => name.Validate()
                 .Match(invalid => new BadRequestObjectResult(new { message = "name is not valid" }) as IActionResult,
                        valid => new OkObjectResult(new { message = "name is valid" }));
    }
}