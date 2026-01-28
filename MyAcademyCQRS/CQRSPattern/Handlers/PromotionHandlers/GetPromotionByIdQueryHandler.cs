using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, GetPromotionByIdQueryResult>
    {
        private readonly AppDbContext _context;
        public GetPromotionByIdQueryHandler(AppDbContext context) { _context = context; }

        public async Task<GetPromotionByIdQueryResult> Handle(GetPromotionByIdQuery request, CancellationToken ct)
        {
            var value = await _context.Promotions.FindAsync(new object[] { request.PromotionId }, ct);
            if (value == null) return null;

            return new GetPromotionByIdQueryResult
            {
                PromotionId = value.PromotionId,
                Title = value.Title,
                Description = value.Description,
                Price = value.Price,
                ImageUrl = value.ImageUrl
            };
        }
    }
}