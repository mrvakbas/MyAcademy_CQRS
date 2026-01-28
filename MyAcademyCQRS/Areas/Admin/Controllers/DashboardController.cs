using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public DashboardController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var promotions = await _mediator.Send(new GetPromotionQuery());
            ViewBag.PromotionCount = promotions.Count();

            var products = await _mediator.Send(new GetProductQuery());
            ViewBag.ProductCount = products.Count();
            ViewBag.ProductDashboardList = products.Take(4).ToList();

            ViewBag.OrderCount = _context.Orders.Count();
            ViewBag.LogCount = _context.AppLogs.Count();

            ViewBag.AppLogs = await _context.AppLogs
                                   .OrderByDescending(x => x.LogDate)
                                   .Take(10)
                                   .ToListAsync();

            return View(promotions);
        }
    }
}