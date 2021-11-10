using System;
using Volo.Abp.Domain.Entities;

namespace ProductManagement.Products
{
    public class Product : Entity<Guid>
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string PicPath { get; set; }

        public float Price { get; set; }

        public Guid CategoryId { get; set; }
        
        protected Product()
        {
        }
        public Product(Guid id) : base(id)
        {
        }
    }
}
