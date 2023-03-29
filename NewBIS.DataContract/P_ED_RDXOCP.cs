using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ED_RDXOCP
    {
        public long? RDXOCP_ED_ID { get; set; }
        public long? RIDER_XOCP_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public string XOCP_GRP { get; set; }
        public string XOCP_TYPE { get; set; }
        public decimal? XOCP_RATE { get; set; }
        public decimal? XOCP_PREMIUM { get; set; }
        public int? XOCP_PAY_TERM { get; set; }
        public DateTime? XOCP_LASTPAY_DT { get; set; }
        public long? TRANSACTION_ID { get; set; }
    }
}
