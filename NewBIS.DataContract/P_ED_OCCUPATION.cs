using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_OCCUPATION
    {
        public long? CLASS_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public string OCP_TYPE { get; set; }
        public char? OCP_CLASS { get; set; }
        public long? TRANSACTION_ID { get; set; }
        public P_ED_OCCUPATION_DETAIL ED_OCCUPATION_DETAIL { get; set; }
    }
}
