using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Extensions;
using MyAcademyCQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAcademyCQRS.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToBasket(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return Json(new { success = false });

            var basket = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("MyBasket")
                         ?? new List<BasketItem>();

            var existingItem = basket.FirstOrDefault(x => x.ProductID == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                basket.Add(new BasketItem
                {
                    ProductID = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObjectAsJson("MyBasket", basket);

            return Json(new { success = true, count = basket.Sum(x => x.Quantity) });
        }

        [HttpGet]
        public IActionResult GetBasketCount()
        {
            var basket = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("MyBasket") ?? new List<BasketItem>();
            var totalCount = basket.Sum(x => x.Quantity);
            return Json(totalCount);
        }

    }
}