using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }

        public int ItemcategoryId { get; set; }
        public string ItemcategoryType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
