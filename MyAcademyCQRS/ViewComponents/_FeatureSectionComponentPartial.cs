using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.ViewComponents
{
    public class _FeatureSectionComponentPartial(AppDbContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var feature = await _context.ThreeStepServices.ToListAsync();
            return View(feature); 
        }
    }
}
