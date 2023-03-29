using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_FAMILY_CUSTOMER
    {
        public long? RIDER_ID { get; set; }
        public string PRENAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public char? SEX { get; set; }
        public DateTime? BIRTH_DT { get; set; }
        public int? ST_AGE { get; set; }
        public char? OCP_CLASS { get; set; }
        public string OCP_TYPE { get; set; }
        public string IDCARD_NO { get; set; }
        public string PASSPORT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public string UPD_ID { get; set; }
    }
}
