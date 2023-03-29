using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_WAIVE_PREMIUM_BNF
    {
        public long? WAIVE_PRM_ID { get; set; }
        public string BNF_PRENAME { get; set; }
        public string BNF_NAME { get; set; }
        public string BNF_SURNAME { get; set; }
    }
}
