using BDDs.ValidationService;
using LaYumba.Functional;
using Microsoft.AspNetCore.Mvc;

namespace BDDs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly INameValidation _nameValidation;

        public ResultsController(INameValidation nameValidation)
            => _nameValidation = nameValidation;

        [HttpPost("post-result/{name}")]
        public Task<IActionResult> Post(string name)
            => _nameValidation.Validate(name)
                .Map(result => result
                    .Match(
                        Invalid: invalid => new BadRequestObjectResult(new { errors = invalid.Select(error => error.Message) }) as IActionResult,
                        Valid: valid => new OkObjectResult(new { message = valid })));
    }
}