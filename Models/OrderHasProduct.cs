using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class OrderHasProduct
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int RoleId { get; set; }
        public decimal Price { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
