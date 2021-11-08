using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace StoreApp.Pages
{
    public class Index_Tests : StoreAppWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
