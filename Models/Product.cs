﻿using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    public partial class Product
    {

        public Product()
        {
            ProductHasCategory = new HashSet<ProductHasCategory>();
            Pictures = new HashSet<ProductPicture>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<ProductHasCategory> ProductHasCategory { get; set; }
        public virtual ICollection<ProductPicture> Pictures { get; set; }
        public virtual ICollection<OrderHasProduct> OrderHasProducts { get; set; }




    }
}
