using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_SERVANT_ID
    {
        public long? SERVANT_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public string SVT_LEVEL { get; set; }
        public string SVT_ID { get; set; }
        public char? SVT_FLG { get; set; }
        public int? INCOME { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public P_SERVANT_NAME SERVANT_NAME { get; set; }
    }
}
