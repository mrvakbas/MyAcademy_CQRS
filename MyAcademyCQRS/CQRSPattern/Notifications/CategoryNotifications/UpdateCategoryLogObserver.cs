using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications
{
    public class UpdateCategoryLogObserver : INotificationHandler<CategoryUpdatedNotification>
    {
        public Task Handle(CategoryUpdatedNotification notification, CancellationToken ct)
        {
            // 32GB RAM kapasiten sayesinde bu loglama işlemleri bellekte iz bırakmadan hızla akar.
            Console.WriteLine($"[GÜNCELLEME LOG]: ID: {notification.Id} olan kategori '{notification.OldName}' isminden '{notification.NewName}' ismine güncellendi.");

            return Task.CompletedTask;
        }
    }
}