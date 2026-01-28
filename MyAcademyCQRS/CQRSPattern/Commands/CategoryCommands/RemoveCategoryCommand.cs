using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
