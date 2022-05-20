using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class Supply
    {
        public Supply()
        {
            Items = new HashSet<Item>();
        }

        public int SupplyId { get; set; }
        public int StockId { get; set; }
        public int SuppliedQuantity { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
