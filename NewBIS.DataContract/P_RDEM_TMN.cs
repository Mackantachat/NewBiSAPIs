using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RDEM_TMN
    {
        public long? RIDER_EM_ID { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
