using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_LFXOCP_TMN
    {
        public long? POLICY_ID { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
