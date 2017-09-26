using LockerPickupDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Services
{
    public interface IDemoService
    {
        List<OrdersData> GetOrders();
        OrdersData GetOrders(int id);
        OrdersData CreateOrders(OrdersData ordersData);
        OrdersData UpdateOrders(OrdersData ordersData);
        string DeleteOrders(int id);
        List<OrdersDetailsData> GetOrderDetails(int id, int? groupId);
    }
}
