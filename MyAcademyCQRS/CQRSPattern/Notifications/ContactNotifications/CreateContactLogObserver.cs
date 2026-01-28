using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace MyAcademyCQRS.CQRSPattern.Notifications.ContactNotifications
{
    public class CreateContactLogObserver : INotificationHandler<ContactCreatedNotification>
    {
        private readonly AppDbContext _context;

        public CreateContactLogObserver(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ContactCreatedNotification notification, CancellationToken ct)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            var log = new AppLog
            {
                LogDate = DateTime.Now,
                LogLevel = "Information",
                Module = "Contact",
                Message = $"{notification.NameSurname} isimli kullanıcıdan yeni iletişim mesajı alındı.",
                UserName = $"{notification.NameSurname}",

                AdditionalData = JsonSerializer.Serialize(new
                {
                    notification.ContactId,
                    notification.NameSurname,
                    notification.Email,
                    notification.Phone,
                    notification.Subject
                }, options)
            };

            await _context.AppLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}