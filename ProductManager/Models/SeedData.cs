using ProductManager.ContextFolder;
using ProductManager.Models.Entities;

namespace ProductManager.Models
{
    public class SeedData
    {
        public static void SeedProducts(IApplicationBuilder app)
        {
            DataContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            context.Database.EnsureCreated();

            AddTestProducts(context);
        }

        public static void SetLoginData(IConfiguration configuration)
        {
            LoginData.login = configuration["UserLogin"]!;
            LoginData.password = configuration["UserPassword"]!;
        }

        private static void AddTestProducts(DataContext context)
        {
            if (!context.Products.Any())
            {
                Random rnd = new();
                for (int i = 1; i <= 100; i++)
                {
                    context.Products.Add(
                        new Product
                        {
                            Name = $"testProduct_{i}",
                            Description = $"testProduct_{i}_Description",
                            Price = rnd.Next(20000, 100000)
                        });
                }

                context.SaveChanges();
            }
        }
    }
}
