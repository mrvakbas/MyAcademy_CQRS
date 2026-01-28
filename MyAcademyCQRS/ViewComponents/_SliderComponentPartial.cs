using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.ViewComponents
{
    public class _SliderComponentPartial(AppDbContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slider = await _context.Sliders.ToListAsync();
            return View(slider);
        }
    }
}
