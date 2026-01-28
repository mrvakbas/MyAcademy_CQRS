using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.OrderNotifications;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Extensions;
using MyAcademyCQRS.Models;

namespace MyAcademyCQRS.Controllers
{
    public class HomeController(IMediator _mediator,AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                TempData["SuccessMessage"] = "Mesajýnýz baþarýyla iletildi!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Zincirden fýrlatýlan özel mesajý yakalýyoruz
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Attribute'u sildik, sadece metodun kendisi kaldý
        public IActionResult Checkout()
        {
            var basket = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("MyBasket")
                         ?? new List<BasketItem>();

            // DEBUG: Sepette gerçekten eleman var mý yok mu ekrana yazdýralým
            ViewBag.SepetAdet = basket.Count;

            return View(basket);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(string FullName, string PhoneNumber, string Address, string Email)
        {
            // 1. Session'dan sepeti alýyoruz [cite: 2026-01-23]
            var basket = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("MyBasket");

            if (basket == null || !basket.Any())
            {
                TempData["ErrorMessage"] = "Sepetiniz boþ olduðu için sipariþ verilemedi.";
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                CustomerName = FullName,
                Phone = PhoneNumber,
                Address = Address,
                OrderDate = DateTime.Now,
                IsCompleted = false,
                TotalAmount = basket.Sum(x => x.Price * x.Quantity),
                Email = Email,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in basket)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new OrderCreatedNotification
            {
                OrderID = order.OrderID,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount
            });

            HttpContext.Session.Remove("MyBasket");

            TempData["SuccessMessage"] = $"Teþekkürler {FullName.ToUpper()}, sipariþiniz baþarýyla alýndý!";

            return RedirectToAction("Index");
        }
    }
}