using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGNMENT_TMN
    {
        public long? ASSIGNMENT_ID { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public long? TMN_TRANSACTION_ID { get; set; }
    }
}
