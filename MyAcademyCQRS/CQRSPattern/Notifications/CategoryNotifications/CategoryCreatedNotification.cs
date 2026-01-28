using MediatR;
namespace MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications
{
    public class CategoryCreatedNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}