using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly AppDbContext _context;

        public GetCategoryByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken ct)
        {
            var value = await _context.Categories.FindAsync(request.PromotionId);

            if (value == null) return null;

            return new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }
}