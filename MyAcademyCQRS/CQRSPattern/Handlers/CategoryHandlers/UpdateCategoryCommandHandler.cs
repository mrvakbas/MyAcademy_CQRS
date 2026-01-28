using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications;
using MyAcademyCQRS.CQRSPattern.Validation.CategoryValidation;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public UpdateCategoryCommandHandler(IUnitOfWork uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken ct)
        {
            var validator = new UpdateCategoryValidator();
            await validator.ValidateAsync(request, _uow.Context);

            var category = await _uow.Context.Categories.FindAsync(request.Id);
            if (category == null) return false;

            string oldName = category.Name;

            category.Name = request.Name;
            await _uow.SaveChangesAsync();

            await _mediator.Publish(new CategoryUpdatedNotification
            {
                Id = category.Id,
                OldName = oldName,
                NewName = request.Name
            }, ct);

            return true;
        }
    }
}