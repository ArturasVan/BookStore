using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ProductPicture
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }

        public virtual Product Product { get; set; }
    }
}
