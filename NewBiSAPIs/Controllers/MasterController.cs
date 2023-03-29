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
    public class MasterController : ApiController
    {
        public MasterController(IConfiguration Configuration, IHostEnvironment hosting,IOptions<AppSettingsModel> settings) : base(Configuration,hosting, settings)
        {

        }

        [HttpGet]
        [Route("GetWorkStatus")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DropDownModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWorkStatus()
        {
            try
            {
                List<DropDownModel> workStatus = new List<DropDownModel> { 
                    new DropDownModel { Id = "0" ,Text = "ยกเลิกใบเสร็จ" },
                    new DropDownModel { Id = "1" ,Text = "ออกใบเสร็จใหม่"}
                };

                return Success(workStatus);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpGet]
        [Route("GetReasonCode")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DropDownModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReasonCode()
        {
            try
            {

                var data = await serviceAction.GetReasonCode();
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
    }
}
