using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
    {
        private readonly AppDbContext _context;

        public GetCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken ct)
        {
            return await _context.Categories.Select(x => new GetCategoriesQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}