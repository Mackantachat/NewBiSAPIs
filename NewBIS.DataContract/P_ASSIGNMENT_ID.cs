using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_ASSIGNMENT_ID
    {
        public long? ASSIGNMENT_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public long? NAME_ID { get; set; }
        public DateTime? ENDS_DT { get; set; }
        public string REFERENCE { get; set; }
        public DateTime? REF_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public DateTime? CONTRACT_DT { get; set; }
        public char? DEVIDEND_AS_FLG { get; set; }
        public decimal? DEVIDEND_PC { get; set; }
        public char? MAT_SUM_AS_FLG { get; set; }
        public decimal? MAT_SUM_PC { get; set; }
        public char? LOAN_AS_FLG { get; set; }
        public decimal? LOAN_PC { get; set; }
        public char? SURRENDER_AS_FLG { get; set; }
        public decimal? SURRENDER_PC { get; set; }
        public DateTime? MAT_DT { get; set; }
        public char? TMN { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public string PRENAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public char? MINI_UPDATE { get; set; }
        public DateTime? MINI_DT { get; set; }
        public string OLD_REFERENCE { get; set; }
        public string APPROVE_STATUS { get; set; }
        public string APPROVE_ID { get; set; }
        public DateTime? APPROVE_DT { get; set; }
        public P_ASSIGNMENT_REMARK ASSIGNMENT_REMARK { get; set; }
        public P_ASSIGNMENT_TMN ASSIGNMENT_TMN { get; set; }
        public List<P_ASSIGN_ACCOUNT> ASSIGN_ACCOUNT { get; set; }
    }
}
