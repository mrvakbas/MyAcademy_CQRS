using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;
using System.Text.Json;

namespace MyAcademyCQRS.CQRSPattern.Notifications.CategoryNotifications
{
    public class CreateCategoryLogObserver : INotificationHandler<CategoryCreatedNotification>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateCategoryLogObserver(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(CategoryCreatedNotification notification, CancellationToken ct)
        {
            var log = new AppLog
            {
                LogDate = DateTime.Now,
                LogLevel = "Information",
                Module = "Category",
                Message = $"'{notification.Name}' isimli yeni kategori eklendi.",
                UserName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Admin",
                AdditionalData = JsonSerializer.Serialize(new { notification.Id, notification.Name })
            };

            _context.AppLogs.Add(log);
            await _context.SaveChangesAsync(ct);
        }
    }
}