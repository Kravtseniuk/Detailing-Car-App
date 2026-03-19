using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class CompanyService
    {
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public decimal DefaultPrice { get; set; }

        public string Description { get; set; } = string.Empty;

        public ICollection<OrderServiceMapping> OrderMappings { get; set; } = new List<OrderServiceMapping>();
    }
}