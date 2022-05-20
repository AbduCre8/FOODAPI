using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class Stock
    {
        public Stock()
        {
            Supplies = new HashSet<Supply>();
        }

        public int StockId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
