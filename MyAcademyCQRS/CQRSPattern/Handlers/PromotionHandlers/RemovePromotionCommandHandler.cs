using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class RemovePromotionCommandHandler : IRequestHandler<RemovePromotionCommand>
    {
        private readonly AppDbContext _context;

        public RemovePromotionCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemovePromotionCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Promotions.FindAsync(new object[] { request.PromotionId }, cancellationToken);

            if (value != null)
            {
                _context.Promotions.Remove(value);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}