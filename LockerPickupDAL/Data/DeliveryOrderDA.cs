using LockerPickupDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Data
{
    public class DeliveryOrderDA
    {
        public DeliveryOrderDA()
        {

        }

        public DeliveryOrderResponseData CreateDeliveryOrder(DeliveryOrderRequestData deliveryOrderRequest)
        {
            //var res = new List<DeliveryOrderResponse>() {
            //    new DeliveryOrderResponse { DeliveryCd = "D1", DeliveryOrderNumber = "Do1", ExtOrderId = "E1", Link = "L1", PickupCd = "P1", StatudCd = "S1" },
            //    new DeliveryOrderResponse { DeliveryCd = "D1", DeliveryOrderNumber = "Do1", ExtOrderId = "E1", Link = "L1", PickupCd = "P1", StatudCd = "S1" }
            //};
            var res = new DeliveryOrderResponseData() { DeliveryCd = "D1", DeliveryOrderNumber = "Do1", ExtOrderId = "E1", Link = "L1", PickupCd = "P1", StatudCd = "S1" };
            
            return res;
        }
    }
}
