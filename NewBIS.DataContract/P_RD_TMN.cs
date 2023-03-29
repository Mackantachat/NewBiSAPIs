using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RD_TMN
    {
        public long? RIDER_ID { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
