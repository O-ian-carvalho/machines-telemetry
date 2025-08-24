using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MachinesTelemetry.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected Object BuildErrorResponse(int statusCode, string title, string? detail = null)
        {
            return new
            {
                StatusCode = statusCode,
                Title = title,
                Detail = detail
            };
        }

    }
}
