using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ProductManagement.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<List<CategoryDto>> GetAsync();
    }
}
