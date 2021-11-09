using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class CreateProductDto :EntityDto<Guid>
    {
        [Required]
        [StringLength(ProductConsts.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public float Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}