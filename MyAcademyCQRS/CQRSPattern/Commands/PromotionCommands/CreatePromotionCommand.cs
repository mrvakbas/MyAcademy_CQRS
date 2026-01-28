using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands
{
    public class CreatePromotionCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
