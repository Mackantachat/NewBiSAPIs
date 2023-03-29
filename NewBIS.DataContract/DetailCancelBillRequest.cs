using System;
using System.Collections.Generic;
using System.Text;

namespace NewBIS.DataContract
{
    public  class DetailCancelBillRequest
    {
        public string Policy { get; set; }  
        public  string BillNo { get; set; }
        public string ChannelType { get; set; }
        public string TypeOfChannel { get; set; }
        public string Holding { get; set; }
        public string Work { get; set; }
        public string BillDt { get; set; }
        public string ReasonCode { get; set; }
        public string UserId { get; set; }
        public List<DetailCancelBill> DataCancelBill { get; set; }
    }
     
}
