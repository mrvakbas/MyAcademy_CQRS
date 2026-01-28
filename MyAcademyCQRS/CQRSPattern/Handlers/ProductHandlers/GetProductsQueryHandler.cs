using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(AppDbContext _context, IMapper _mapper)
        : IRequestHandler<GetProductQuery, List<GetProductsQueryResult>>
    {
        public async Task<List<GetProductsQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync(cancellationToken);
            return _mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }
}