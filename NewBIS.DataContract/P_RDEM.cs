using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RDEM
    {
        public long? RIDER_EM_ID { get; set; }
        public long? RIDER_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? EM_PERCENT { get; set; }
        public decimal? EM_PERMUE { get; set; }
        public decimal? EM_PREMIUM { get; set; }
        public int? EM_PAY_TERM { get; set; }
        public DateTime? EM_LASTPAY_DT { get; set; }
        public char? TMN { get; set; }
        public P_RDEM_TMN RDEM_TMN { get; set; }
        public List<P_ED_RDEM> ED_RDEM { get; set; }
    }
}
