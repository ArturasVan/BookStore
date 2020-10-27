using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookStore.Models
{
    public partial class OrderHasProductsVM
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
