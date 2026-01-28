namespace MyAcademyCQRS.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
