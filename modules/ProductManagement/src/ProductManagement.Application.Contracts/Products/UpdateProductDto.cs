using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class UpdateProductDto : EntityDto<Guid>
    {
        [DisplayName("Title")]
        [Required]
        [StringLength(ProductConsts.MaxTitleLength)]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("PicPath")]
        public string PicPath { get; set; }

        [DisplayName("Price")]
        [Required]
        public float Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

    }
}
