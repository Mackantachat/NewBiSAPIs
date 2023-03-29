using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewBIS.DataContract
{
    public class Mail
    {
        public string[] To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailEncoding Encoding { get; set; }
        public bool IsBodyHtml { get; set; }
    }
    public enum MailEncoding
    {
        [EnumMember]
        Windows874,
        [EnumMember]
        UTF8
    }
}
