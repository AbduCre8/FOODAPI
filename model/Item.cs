using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class Item
    {
        public Item()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemCategoryId { get; set; }
        public int SupplyId { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual Supply Supply { get; set; }
        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}
