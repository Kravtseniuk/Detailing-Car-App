using BaseLibrary.Entities;

namespace BaseLibrary.DTOs.Order
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}