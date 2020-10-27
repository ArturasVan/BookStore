using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class OrderHasProduct
    {
        public int OrderId { get; set; }
        public virtual Orders Orders { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public int ReleaseYear { get; set; }

    }
}
