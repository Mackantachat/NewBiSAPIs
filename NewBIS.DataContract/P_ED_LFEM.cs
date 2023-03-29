using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_LFEM
    {
        public long? POLICY_EM_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? EM_PERCENT { get; set; }
        public decimal? EM_PERMUE { get; set; }
        public decimal? EM_PREMIUM { get; set; }
        public int? EM_PAY_TERM { get; set; }
        public DateTime? EM_LASTPAY_DT { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
