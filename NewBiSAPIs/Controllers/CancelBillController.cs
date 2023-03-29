using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewBIS.DataAccess;
using NewBIS.DataContract;
using NewBiSAPIs.Model;
using System.Net;

namespace NewBiSAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelBillController : ApiController
    {
        public CancelBillController(IConfiguration Configuration, IHostEnvironment hosting, IOptions<AppSettingsModel> settings) : base(Configuration, hosting, settings)
        {

        }

        [HttpPost]
        [Route("GetDetailCancelBillV3")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DetailCancelBill), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDetailCancelBillV3([FromBody] DetailCancelBillRequest request)
        {
            try
            {
                var data = await serviceAction.GetDetailCancelBillV3(request);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpPost]
        [Route("ExecuteTask")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DetailCancelBill), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ExecuteTask([FromBody] DetailCancelBillRequest request)
        {
            try
            {
                var inforce = await serviceAction.CheckInforce(request);
                if (!string.IsNullOrEmpty(inforce))
                {
                    if (request.Work.Equals("1"))
                    {
                        if (!string.IsNullOrEmpty(request.BillDt))
                        {
                            ExeTask(request);
                        }
                    }
                    else
                    {
                        ExeTask(request);
                    }
                }

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
        private void ExeTask(DetailCancelBillRequest request)
        {
            string newbis2018 = "";
            var type = serviceAction.isRenewalAllChannel(request.Policy.PadLeft(8, '0'), request.Holding, out newbis2018);
            if (type != "Y")
            {
                switch (request.Work)
                {
                    case "0":
                        {
                            #region " 0: ยกเลิกอย่างเดียว" 
                            string cancelCompleteMsg = "";
                            using (IsisAppTransportService.AppTransportServiceContractClient cIsis = new IsisAppTransportService.AppTransportServiceContractClient())
                            {
                                if (request.DataCancelBill.Count > 0)
                                {
                                    foreach (var data in request.DataCancelBill)
                                    {
                                        IsisAppTransportService.OrdBillingCancel ordBillingCancel = new IsisAppTransportService.OrdBillingCancel();
                                        ordBillingCancel.BillNumber = data.BillNo.ToString();
                                        ordBillingCancel.CancelType = Convert.ToInt32(request.Work.ToString());
                                        ordBillingCancel.ReasonCode = request.ReasonCode.ToString();
                                        ordBillingCancel.UserID = request.UserId;

                                        if (cancelCompleteMsg != "") cancelCompleteMsg += ", ";
                                        cancelCompleteMsg += request.BillNo.ToString();

                                        try
                                        {
                                            cIsis.RequestToCancelBillAsync(ordBillingCancel);
                                        }
                                        catch (Exception ex)
                                        {
                                            //throw new Exception("เกิดความผิดพลาดระหว่างการยกเลิกใบเสร็จ [ RequestToCancelBill ] : " + ex.ToString());
                                        }


                                    }
                                }
                            }

                            #endregion " 0: ยกเลิกอย่างเดียว"
                            break;
                        }
                    case "1":
                        {
                            #region " 1: ออกใหม่" 

                            #endregion " 1: ออกใหม่"
                            break;
                        }
                }
            }
            else
            {
                #region "Renew"
                switch (request.Work)
                {
                    case "0":
                        {
                            #region "0: ยกเลิกอย่างเดียว"

                            #endregion "0: ยกลิกอย่างเดียว"
                            break;
                        }
                    case "1":
                        {
                            #region "1: ออกใหมา"

                            #endregion "1: ออกใหม่"
                            break;
                        }
                }
                #endregion "Renew"
            }

        }
    }
}
