using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Shopingcartview
    {
        public IEnumerable<Product> Product { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
