using LockerPickupDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Services
{
    public interface IDeliveryOrderService
    {
        DeliveryOrderResponseData CreateDeliveryOrder(DeliveryOrderRequestData deliveryOrderRequest);
    }
}
