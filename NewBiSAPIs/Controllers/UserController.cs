using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewBiSAPIs.Model;
using System.Net;

namespace NewBiSAPIs.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    [ApiController]
    public class UserController : ApiController
    {
        public UserController(IConfiguration Configuration, IHostEnvironment hosting,IOptions<AppSettingsModel> settings) : base(Configuration,hosting, settings)
        {

        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string nUserId)
        {
            try
            {
                var data = await serviceAction.Get_ZTB_USER(nUserId);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
    }
}
