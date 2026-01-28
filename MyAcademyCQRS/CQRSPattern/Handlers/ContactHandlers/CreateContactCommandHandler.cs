using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.ContactNotifications;
using MyAcademyCQRS.CQRSPattern.Validation.ContactValidation;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public CreateContactCommandHandler(IUnitOfWork uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateContactCommand request, CancellationToken ct)
        {
            var emailValidator = new ContactEmailNotEmptyValidator();
            var lengthValidator = new ContactMessageLengthValidator();

            emailValidator.SetNext(lengthValidator);
            await emailValidator.ValidateAsync(request, _uow.Context);

            await _uow.BeginTransactionAsync();
            try
            {
                var contact = new Contact
                {
                    NameSurname = request.NameSurname,
                    Email = request.Email,
                    Phone = request.Phone,
                    Subject = request.Subject,
                    MessageContent = request.MessageContent
                };

                await _uow.Context.Contacts.AddAsync(contact);
                await _uow.SaveChangesAsync();
                await _uow.CommitAsync();

                await _mediator.Publish(new ContactCreatedNotification
                {
                    ContactId = contact.ContactId,
                    NameSurname = contact.NameSurname,
                    Email = contact.Email,
                    Subject = contact.Subject,
                    Phone = contact.Phone
                });

                return true;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }
}