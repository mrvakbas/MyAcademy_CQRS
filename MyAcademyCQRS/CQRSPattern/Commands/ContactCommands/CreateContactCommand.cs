using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ContactCommands
{
    public class CreateContactCommand : IRequest<bool>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
