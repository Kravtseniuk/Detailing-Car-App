using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class SaveOrderDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Название заказа не должно превышать 100 символов.")]
        public string OrderName { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public string CustomerFullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string CustomerAuto { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string CustomerPhone { get; set; } = string.Empty;

        public TimeSpan? WorkStartTime { get; set; }

        public TimeSpan? WorkEndTime { get; set; }

        public decimal TotalPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Потрібно обрати працівника.")]
        public int EmployeeId { get; set; }
    }
}
