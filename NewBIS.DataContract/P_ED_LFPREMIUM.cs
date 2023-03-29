using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_LFPREMIUM
    {
        public long? PREMIUM_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public long? PREMIUM { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
