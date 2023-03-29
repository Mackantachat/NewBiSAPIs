using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_POL_PAYER_TMN
    {
      
        public long? PAYER_ID { get; set; }
        public string TMN_CAUSE { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
    }
}
