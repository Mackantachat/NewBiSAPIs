using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_LIFE_ID
    {
        public long? POLICY_ID { get; set; }
        public char? PL_BLOCK { get; set; }
        public string PL_CODE { get; set; }
        public string PL_CODE2 { get; set; }
        public long? SUMM { get; set; }
        public long? INFSUMM { get; set; }
        public decimal? PREMIUM { get; set; }
        public int? P_MODE { get; set; }
        public int? ST_AGE { get; set; }
        public decimal? ASS_TERM { get; set; }
        public decimal? MAT_TERM { get; set; }
        public decimal? PAY_TERM { get; set; }
        public int? POL_YR { get; set; }
        public int? POL_LT { get; set; }
        public int? POL_LF_YR { get; set; }
        public int? POL_LF_LT { get; set; }
        public DateTime? ISU_DT { get; set; }
        public DateTime? ASS_DT { get; set; }
        public DateTime? MAT_DT { get; set; }
        public DateTime? PENSION_DT { get; set; }
        public DateTime? LASTPAY_DT { get; set; }
        public DateTime? NXTDUE_DT { get; set; }
        public decimal? DEPOSIT_INST { get; set; }
        public string OCP_TYPE { get; set; }
        public char? OCP_CLASS { get; set; }
        public char? CTM_TYPE { get; set; }
        public char? SINGLE { get; set; }
        public string PROTECT { get; set; }
        public char? MEDICAL { get; set; }
        public char? STANDARD { get; set; }
        public char? REINSURE { get; set; }
        public string STATUS { get; set; }
        public string SUBSTATUS { get; set; }
        public DateTime? SUBSTATUS_DT { get; set; }
        public DateTime? STATUS_DT { get; set; }
        public String NB_FLG { get; set; }
        public List<P_POL_ADVANCE> POL_ADVANCE { get; set; }
        public List<P_POL_EXCLUSION> POL_EXCLUSION_Collection { get; set; }
        public List<P_POL_PAYER> POL_PAYER { get; set; }
        public List<P_REMARK_ID> REMARK_ID { get; set; }
        public List<P_ED_LFINTEREST> ED_LFINTEREST { get; set; }
        public List<P_ED_LFPLAN> ED_LFPLAN { get; set; }
        public List<P_ED_LFPREMIUM> ED_LFPREMIUM { get; set; }
        public List<P_ED_LFSUMM> ED_LFSUMM { get; set; }
        public List<P_ED_MODE> ED_MODE { get; set; }
        public List<P_ED_OCCUPATION> ED_OCCUPATION { get; set; }
        public List<P_SERVANT_ID> SERVANT_ID { get; set; }
        public P_LFEM LFEM { get; set; }
        public P_AGENT AGENT { get; set; }
        public List<P_ASSIGNMENT_ID> ASSIGNMENT_ID { get; set; }
        public P_ASSIGN_AGENT ASSIGN_AGENT { get; set; }
        public P_CLASS_DETAIL CLASS_DETAIL { get; set; }
        public P_DPA_POLICY DPA_POLICY { get; set; }
        public P_DPA_SPOUSE DPA_SPOUSE { get; set; }
        public P_LFXOCP LFXOCP { get; set; }
        public List<P_WAIVE_PREMIUM_ID> WAIVE_PREMIUM_ID { get; set; }
        public List<P_RIDER_ID> RIDER_ID { get; set; }
        public P_FIRST_DISCOUNT FIRST_DISCOUNT { get; set; }
        public P_SMART_ID_Collection SMART_ID_Collection { get; set; }
        public P_STATUS_HISTORY_Collection STATUS_HISTORY_Collection { get; set; }
        public P_OPA_RENEWAL OPA_RENEWAL { get; set; }
        public P_LFEF LFEF { get; set; }
        public P_PAYMENT_ID_Collection PAYMENT_ID_Collection { get; set; }
        public P_INSTALL INSTALL { get; set; }
        public P_COMPOUND_AGENT_Collection COMPOUND_AGENT_Collection { get; set; }
        public String FREE_FLG { get; set; }
        public String SPOUSE_FLG { get; set; }
        public String EXCLUDE_TPD { get; set; }
        public String MARKETING_TYPE { get; set; }
        public String POLICY_HOLDING { get; set; }
        
    }
}
