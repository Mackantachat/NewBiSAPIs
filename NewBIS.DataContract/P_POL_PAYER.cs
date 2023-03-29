using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_PAYER
    {
        public long? PAYER_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? EFF_DT { get; set; }
        public char? PAYER_TYPE { get; set; }
        public string RELATION { get; set; }
        public char? TMN { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public P_POL_ORGANIZATION POL_ORGANIZATION { get; set; }
        public P_POL_PAYER_TMN POL_PAYER_TMN { get; set; }
        public P_POL_PERSONAL POL_PERSONAL { get; set; }
        public List<P_PAYER_ADDRESS> PAYER_ADDRESS { get; set; }
    }
}
