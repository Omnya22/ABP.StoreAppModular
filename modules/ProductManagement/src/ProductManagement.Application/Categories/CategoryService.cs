using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Categories
{
    public class CategoryService : ProductManagementAppService ,ICategoryService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryService(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryDto>> GetAsync()
        {
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(await _categoryRepository.GetListAsync());
        }
    }
}
