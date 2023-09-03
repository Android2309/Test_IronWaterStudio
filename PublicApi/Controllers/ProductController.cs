using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.ContextFolder;
using System.Text.Json;

namespace PublicApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext context;

        public ProductController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<string> GetAll(string? searchName = "", decimal priceFrom = 0, decimal priceTo = 1000000)
        {
            var products = context.Products
                .Where(x => x.Price >= priceFrom && x.Price <= priceTo)
                .Select(product => new { product.Id, product.Name, product.Price });

            if (!string.IsNullOrWhiteSpace(searchName))
                products = products.Where(x => x.Name.Contains(searchName));

            var productList = await products.ToListAsync();

            return JsonSerializer.Serialize(productList);
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return JsonSerializer.Serialize(product);
        }
    }
}