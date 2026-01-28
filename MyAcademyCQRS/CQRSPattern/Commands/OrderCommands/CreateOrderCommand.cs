using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderCommands
{
    public class CreateOrderCommand :IRequest
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
