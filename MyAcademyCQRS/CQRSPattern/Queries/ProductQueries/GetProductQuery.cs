using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductsQueryResult>>
    {
    }
}
