using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class ThreeDSAuthorization2Request
    {
        private string _operatorId;
        private string _threeDSTransId;

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string ThreeDSTransId { get { return _threeDSTransId; } set { _threeDSTransId = value; } }

    }
}
