using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Models
{
    public class OrdersData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrdersDetailsData
    {
        public int GroupId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
