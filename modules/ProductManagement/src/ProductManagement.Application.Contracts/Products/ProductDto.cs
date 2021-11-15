using System;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public string TitleAr { get; set; }

        public string DescriptionAr { get; set; }
        
        public string TitleEn { get; set; }

        public string DescriptionEn { get; set; }

        public float Price { get; set; }
        
        public string PicPath { get; set; }

        public Guid CategoryId { get; set; }
    }
}
