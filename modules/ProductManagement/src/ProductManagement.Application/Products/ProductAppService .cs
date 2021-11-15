using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace ProductManagement.Products
{
    [Authorize]
    public class ProductAppService : ProductManagementAppService, IProductAppService
    {
        private readonly IRepository<Product,Guid> _productRepository;

        private readonly string culture = CultureInfo.CurrentCulture.Name;

        public ProductAppService(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize("ProductManagement.Products.Create")]
        public async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            var product = ObjectMapper.Map<CreateProductDto, Product>(input);

            var createdProduct = await _productRepository.InsertAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(createdProduct);
        }

        [Authorize("ProductManagement.Products.Delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        [AllowAnonymous]
        public async Task<List<ProductDto>> GetListAsync(Nullable<Guid> filter)
        {
            var products = ObjectMapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetListAsync());
            return (filter == null || filter == Guid.Empty) ? products : products.Where(p => p.CategoryId == filter).ToList();
        }

        [Authorize("ProductManagement.Products.Edit")]
        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            var product = ObjectMapper.Map<UpdateProductDto, Product>(input);
            
            var updatedProduct = await _productRepository.UpdateAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(updatedProduct);
        }
        
    }
}
