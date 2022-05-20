using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class OrderedItem
    {
        public OrderedItem()
        {
            Orders = new HashSet<Order>();
        }

        public Guid OrdereditemId { get; set; }
        public int OrdereditemQuantity { get; set; }
        public decimal OrdereditemAmount { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
