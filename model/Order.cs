using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int ItemId { get; set; }
        public string Status { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeCancelled { get; set; }
        public decimal TotalBill { get; set; }
        public Guid OrdereditemId { get; set; }

        public virtual OrderedItem Ordereditem { get; set; }
        public virtual User User { get; set; }
    }
}
