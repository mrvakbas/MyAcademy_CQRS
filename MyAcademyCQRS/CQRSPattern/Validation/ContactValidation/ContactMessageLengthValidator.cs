using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

namespace MyAcademyCQRS.CQRSPattern.Validation.ContactValidation
{
    public class ContactMessageLengthValidator : ContactValidator
    {
        public override async Task ValidateAsync(CreateContactCommand command, AppDbContext context)
        {
            if (command.MessageContent.Length < 10)
            {
                throw new Exception("Mesajınız çok kısa, lütfen en az 10 karakter yazın.");
            }

            if (_next != null) await _next.ValidateAsync(command, context);
        }
    }
}