using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public RemoveCategoryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken ct)
        {
            var value = await _uow.Context.Categories.FindAsync(request.Id);
            if (value == null) return false;
            _uow.Context.Categories.Remove(value);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}