using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_AGENT
    {

        public long? POLICY_ID { get; set; }
        public string SALE_AGENT { get; set; }
        public string LICENSE_AGENT { get; set; }
        public DateTime? STR_DT { get; set; }
        public string SALE_OFC { get; set; }
        public string LICENSE_OFC { get; set; }
        public char? PAY_COM_FLG { get; set; }
        public DateTime? MARKETING_DT { get; set; }
        public String MARKETING_TYPE { get; set; }
        public String SUBMARKETING_TYPE { get; set; }
        public string SALE_CHANNEL { get; set; }
        public string STAFF_NO { get; set; }
    }
}
