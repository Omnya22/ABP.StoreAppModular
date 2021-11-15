using System.IO;
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
                    await _productAppService.CreateAsync(Product);
                    return RedirectToPage("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Product.PicPath = _webHost.WebRootPath + "\\Images\\" + "dafult.png";
                    await _productAppService.CreateAsync(Product);
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
