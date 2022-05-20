using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserCategories = new HashSet<UserCategory>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public DateTime? TimeDeleted { get; set; }
        public bool IsActive { get; set; }
        public Guid UserCategoryId { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual UserCategory UserCategory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; set; }
    }
}
