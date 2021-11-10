using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using ProductManagement.Categories;
using ProductManagement.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Web.Pages.ProductManagement.Products
{
    public class CreateModel : ProductManagementPageModel
    {

        [BindProperty]
        public CreateProductDto Product { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }

        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;
        private readonly IWebHostEnvironment _webHost;

        public CreateModel(ICategoryAppService categoryAppService, IProductAppService productAppService, IWebHostEnvironment webHost)
        {
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
            _webHost = webHost;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryAppService.GetListAsync();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile uploaded)
        {
            //string imgtxt = Path.GetExtension(uploaded.FileName);
            //if(imgtxt == ".jpg" || imgtxt == ".gif" || imgtxt == ".png")
            //{
            //    var imgSave = Path.Combine(_webHost.WebRootPath, "Images", uploaded.FileName);
            //    var stream = new FileStream(imgSave, FileMode.Create);
            //    await uploaded.CopyToAsync(stream);
            //    stream.Close();
            //    Product.PicPath = imgSave;
            //}
            if (ModelState.IsValid)
            {
                await _productAppService.CreateAsync(Product);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
