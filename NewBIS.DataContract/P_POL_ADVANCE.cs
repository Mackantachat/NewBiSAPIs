using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_ADVANCE
    {

        public long? ADVANCE_PRM_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public char? INST_FLG { get; set; }
        public decimal? INST_VAL { get; set; }
        public decimal? DISC_INST { get; set; }
        public int? LF_PRM { get; set; }
        public int? LF_EFF_YR { get; set; }
        public int? LF_EFF_LT { get; set; }
        public DateTime? LF_EFF_DT { get; set; }
        public int? LF_LAST_YR { get; set; }
        public int? LF_LAST_LT { get; set; }
        public DateTime? LF_LAST_DT { get; set; }
        public int? LF_RETURN_PRM { get; set; }
        public char? TMN { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public long? UPD_ID { get; set; }
        public char? MINI_UPDATE { get; set; }
        public DateTime? MINI_DT { get; set; }
        public char? MATURITY_PROCESS { get; set; }
        public char? DEPARTMENT { get; set; }
        public P_POL_ADVANCE_TMN POL_ADVANCE_TMN { get; set; }
        public P_RIDER_ADVANCE RIDER_ADVANCE { get; set; }
    }
}
