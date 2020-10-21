using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class OrderHasProduct
    {
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
