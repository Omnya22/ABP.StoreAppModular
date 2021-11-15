using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement.Web.Pages.ProductManagement.Products
{
    public class EditModel : ProductManagementPageModel
    {
        [BindProperty]
        public UpdateProductDto Product { get; set; }

        [BindProperty]
        public string Photo { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }

        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IWebHostEnvironment _webHost;

        public EditModel(IProductAppService productAppService, ICategoryAppService categoryAppService, IWebHostEnvironment webHost)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _webHost = webHost;
        }

        public async Task OnGet(Guid id)
        {
            var prodcutDto = await _productAppService.GetAsync(id);
            Product =  ObjectMapper.Map <ProductDto, UpdateProductDto>(prodcutDto);
            Categories = await _categoryAppService.GetListAsync();
            Photo = Product.PicPath == null ? _webHost.WebRootPath + "\\Images\\" + "dafult.png" : _webHost.WebRootPath + "\\Images\\" + Product.PicPath;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Request.Form.Files.Count > 0)
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _webHost.WebRootPath + "\\Images\\" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                if (ModelState.IsValid)
                {
                    Product.PicPath = filename;
                    await _productAppService.UpdateAsync(Product.Id, Product);
                    return RedirectToPage("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Product.PicPath = _webHost.WebRootPath + "\\Images\\" + "dafult.png";
                    await _productAppService.UpdateAsync(Product.Id, Product);
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
