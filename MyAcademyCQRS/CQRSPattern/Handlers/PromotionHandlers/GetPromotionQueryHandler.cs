using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionQueryHandler : IRequestHandler<GetPromotionQuery, List<GetPromotionQueryResult>>
    {
        private readonly AppDbContext _context;

        public GetPromotionQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetPromotionQueryResult>> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Promotions.Select(x => new GetPromotionQueryResult
            {
                Id = x.PromotionId,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl
            }).ToListAsync(cancellationToken);
        }
    }
}