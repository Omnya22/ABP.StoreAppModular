using ProductManagement.Categories;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace ProductManagement
{
    class ProductManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ProductManagementDataSeedContributor(IRepository<Category, Guid> categoryRepository, IGuidGenerator guidGenerator)
        {
            _categoryRepository = categoryRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() <= 0)
            {
                await _categoryRepository.InsertAsync(
                    new Category(_guidGenerator.Create())
                    {
                        Name = "A"
                    },
                    autoSave: true
                );

                await _categoryRepository.InsertAsync(
                    new Category(_guidGenerator.Create())
                    {
                        Name = "B"
                    },
                    autoSave: true
                );

                await _categoryRepository.InsertAsync(
                    new Category(_guidGenerator.Create())
                    {
                        Name = "C"
                    },
                    autoSave: true
                );
            }
        }
    }

}
