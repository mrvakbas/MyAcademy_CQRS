using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Notifications.OrderNotifications
{
    public class OrderCreatedNotification : INotification
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }
    }
}