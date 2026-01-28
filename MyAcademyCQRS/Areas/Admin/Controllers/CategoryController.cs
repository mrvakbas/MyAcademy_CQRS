using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetCategoriesQuery());
            return View(values);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(command);
        }
    }
}