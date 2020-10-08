using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            OrderHasProduct = new HashSet<OrderHasProduct>();
            Orders = new HashSet<Orders>();
            UserHasRoles = new HashSet<UserHasRoles>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BillingAddress { get; set; }
        public int BillingZip { get; set; }
        public string BillingCity { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<OrderHasProduct> OrderHasProduct { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<UserHasRoles> UserHasRoles { get; set; }
    }
}
