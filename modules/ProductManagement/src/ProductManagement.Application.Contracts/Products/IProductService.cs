using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ProductManagement.Products
{
    public interface IProductService : IApplicationService
    {
        Task<ProductDto> GetAsync(Guid id);

        Task<List<ProductDto>> GetListAsync(Guid? filter);

        Task<ProductDto> CreateAsync(CreateProductDto input);

        Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input);

        Task DeleteAsync(Guid id);
    }
}
