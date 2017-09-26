using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrdersDetailsDTO
    {
        public int GroupId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
