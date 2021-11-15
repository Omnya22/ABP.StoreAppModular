using System;
using Volo.Abp.Domain.Entities;

namespace ProductManagement.Products
{
    public class Product : Entity<Guid>
    {
        public string TitleAr { get; set; }
        
        public string TitleEn { get; set; }

        public string DescriptionAr { get; set; }
        
        public string DescriptionEn { get; set; }

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
