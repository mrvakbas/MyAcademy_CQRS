using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications;
using MyAcademyCQRS.CQRSPattern.Validation.CategoryValidation;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public CreateCategoryCommandHandler(IUnitOfWork uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken ct)
        {
            var validator = new CategoryNameValidator();
            await validator.ValidateAsync(request, _uow.Context);
            await _uow.BeginTransactionAsync();

            try
            {
                var category = new Category
                {
                    Name = request.Name
                };

                await _uow.Context.Categories.AddAsync(category);
                await _uow.SaveChangesAsync();
                await _uow.CommitAsync();
                await _mediator.Publish(new CategoryCreatedNotification
                {
                    Id = category.Id,
                    Name = category.Name
                });

                return true;
            }
            catch (Exception)
            {
                await _uow.RollbackAsync();
                return false;
            }
        }
    }
}