using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using System.Threading.Tasks;

namespace MyAcademyCQRS.ViewComponents
{
    public class _OurStoryComponentPartial(AppDbContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _context.Products.ToListAsync();
            return View(basket);
        }
    }
}
