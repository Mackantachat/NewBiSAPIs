using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_RDXPRM
    {
        public long? RDXTR_ED_ID { get; set; }
        public long? RIDER_XTR_ID { get; set; }
        public decimal? XTR_PREMIUM { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? XTR_RATE { get; set; }
        public int? XTR_PAY_TERM { get; set; }
        public DateTime? XTR_LASTPAY_DT { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
