using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIPractise.model
{
    public partial class UserCategory
    {
        public UserCategory()
        {
            Users = new HashSet<User>();
        }

        public Guid UsercategoryId { get; set; }
        public string UsercategoryDescription { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
