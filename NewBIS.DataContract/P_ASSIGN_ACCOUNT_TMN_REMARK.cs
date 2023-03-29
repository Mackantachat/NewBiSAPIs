using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGN_ACCOUNT_TMN_REMARK
    {
        public long? ASSIGN_ACC_ID { get; set; }
        public long? ASSIGNMENT_ACC_ID { get; set; }
        public string REMARK { get; set; }
    }
}
