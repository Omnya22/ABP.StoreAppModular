using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class UpdateProductDto : EntityDto<Guid>
    {
        [DisplayName("Title")]
        [StringLength(ProductConsts.MaxTitleLength)]
        public string TitleAr { get; set; }

        [DisplayName("Description")]
        public string DescriptionAr { get; set; }

        [DisplayName("Title")]
        [StringLength(ProductConsts.MaxTitleLength)]
        public string TitleEn { get; set; }

        [DisplayName("Description")]
        public string DescriptionEn { get; set; }

        [DisplayName("PicPath")]
        public string PicPath { get; set; }

        [DisplayName("Price")]
        [Required]
        public float Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

    }
}
