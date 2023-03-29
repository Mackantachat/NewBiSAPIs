using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RIDER_ID
    {
        public long? RIDER_ID { get; set; }
        public long? POLICY_ID { get; set; }
        public char? PL_BLOCK { get; set; }
        public string PL_CODE { get; set; }
        public string PL_CODE2 { get; set; }
        public int? SEQ { get; set; }
        public long? SUMM { get; set; }
        public decimal? PREMIUM { get; set; }
        public DateTime? FIRST_ISU_DT { get; set; }
        public DateTime? ISU_DT { get; set; }
        public int? MAT_TERM { get; set; }
        public int? PAY_TERM { get; set; }
        public DateTime? MAT_DT { get; set; }
        public DateTime? LASTPAY_DT { get; set; }
        public DateTime? NXTDUE_DT { get; set; }
        public int? RD_YR { get; set; }
        public int? RD_LT { get; set; }
        public string RDSTATUS { get; set; }
        public DateTime? RDSTATUS_DT { get; set; }
        public char? FREE_FLG { get; set; }
        public char? TMN { get; set; }
        public DateTime? FSYSTEM_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
        public char? MINI_UPDATE { get; set; }
        public DateTime? MINI_DT { get; set; }
        public List<P_RDSTATUS_HISTORY> RDSTATUS_HISTORY { get; set; }
        public List<P_RDXTR> RDXTR { get; set; }
        public List<P_RDEM> RDEM { get; set; }
        public List<P_RDXOCP> RDXOCP { get; set; }
        public P_RD_TMN RD_TMN { get; set; }
        public List<P_RDEF> RDEF { get; set; }
        public List<P_ED_RDSUMM> ED_RDSUMM_Collection { get; set; }
        public P_FAMILY_CUSTOMER FAMILY_CUSTOMER { get; set; }
        public DateTime? TAX_ISU_DT { get; set; }
        public DateTime? EFF_DT { get; set; }
        public decimal? EXTRA_RATE { get; set; }
        public decimal? XTR_PREMIUM { get; set; }
        public decimal? EM_PERCENT { get; set; }
        public int? RIDER_SEQ { get; set; }
    }
}
