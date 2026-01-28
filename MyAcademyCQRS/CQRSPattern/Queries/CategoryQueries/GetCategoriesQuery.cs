using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries
{
    public class GetCategoriesQuery : IRequest<List<GetCategoriesQueryResult>>
    {
    }
}
