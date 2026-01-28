using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace MyAcademyCQRS.CQRSPattern.Notifications.OrderNotifications
{
    public class OrderCreatedLogHandler : INotificationHandler<OrderCreatedNotification>
    {
        private readonly AppDbContext _context;

        public OrderCreatedLogHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            // Log mesajını IsCompleted durumuna göre belirliyoruz [cite: 2026-01-23]
            string logMessage = notification.IsCompleted
                ? $"#{notification.OrderID} numaralı sipariş başarıyla TAMAMLANDI."
                : $"{notification.CustomerName} tarafından {notification.TotalAmount.ToString("C2")} tutarında YENİ SİPARİŞ oluşturuldu.";

            var log = new AppLog
            {
                LogDate = DateTime.Now,
                LogLevel = "Information",
                Module = "Order",
                Message = logMessage,
                UserName = notification.CustomerName,

                AdditionalData = JsonSerializer.Serialize(new
                {
                    notification.OrderID,
                    notification.CustomerName,
                    notification.TotalAmount,
                    notification.IsCompleted, // Durumu JSON içine de ekliyoruz [cite: 2026-01-23]
                    LogType = notification.IsCompleted ? "Durum Güncelleme" : "Yeni Sipariş"
                }, options)
            };

            await _context.AppLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}