using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
