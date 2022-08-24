using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CusomBaseController : ControllerBase
    {
        //Bu classın amacı diğer controller classlarımın return kısmında yazmam gereken ok,badrequest vs tarzı ifadeyi elle yazmak yerine burda methot hazırlayıp statuscode da göre kendisinin otomatik yazmasını sağlamak maksadıyla yapıyorum

        [NonAction]// Bu methodun kendi içimde kullanılan bir methot olduğunu belirttim
        public ActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode==204)
                return new ObjectResult(null) { StatusCode=response.StatusCode};
            else
            {
                return new ObjectResult(response) { StatusCode=response.StatusCode};
            }
        }
    }
}
