using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_RDSUMM
    {
        public long? RDSUM_ED_ID { get; set; }
        public long? RIDER_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public long? SUMM { get; set; }
        public decimal? PREMIUM { get; set; }
        public int? RD_YR { get; set; }
        public int? RD_LT { get; set; }
        public string CAUSE { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
