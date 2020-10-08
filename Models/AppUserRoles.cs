using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class AppUserRoles
    {
        public AppUserRoles()
        {
            OrderHasProduct = new HashSet<OrderHasProduct>();
            UserHasRoles = new HashSet<UserHasRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderHasProduct> OrderHasProduct { get; set; }
        public virtual ICollection<UserHasRoles> UserHasRoles { get; set; }
    }
}
