using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGN_ACCOUNT
    {
        public long? ASSIGNMENT_ACC_ID { get; set; }
        public long? ASSIGNMENT_ID { get; set; }
        public long? ACCOUNT_ID { get; set; }
        public DateTime? EFF_DT { get; set; }
        public char? TMN { get; set; }
        public char? APPROVE_BY { get; set; }
        public char? CHECK_RESULT { get; set; }
        public DateTime? CHECK_DT { get; set; }
        public string APPROVE_ID { get; set; }
        public P_ASSIGN_ACCOUNT_TMN ASSIGN_ACCOUNT_TMN { get; set; }
    }
}
