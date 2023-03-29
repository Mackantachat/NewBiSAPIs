using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_REMARK_ID
    {
        public long? REMARK_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? REMARK_TRN_DT { get; set; }
        public char? REMARK_FLG { get; set; }
        public string ORDER_PERSON { get; set; }
        public char? PROCESS_FLG { get; set; }
        public DateTime? AUDIT_DT { get; set; }
        public DateTime? AUDIT_RCV_DT { get; set; }
        public string AUDIT_REF { get; set; }
        public DateTime? INFORM_DT { get; set; }
        public string INFORM_DPT { get; set; }
        public DateTime? ATTACH_DT { get; set; }
        public DateTime? ATTACH_RCV_DT { get; set; }
        public string ATTACH_REF { get; set; }
        public DateTime? REPEAL_DT { get; set; }
        public DateTime? REPEAL_TRN_DT { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public P_REMARK_BNF REMARK_BNF { get; set; }
        public P_REMARK_DETAIL REMARK_DETAIL { get; set; }
    }
}
