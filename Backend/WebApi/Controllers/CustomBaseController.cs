using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtoLayer.CustomResponseDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        public IActionResult CreateActionResultInstance<T>(CustomResponseDto<T> serviceResponse)
        {
            return new ObjectResult(serviceResponse)
            {
                StatusCode = serviceResponse.StatusCode
            };
        }
    }
}
