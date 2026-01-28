using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand>
    {
        private readonly AppDbContext _context;

        public UpdatePromotionCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Promotions.FindAsync(new object[] { request.PromotionId }, cancellationToken);

            if (value != null)
            {
                value.Title = request.Title;
                value.Description = request.Description;
                value.Price = request.Price;
                value.ImageUrl = request.ImageUrl;

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}