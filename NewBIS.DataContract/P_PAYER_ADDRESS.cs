using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_PAYER_ADDRESS
    {
        public long? PAYER_ID { get; set; }
        public int? ADDRESS_TYPE { get; set; }
        public string ADDRESS_NUMBER { get; set; }
        public string ADDRESS_NAME { get; set; }
        public string MOOH { get; set; }
        public string SOI { get; set; }
        public string ROAD { get; set; }
        public string TAMBOL { get; set; }
        public string AMPHUR { get; set; }
        public string PROVINCE { get; set; }
        public string ZIP_CODE { get; set; }
        public string PHONE_NUMBER { get; set; }
        public char? TMN { get; set; }
        public P_POL_PAYER_ADDRESS_TMN POL_PAYER_ADDRESS_TMN { get; set; }
    }
}
