using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

namespace MyAcademyCQRS.CQRSPattern.Validation.ContactValidation
{
    public class ContactEmailNotEmptyValidator : ContactValidator
    {
        public override async Task ValidateAsync(CreateContactCommand command, AppDbContext context)
        {
            if (string.IsNullOrEmpty(command.Email))
            {
                throw new Exception("E-posta adresi boş geçilemez!");
            }

            if (_next != null) await _next.ValidateAsync(command, context);
        }
    }
}