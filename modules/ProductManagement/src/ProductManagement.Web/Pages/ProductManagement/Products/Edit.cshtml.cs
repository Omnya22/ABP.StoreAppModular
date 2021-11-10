using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement.Web.Pages.ProductManagement.Products
{
    public class EditModel : ProductManagementPageModel
    {
        [BindProperty]
        public UpdateProductDto Product { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }

        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public EditModel(IProductAppService productAppService, ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task OnGet(Guid id)
        {
            var prodcutDto = await _productAppService.GetAsync(id);
            Product =  ObjectMapper.Map <ProductDto, UpdateProductDto>(prodcutDto);
            Categories = await _categoryAppService.GetAsync();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.UpdateAsync(Product.Id,Product);
            return RedirectToPage("Index");
        }
    }
}
