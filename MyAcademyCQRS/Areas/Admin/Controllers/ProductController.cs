using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator _mediator,
                                    GetProductsQueryHandler getProductsQueryHandler,
                                    CreateProductCommandHandler createProductCommandHandler,
                                    GetCategoriesQueryHandler getCategoriesQueryHandler,
                                    UpdateProductCommandHandler updateProductCommandHandler,
                                    RemoveProductCommandHandler removeProductCommandHandler,
                                    GetProductByIdQueryHandler getProductByIdQueryHandler) : Controller
    {
        public async Task GetCategoriesAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            ViewBag.categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var product = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
