using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Notifications.PromotionNotifications
{
    public class PromotionCreatedNotification : INotification
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
