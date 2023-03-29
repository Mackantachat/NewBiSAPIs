using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGN_ACCOUNT_TMN
    {
        public long? ASSIGNMENT_ACC_ID { get; set; }
        public string TMN_CAUSE { get; set; }
        public DateTime? TMN_DT { get; set; }
        public string TMN_ID { get; set; }
        public List<P_ASSIGN_ACCOUNT_TMN_REMARK> ASSIGN_ACCOUNT_TMN_REMARK { get; set; }
    }
}
