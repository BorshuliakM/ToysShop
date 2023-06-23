using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ToysShopIntegrationTest
{
    public class Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public Tests(WebApplicationFactory<Program> factory) => _factory = factory;

        [Theory]
        [InlineData("/")]
        [InlineData("/Admin/Category")]
        [InlineData("/Admin/Toy")]
        [InlineData("/Customer/Home/Privacy")]
        public async Task GetSomePages(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            // if it's not 200-299, it will throw an exception
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

    }
}