using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace BookStore.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
