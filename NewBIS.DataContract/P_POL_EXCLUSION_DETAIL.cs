using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_EXCLUSION_DETAIL
    {

        public long? EXCLUDE_DET_ID { get; set; }
        public long? EXCLUDE_ID { get; set; }
        public string EXCLUDE { get; set; }
        public DateTime? ADMIT_DT { get; set; }
        public string EXCLUDE_CAUSE { get; set; }
        public char? ENDORSE_PRINTING { get; set; }
        public char? TMN { get; set; }
        public char? MINI_UPDATE { get; set; }
        public DateTime? MINI_DT { get; set; }
        public P_POL_EXCLUSION_DETTMN POL_EXCLUSION_DETTMN { get; set; }
        public P_POL_EXCLUSION_BYPLAN_Collection POL_EXCLUSION_BYPLAN_Collection { get; set; }
    }
}
