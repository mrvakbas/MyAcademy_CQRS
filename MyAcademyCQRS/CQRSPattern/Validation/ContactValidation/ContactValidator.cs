using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

namespace MyAcademyCQRS.CQRSPattern.Validation.ContactValidation
{
    public abstract class ContactValidator
    {
        protected ContactValidator _next;
        public void SetNext(ContactValidator next) => _next = next;

        public abstract Task ValidateAsync(CreateContactCommand command, AppDbContext context);
    }
}