using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class P_RIDER_ADVANCE
    {
        public long? ADVANCE_PRM_ID { get; set; }
        public int? RD_PRM                            {get;set;}
        public int? RD_EFF_YR                         {get;set;}
        public int? RD_EFF_LT                         {get;set;}
        public DateTime? RD_EFF_DT                    {get;set;}
        public int? RD_LAST_YR                        {get;set;}
        public int? RD_LAST_LT                        {get;set;}
        public DateTime? RD_LAST_DT                   {get;set;}
        public int? RD_RETURN_PRM                     {get;set;}
        public char? TMN                              {get;set;}
        public P_RIDER_ADVANCE_TMN RIDER_ADVANCE_TMN  {get;set;}
    }
}
