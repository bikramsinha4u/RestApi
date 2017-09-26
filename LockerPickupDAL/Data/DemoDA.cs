using LockerPickupDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Data
{
    public class DemoDA
    {
        private static List<OrdersData> ordersList = new List<OrdersData>() {
            new OrdersData() { Id = 1, Name = "Bk" },
            new OrdersData() { Id = 2, Name = "Sk" },
            new OrdersData() { Id = 3, Name = "Pk" },
            new OrdersData() { Id = 4, Name = "Gk" },
            new OrdersData() { Id = 5, Name = "Dk" },
        };
        private static List<OrdersDetailsData> ordersDetailsList = new List<OrdersDetailsData>() { new OrdersDetailsData() { GroupId = 1, Id = 1, Name = "Bks", Phone = "1234"  },
            new OrdersDetailsData() { GroupId = 1, Id = 2, Name = "Sks", Phone = "5678" },
            new OrdersDetailsData() { GroupId = 2, Id = 3, Name = "Sks", Phone = "9012" }
        };

        public List<OrdersData> GetOrders()
        {
            return ordersList;
        }

        public OrdersData CreateOrders(OrdersData ordersData)
        {
            var exists = ordersList.Any(r => r.Name.ToLower() == ordersData.Name.ToLower());

            if (exists)
            {
                return null;
            }
            else
            {
                var maxIdObject = ordersList.OrderByDescending(r => r.Id).FirstOrDefault();
                ordersList.Add(new OrdersData() { Id = maxIdObject.Id + 1, Name = ordersData.Name });

                return ordersList.OrderByDescending(r => r.Id).FirstOrDefault();
            }
        }

        public OrdersData UpdateOrders(OrdersData ordersData)
        {
            var exists = ordersList.Any(r => r.Id == ordersData.Id);

            if (exists)
            {
                var data = ordersList.FirstOrDefault(r => r.Id == ordersData.Id);
                data.Name = ordersData.Name;

                return data;
            }
            else
            {
                return null;
            }
        }

        public string DeleteOrders(int id)
        {
            var exists = ordersList.Any(r => r.Id == id);

            if (exists)
            {
                var data = ordersList.RemoveAll(x => x.Id == id);

                return "Deleted";
            }
            else
            {
                return null;
            }
        }

        public List<OrdersDetailsData> GetOrderDetails(int id, int? groupId)
        {
            if (groupId == null)
                return ordersDetailsList.FindAll(r => r.Id == id);
            else
                return ordersDetailsList.FindAll(r => r.GroupId == groupId);


        }
    }
}
