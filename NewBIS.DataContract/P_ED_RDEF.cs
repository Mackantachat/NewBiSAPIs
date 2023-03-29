using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_RDEF
    {

        public long? RDEF_ED_ID { get; set; }
        public long? RIDER_EF_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? EF_PERMUE { get; set; }
        public decimal? EF_PREMIUM { get; set; }
        public int? EF_PAY_TERM { get; set; }
        public DateTime? EF_LASTPAY_DT { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
