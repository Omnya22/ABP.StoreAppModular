using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement.Web.Pages.ProductManagement.Products
{
    public class IndexModel : ProductManagementPageModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;

        public IndexModel(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryAppService.GetListAsync();
            Products = await _productAppService.GetListAsync(Guid.Empty);
        }

        public async Task OnPostAsync(Guid selected)
        {
            Categories = await _categoryAppService.GetListAsync();
            Products = await _productAppService.GetListAsync(selected);
        }

    }
}
