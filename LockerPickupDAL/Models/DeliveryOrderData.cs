using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupDAL.Models
{
    public class DeliveryOrderRequestData
    {
        public string SiteId { get; set; }
        public string ExtOrderId { get; set; }
        public string OrderDescription { get; set; }
        public int DeliverySla { get; set; }
        public int PickupSla { get; set; }
    }

    public class DeliveryOrderResponseData
    {
        public string DeliveryOrderNumber { get; set; }
        public string DeliveryCd { get; set; }
        public string PickupCd { get; set; }
        public string StatudCd { get; set; }
        public string ExtOrderId { get; set; }
        public string Link { get; set; }
    }
}
