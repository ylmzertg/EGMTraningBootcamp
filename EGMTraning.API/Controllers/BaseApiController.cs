using EGMTraning.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 200)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
