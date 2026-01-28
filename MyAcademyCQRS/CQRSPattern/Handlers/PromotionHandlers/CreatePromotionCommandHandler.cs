using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.PromotionNotifications;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    // IRequestHandler yanına dönüş tipi eklenmediyse Task döner [cite: 2026-01-24]
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreatePromotionCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = new Promotion
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl
            };

            await _context.Promotions.AddAsync(promotion, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PromotionCreatedNotification
            {
                PromotionId = promotion.PromotionId,
                Title = promotion.Title,
                Price = promotion.Price,
                ImageUrl = promotion.ImageUrl
            }, cancellationToken);
        }
    }
}