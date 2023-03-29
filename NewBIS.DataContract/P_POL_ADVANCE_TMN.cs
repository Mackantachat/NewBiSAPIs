using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_ADVANCE_TMN
    {
        public long? ADVANCE_PRM_ID { get; set; }
        public string TMN_CAUSE { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public P_POL_ADVANCE_TMN_REMARK POL_ADVANCE_TMN_REMARK { get; set; }
    }
}
