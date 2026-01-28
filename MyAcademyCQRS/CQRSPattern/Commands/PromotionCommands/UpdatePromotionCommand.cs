using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands
{
    public class UpdatePromotionCommand : IRequest
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
