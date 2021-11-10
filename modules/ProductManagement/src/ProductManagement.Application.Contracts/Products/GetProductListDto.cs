using System;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public Guid Filter { get; set; }
    }
}