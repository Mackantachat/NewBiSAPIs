using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NewBIS.BusinessLogic;
using NewBiSAPIs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;


namespace NewBiSAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public IConfiguration _configuration { get; private set; }
        protected readonly ServiceAction serviceAction;
        protected readonly AppSettingsModel _appSettings;
        protected readonly EndpointServiceURLs _endpointServiceURL;
        protected readonly IHostEnvironment _hostingEnvironment;


        public ApiController(IConfiguration config, IHostEnvironment hosting, IOptions<AppSettingsModel> settings)
        {
            _configuration = config;
            _appSettings = settings.Value;
            _hostingEnvironment = hosting;
            _endpointServiceURL = _appSettings.EndpointServiceURLs;
            string connecttionString = _appSettings.DBSettingModel.ConnectionString;
            this.serviceAction = new ServiceAction(connecttionString);
        }

        [HttpGet("Environment")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Environment()
        {
            if (_hostingEnvironment.IsProduction())
            {
                return Ok(new
                {
                    Environment = "This Server is Production Environment",
                    CurrentDateTime = $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}"
                });
            }
            else
            {
                return Ok(new
                {
                    Environment = "This Server is Development Environment",
                    CurrentDateTime = $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}"
                });
            }
        }
        protected IActionResult Success<T>(T data)
        {
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }

        protected ObjectResult ErrorResponse(Exception ex, Guid guid)
        {
            if (_hostingEnvironment.IsProduction())
            {
                if (ex is Oracle.ManagedDataAccess.Client.OracleException || ex.Message.Contains("ORA-"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { ErrorMessage = "InternalException : BLAER-" + guid.ToString("D") });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { ErrorMessage = $"{ex.Message}" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        protected IActionResult ErrorResponse(Exception ex)
        {
            if (_hostingEnvironment.IsProduction())
            {
                if (ex is Oracle.ManagedDataAccess.Client.OracleException || ex.Message.Contains("ORA-"))
                {
                    Guid guid = new Guid();
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { ErrorMessage = "InternalException : BLAER-" + guid.ToString("D") });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { ErrorMessage = $"{ex.Message}" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        protected IsisAppTransportService.AppTransportServiceContractClient InitializeWebServiceIsisAppTransportService()
        {
            try
            {
                IsisAppTransportService.AppTransportServiceContractClient DataInitializeWebService = null;
                System.ServiceModel.BasicHttpBinding binding = SetHttpBindingIsisAppTransportService();
                System.ServiceModel.EndpointAddress endpoint = new System.ServiceModel.EndpointAddress(_endpointServiceURL.IsisAppTransportService);
                DataInitializeWebService = new IsisAppTransportService.AppTransportServiceContractClient(binding, endpoint);
                return DataInitializeWebService;
            }
            catch
            {
                throw;
            }
        }
        private System.ServiceModel.BasicHttpBinding SetHttpBindingIsisAppTransportService()
        {
            try
            {
                System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
                binding.CloseTimeout = TimeSpan.FromMinutes(10);
                binding.OpenTimeout = TimeSpan.FromMinutes(10);
                binding.SendTimeout = TimeSpan.FromMinutes(10);
                binding.MaxBufferPoolSize = Int32.MaxValue;
                binding.MaxBufferSize = Int32.MaxValue;
                binding.MaxReceivedMessageSize = Int32.MaxValue;
                binding.TransferMode = TransferMode.Streamed;
                binding.ReaderQuotas.MaxDepth = Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = Int32.MaxValue;
                return binding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
