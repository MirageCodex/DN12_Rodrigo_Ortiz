using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger _logger;
        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exeptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogError(exeptionHandlerFeature.Error, "Unhandled Exeption");
            return Problem(
                detail: exeptionHandlerFeature.Error.StackTrace,
                title: exeptionHandlerFeature.Error.Message
                );
        }
        [Route("/error")]
        public IActionResult HandleError()
        {
            var exeptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogError(exeptionHandlerFeature.Error, "Unhandled Exeption");
            return Problem();
        }
    }
}
