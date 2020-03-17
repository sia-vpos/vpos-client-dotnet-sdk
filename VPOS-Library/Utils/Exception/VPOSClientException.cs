using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Utils.Exception
{
    public class VPOSClientException : System.Exception
    {
        public VPOSClientException(string message) : base(message)
        {
        }
    }
}
