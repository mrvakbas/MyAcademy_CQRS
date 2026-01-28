using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications
{
    public class CategoryUpdatedNotification : INotification
    {
        public int Id { get; set; }
        public string OldName { get; set; } = null!;
        public string NewName { get; set; } = null!;
    }
}