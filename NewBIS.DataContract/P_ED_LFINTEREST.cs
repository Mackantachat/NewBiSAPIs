using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_LFINTEREST
    {
        public long? INTEREST_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public decimal? DEPOSIT_INST { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
