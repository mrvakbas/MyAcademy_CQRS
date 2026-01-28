using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries
{
    public class GetPromotionByIdQuery : IRequest<GetPromotionByIdQueryResult>
    {
        public int PromotionId { get; set; }

        public GetPromotionByIdQuery(int id)
        {
            PromotionId = id;
        }
    }
}