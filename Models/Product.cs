using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductHasCategory = new HashSet<ProductHasCategory>();
            Pictures = new HashSet<ProductPicture>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<ProductHasCategory> ProductHasCategory { get; set; }
        public virtual ICollection<ProductPicture> Pictures { get; set; }
    }
}
