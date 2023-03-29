using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_LFSUMM
    {
        public long? SUMM_ED_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public long? SUMM { get; set; }
        public long? INFSUMM { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
