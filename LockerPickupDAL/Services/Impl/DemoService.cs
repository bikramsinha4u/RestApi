using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockerPickupDAL.Models;
using LockerPickupDAL.Data;

namespace LockerPickupDAL.Services.Impl
{
    public class DemoService : IDemoService
    {
        private readonly DemoDA _demoDA;
        public DemoService(DemoDA demoDA)
        {
            _demoDA = demoDA;
        }
        public List<OrdersData> GetOrders()
        {
            return _demoDA.GetOrders();
        }

        public OrdersData GetOrders(int id)
        {
            var data = this._demoDA.GetOrders();
            var result = data.FirstOrDefault(r => r.Id == id);

            return result;
        }

        public OrdersData CreateOrders(OrdersData ordersData)
        {
            return this._demoDA.CreateOrders(ordersData);
        }

        public OrdersData UpdateOrders(OrdersData ordersData)
        {
            return this._demoDA.UpdateOrders(ordersData);
        }

        public string DeleteOrders(int id)
        {
            return this._demoDA.DeleteOrders(id);
        }

        public List<OrdersDetailsData> GetOrderDetails(int id, int? groupId)
        {
            return this._demoDA.GetOrderDetails(id, groupId);
        }
    }
}
