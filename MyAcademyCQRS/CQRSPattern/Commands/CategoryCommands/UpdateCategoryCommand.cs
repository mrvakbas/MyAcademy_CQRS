using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
