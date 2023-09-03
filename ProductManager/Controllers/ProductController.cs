using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManager.ContextFolder;
using ProductManager.Models;
using ProductManager.Models.Entities;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext context;

        public ProductController(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!LoginData.isLoggedIn)
                return Redirect("/login");

            return View(await context.Products.ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                var product = await context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await context.AddAsync(model);
                }
                else
                {
                    var product = context.Products.Find(model.Id);

                    if (product == null)
                        return NotFound();

                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.Name = model.Name;
                }
                await context.SaveChangesAsync();

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await context.Products.ToListAsync()) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }


        public async Task<IActionResult> Delete(int id = 0)
        {
            var product = context.Products.Find(id);

            if (product == null)
                return NotFound();

            context.Products.Remove(product);

            await context.SaveChangesAsync();

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await context.Products.ToListAsync()) });
        }
    }
}
