using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class OrderStatusRequest
    {
        private string _orderId;
        private string _productRef;
        private string _operatorId;
        private string _options;

        public OrderStatusRequest() { }

        public OrderStatusRequest(String shopId, String operatorId, String orderId, String productRef, String options)
        {
            this._operatorId = operatorId;
            this._orderId = orderId;
            this._productRef = productRef;
            this._options = options;
        }

        public OrderStatusRequest(String shopId, String operatorId, String orderId)
        {
            this._operatorId = operatorId;
            this._orderId = orderId;
            
        }

        public string OrderId { get { return _orderId; } set { _orderId = value; } }

        public string ProductRef { get { return _productRef; } set { _productRef = value; } }
        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }
        public string Options { get { return _options; } set { _options = value; } }

    }
}
