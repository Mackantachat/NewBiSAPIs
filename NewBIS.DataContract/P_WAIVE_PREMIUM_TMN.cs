using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_WAIVE_PREMIUM_TMN
    {
        public long? WAIVE_PRM_ID { get; set; }
        public string TMN_REF       {get;set;}
        public string TMN_CAUSE     {get;set;}
        public DateTime? TMN_DT     {get;set;}
        public string TMN_ID        {get;set;}
        public long? TRANSACTION_ID {get;set;}
    }
}
