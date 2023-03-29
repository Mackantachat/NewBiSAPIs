using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_REMARK_BNF
    {
        public long? REMARK_ID { get; set; }
        public string BNFPAY_PERSON { get; set; }
        public char? BNFPAY_TYPE { get; set; }
        public DateTime? BNFPAY_DT { get; set; }
        public decimal? BENEFIT { get; set; }
        public long? ACCOUNT_ID { get; set; }
    }
}
