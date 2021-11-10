using System;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
        
        public string PicPath { get; set; }

        public Guid CategoryId { get; set; }
    }
}
