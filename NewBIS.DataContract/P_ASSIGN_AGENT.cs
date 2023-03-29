using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGN_AGENT
    {
        public long? POLICY_ID { get; set; }
        public string ASSIGN_AGENT { get; set; }
        public DateTime? ASSIGN_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public string REFERENCE { get; set; }
        public List<P_ASSIGN_HISTORY> ASSIGN_HISTORY { get; set; }
    }
}
