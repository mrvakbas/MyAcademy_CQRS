using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Notifications.ContactNotifications
{
    public class ContactCreatedNotification : INotification
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
    }
}
