using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGN_HISTORY
    {
        public long? ASSIGN_AGENT_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public string ASSIGN_AGENT { get; set; }
        public DateTime? ASSIGN_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public string REFERENCE { get; set; }
        public string ASSIGN_CAUSE { get; set; }
        public string ASSIGN_ID { get; set; }
        public char? TMN { get; set; }
        public string TMN_REF { get; set; }
        public string TMN_ID { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_CAUSE { get; set; }
        public string N_ASSIGN_AGENT { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public string N_REFERENCE { get; set; }
        public DateTime? N_EFF_DT { get; set; }
    }
}
