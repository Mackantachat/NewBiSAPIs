using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RDSTATUS_HISTORY
    {
        public long? RIDER_STATUS_ID { get; set; }
        public long? RIDER_ID { get; set; }
        public string RDSTATUS { get; set; }
        public DateTime? RDSTATUS_DT { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
