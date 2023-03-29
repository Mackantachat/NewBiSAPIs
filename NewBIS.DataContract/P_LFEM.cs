using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_LFEM
    {
        public long? POLICY_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public decimal? EM_PERCENT { get; set; }
        public decimal? EM_PERMUE { get; set; }
        public decimal? EM_PREMIUM { get; set; }
        public int? EM_PAY_TERM { get; set; }
        public DateTime? EM_LASTPAY_DT { get; set; }
        public char? TMN { get; set; }
        public List<P_ED_LFEM> ED_LFEM { get; set; }
        public P_LFEM_TMN LFEM_TMN { get; set; }
    }
}
