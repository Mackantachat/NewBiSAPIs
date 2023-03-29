using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_LFPLAN
    {
        public long? PLAN_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public char? PL_BLOCK { get; set; }
        public string PL_CODE { get; set; }
        public string PL_CODE2 { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
