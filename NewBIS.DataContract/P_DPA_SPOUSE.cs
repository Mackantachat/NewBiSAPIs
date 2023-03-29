using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_DPA_SPOUSE
    {
        public long? POLICY_ID { get; set; }
        public DateTime? MAT_DT { get; set; }
        public string PRENAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string IDCARD_NO { get; set; }
        public string PASSPORT { get; set; }
        public DateTime? BIRTH_DT { get; set; }
        public char? SEX { get; set; }
        public string MB_PHONE { get; set; }
        public string NATIONALITY { get; set; }
        public P_DPA_SPSTATUS DPA_SPSTATUS { get; set; }
    }
}
