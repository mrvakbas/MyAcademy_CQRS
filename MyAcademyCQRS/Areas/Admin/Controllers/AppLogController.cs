using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppLogController : Controller
    {
        private readonly AppDbContext _context;

        public AppLogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _context.AppLogs.OrderByDescending(x => x.LogDate).ToListAsync();
            return View(logs);
        }
        public async Task<IActionResult> DeleteLog(int id)
        {
            var log = await _context.AppLogs.FindAsync(id);
            if (log != null)
            {
                _context.AppLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}