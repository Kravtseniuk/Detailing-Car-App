using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string SecondName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        [Required, Phone]
        public string TelephoneNumber { get; set; } = string.Empty;

        public ICollection<Order> ExecutedOrders { get; set; } = new List<Order>();

        public string FullName => $"{SecondName} {FirstName} {LastName}".Trim();
    }
}