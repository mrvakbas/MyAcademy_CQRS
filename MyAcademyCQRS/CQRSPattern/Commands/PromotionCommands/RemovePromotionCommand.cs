using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands
{
    public class RemovePromotionCommand : IRequest
    {
        public int PromotionId { get; set; }
        public RemovePromotionCommand(int id) { PromotionId = id; }
    }
}
