using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public  class DetailCancelBill
    {
        public string Ppolicy { get; set; }
        public string CertNo { get; set; }
        public string BillNo { get; set; }
        public int? YR { get; set; }
        public int? LT { get; set; }
        public string BillDt { get; set; }
        public int? Pmode { get; set; }
        public string Customer { get; set; }
        public decimal? SumPremium { get; set; }
    }
}
