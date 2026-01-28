using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Notifications.OrderNotifications;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IMediator _mediator, AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _context.Orders.OrderByDescending(x => x.OrderDate).ToListAsync();
            return View(values);
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            var values = await _context.OrderDetails
                .Include(x => x.Product)
                .Where(x => x.OrderID == id)
                .ToListAsync();

            return View(values);
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            if (value != null)
            {
                value.IsCompleted = !value.IsCompleted;

                await _context.SaveChangesAsync();

                await _mediator.Publish(new OrderCreatedNotification
                {
                    OrderID = value.OrderID,
                    CustomerName = value.CustomerName,
                    TotalAmount = value.TotalAmount,
                    IsCompleted = value.IsCompleted
                });
            }
            return RedirectToAction("Index");
        }
    }
}