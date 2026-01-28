using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;

public class _PromotionComponentPartial : ViewComponent
{
    private readonly IMediator _mediator;

    public _PromotionComponentPartial(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _mediator.Send(new GetPromotionQuery());
        return View(values);
    }
}