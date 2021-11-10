using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products
{
    public class ProductAppService : ProductManagementAppService, IProductAppService
    {
        private readonly IRepository<Product,Guid> _productRepository;

        public ProductAppService(IRepository<Product, Guid> productRepository)
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

        //override the GetList method to enable searching (in here I only search by book name, you can also search by other props)
        //public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto? input)
        //{
        //    var queryable = await _productRepository.GetQueryableAsync();

        //    //var query = queryable.Where(p => p.CategoryId == input.Filter);
        //                                //.OrderBy(input.Sorting ?? nameof(Product.Title).ToLower())
        //                                //.PageBy(input);

        //    var count = await AsyncExecuter.CountAsync(queryable);

        //    var products = await AsyncExecuter.ToListAsync(queryable);

        //    var result = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);

        //    return new PagedResultDto<ProductDto> { Items = result };
        //}

        public async Task<List<ProductDto>> GetListAsync(Nullable<Guid> filter)
        {
            var products = ObjectMapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetListAsync());

            return (filter == null || filter == Guid.Empty) ?  products : products.Where(p => p.CategoryId == filter).ToList();
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            var product = ObjectMapper.Map<UpdateProductDto, Product>(input);

            var createdProduct = await _productRepository.UpdateAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(createdProduct);
        }
        
    }
}
