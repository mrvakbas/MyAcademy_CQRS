using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries
{
    public class GetPromotionQuery : IRequest<List<GetPromotionQueryResult>>
    {
    }
}