using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RDEF
    {
        public long? RIDER_EF_ID { get; set; }
        public long? RIDER_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? EF_PERMUE { get; set; }
        public decimal? EF_PREMIUM { get; set; }
        public int? EF_PAY_TERM { get; set; }
        public DateTime? EF_LASTPAY_DT { get; set; }
        public char? TMN { get; set; }
        public P_RDEF_TMN RDEF_TMN { get; set; }
        public List<P_ED_RDEF> ED_RDEF { get; set; }
    }
}
