using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class OrderServiceMapping
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int CompanyServiceId { get; set; }
        public CompanyService CompanyService { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
