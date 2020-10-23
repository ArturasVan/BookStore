using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookStore.Models
{
    public partial class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }


        public string ApplicationUserId { get; set; }
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity{ get; set; }
        public string DeliveryZip { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderHasProduct> OrderHasProducts { get; set; }
    }
}
