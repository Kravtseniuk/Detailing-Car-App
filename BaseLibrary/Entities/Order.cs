namespace BaseLibrary.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }

        public OrderStatus Status { get; set; }

        public decimal? TotalPrice { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee ExecutorOfTheWork { get; set; } = null!;

        public ICollection<OrderServiceMapping> OrderCompanyServices { get; set; } = new List<OrderServiceMapping>();
    }
}