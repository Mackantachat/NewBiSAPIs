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
    public class AutbChannelController : ApiController
    {
        public AutbChannelController(IConfiguration Configuration, IHostEnvironment hosting,IOptions<AppSettingsModel> settings) : base(Configuration , hosting, settings)
        {

        }

        [HttpGet]
        [Route("GetAutbChannel")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AutbChannelResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAutbChannel()
        {
            try
            {
                var data = await serviceAction.GetAUTB_CHANNEL();
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
    }
}
