namespace BaseLibrary.DTOs.Order
{
    public class GetOrdersDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAuto { get; set; } = string.Empty;
        public decimal PriceForServices { get; set; }
        public string ExecutorOfWork { get; set; } = string.Empty;
        public TimeSpan WorkStartTime { get; set; }
        public TimeSpan WorkEndTime { get; set; }
        public List<string> Services { get; set; } = new();
    }
}