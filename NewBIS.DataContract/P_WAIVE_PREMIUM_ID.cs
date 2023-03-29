using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_WAIVE_PREMIUM_ID
    {
        public long? WAIVE_PRM_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? ENDS_DT { get; set; }
        public string REF { get; set; }
        public char? WAIVE_BY { get; set; }
        public DateTime? CAUSE_DT { get; set; }
        public char? WAIVE_CAUSE { get; set; }
        public DateTime? WAIVE_ST_DT { get; set; }
        public DateTime? WAIVE_END_DT { get; set; }
        public int? WAIVE_YR { get; set; }
        public decimal? WAIVE_PREMIUM { get; set; }
        public char? TMN { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public int? WAIVE_ST_YR { get; set; }
        public DateTime? ENDS_PRINT_DT { get; set; }
        public string BNF_TYPE { get; set; }
        public P_WAIVE_PREMIUM_BNF WAIVE_PREMIUM_BNF { get; set; }
        public P_WAIVE_PREMIUM_REMARK WAIVE_PREMIUM_REMARK { get; set; }
        public P_WAIVE_PREMIUM_TMN WAIVE_PREMIUM_TMN { get; set; }
        public string PERMANENT_TPD { get; set; }
        public DateTime? PERMANENT_TPD_DT { get; set; }
    }
}
