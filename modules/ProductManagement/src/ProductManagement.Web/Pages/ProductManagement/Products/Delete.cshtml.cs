using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement.Web.Pages.ProductManagement.Products
{
    public class DeleteModel : ProductManagementPageModel
    {
        [BindProperty]
        public ProductDto Product { get; set; }

        private readonly IProductAppService _productAppService;

        public DeleteModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGet(Guid id)
        {
           Product = await _productAppService.GetAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.DeleteAsync(Product.Id);
            return RedirectToPage("Index");
        }

    }
}
