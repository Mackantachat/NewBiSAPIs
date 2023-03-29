using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_LFXOCP
    {
        public long? POLICY_ID { get; set; }
        public DateTime? ISU_DT { get; set; }
        public string XOCP_GRP { get; set; }
        public string XOCP_TYPE { get; set; }
        public decimal? XOCP_RATE { get; set; }
        public decimal? XOCP_PREMIUM { get; set; }
        public int? XOCP_PAY_TERM { get; set; }
        public DateTime? XOCP_LASTPAY_DT { get; set; }
        public char? TMN { get; set; }
        public List<P_ED_LFXOCP> ED_LFXOCP { get; set; }
        public P_LFXOCP_TMN LFXOCP_TMN { get; set; }
    }
}
