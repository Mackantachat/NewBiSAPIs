using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_DPA_SPSTATUS
    {
        public long? SP_STATUS_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? STATUS_TRN_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public string STATUS { get; set; }
        public string SUBSTATUS { get; set; }
        public long? SUMM { get; set; }
        public int? POL_YR { get; set; }
        public int? POL_LT { get; set; }
        public string STATUS_CAUSE { get; set; }
        public string UPD_ID { get; set; }
        public char? TMN { get; set; }
        public P_DPA_SPSTATUS_TMN DPA_SPSTATUS_TMN { get; set; }
    }
}
