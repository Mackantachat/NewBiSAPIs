using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_MODE
    {
        public long? MODE_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public int? P_MODE { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
