using System;
using System.Collections.Generic;
using System.Text;
using VPOS_Library.XML.Models;

namespace VPOS_Library.Response
{
    public class CaptureResponse
    {
        public string TransactionID { get; set; }
        public string TimestampReq { get; set; }
        public string TimestampElab { get; set; }
        public string SrcType { get; set; }
        public string Amount { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string OpDesc { get; set; }
        public AuthorizationResponse Authorization { get; set; }
    }
}
