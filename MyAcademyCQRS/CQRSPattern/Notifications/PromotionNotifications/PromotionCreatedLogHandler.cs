using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace MyAcademyCQRS.CQRSPattern.Notifications.PromotionNotifications
{
    public class PromotionCreatedLogHandler : INotificationHandler<PromotionCreatedNotification>
    {
        private readonly AppDbContext _context;

        public PromotionCreatedLogHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(PromotionCreatedNotification notification, CancellationToken cancellationToken)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            string logMessage = $"'{notification.Title}' başlıklı yeni kampanya {notification.Price:C2} fiyatıyla sisteme eklendi.";

            var log = new AppLog
            {
                LogDate = DateTime.Now,
                LogLevel = "Information",
                Module = "Promotion",
                Message = logMessage,
                UserName = "Admin",

                AdditionalData = JsonSerializer.Serialize(new
                {
                    notification.PromotionId,
                    notification.Title,
                    notification.Price,
                    notification.ImageUrl,
                    LogType = "Yeni Kampanya Girişi"
                }, options)
            };

            await _context.AppLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}