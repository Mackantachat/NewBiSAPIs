using NewBIS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewBiSAPIs.Model
{
    public class AppSettingsModel
    {
      
        public DBSettingModel DBSettingModel { get; set; }
        public EndpointServiceURLs EndpointServiceURLs { get; set; }
        public ReDirectPage ReDirectPage { get; set; }

    }
    public class DBSettingModel
    {
        public string ConnectionString { get; set; }
    }
    public class EndpointServiceURLs
    {
        public string IsisAppTransportService { get; set; }


    }
    public class ReDirectPage
    {
        public string MainPage { get; set; }
    }

}

