using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public int PromotionId { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            PromotionId = id;
        }
    }
}
