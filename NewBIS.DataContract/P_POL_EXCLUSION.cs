﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_EXCLUSION
    {
        public long? EXCLUDE_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? EXCLUDE_TRN_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public DateTime? REF_DT { get; set; }
        public string REFERENCE { get; set; }
        public string UNDERWRITE_ID { get; set; }
        public char? TMN { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public char? MINI_UPDATE { get; set; }
        public DateTime? MINI_DT { get; set; }
        public P_POL_EXCLUSION_DETAIL_Collection POL_EXCLUSION_DETAIL_Collection { get; set; }
        public P_POL_EXCLUSION_TMN POL_EXCLUSION_TMN { get; set; }
        public DateTime? TMN_EFF_DT { get; set; }
    }
}
