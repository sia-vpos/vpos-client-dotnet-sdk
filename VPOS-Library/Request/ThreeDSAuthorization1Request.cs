using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class ThreeDSAuthorization1Request
    {
        private string _operatorId;
        private string _threeDSTransId;
        private string _threeDSMtdComplInd;

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string ThreeDSTransId { get { return _threeDSTransId; } set { _threeDSTransId = value; } }

        public string ThreeDSMtdComplInd { get { return _threeDSMtdComplInd; } set { _threeDSMtdComplInd = value; } }


    }
}
