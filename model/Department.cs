using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int FloorNumber { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
