using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RDXOCP
    {
        public long? RIDER_XOCP_ID { get; set; }
        public long? RIDER_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public string XOCP_GRP { get; set; }
        public string XOCP_TYPE { get; set; }
        public decimal? XOCP_RATE { get; set; }
        public decimal? XOCP_PREMIUM { get; set; }
        public int? XOCP_PAY_TERM { get; set; }
        public DateTime? XOCP_LASTPAY_DT { get; set; }
        public char? TMN { get; set; }
        public P_RDXOCP_TMN RDXOCP_TMN { get; set; }
        public List<P_ED_RDXOCP> ED_RDXOCP { get; set; }
    }
}
