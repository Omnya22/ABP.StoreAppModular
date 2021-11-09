using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products
{
    public class ProductService : ProductManagementAppService, IProductService
    {
        private readonly IRepository<Product,Guid> _productRepository;

        public ProductService(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            var product = ObjectMapper.Map<CreateProductDto, Product>(input);

            var createdProduct = await _productRepository.InsertAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(createdProduct);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetListAsync(Guid? filter)
        {
            var products = ObjectMapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetListAsync());
            
            if (filter == null)
            {
                return products;
            }
            else
            {
                return products.Where(p=>p.CategoryId==filter).ToList();
            }
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            var product = ObjectMapper.Map<UpdateProductDto, Product>(input);

            var createdProduct = await _productRepository.UpdateAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(createdProduct);
        }
        
    }
}
