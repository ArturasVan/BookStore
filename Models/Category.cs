using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductHasCategory = new HashSet<ProductHasCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductHasCategory> ProductHasCategory { get; set; }
    }
}
