// ... usingler aynı
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Notifications.OrderNotifications;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Extensions;
using MyAcademyCQRS.Models;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    // IRequestHandler ekleyerek MediatR'a "bu komutu ben işlerim" diyoruz
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }
        public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var basket = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<BasketItem>>("MyBasket")
                         ?? new List<BasketItem>();

            if (basket.Count == 0) return;

            var order = new Order
            {
                CustomerName = command.CustomerName,
                Email = command.Email,
                Phone = command.Phone,
                Address = command.Address,
                OrderDate = DateTime.Now,
                IsCompleted = false,
                TotalAmount = basket.Sum(x => x.Price * x.Quantity),
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in basket)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new OrderCreatedNotification
            {
                OrderID = order.OrderID,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount
            });

            _httpContextAccessor.HttpContext.Session.Remove("MyBasket");
        }
    }
}