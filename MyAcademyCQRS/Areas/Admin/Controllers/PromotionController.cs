using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetPromotionQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePromotion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CreatePromotionCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemovePromotion(int id)
        {
            await _mediator.Send(new RemovePromotionCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePromotion(int id)
        {
            var value = await _mediator.Send(new GetPromotionByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(UpdatePromotionCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}