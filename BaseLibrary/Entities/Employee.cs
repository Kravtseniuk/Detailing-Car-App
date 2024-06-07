using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        public string Fullname { get; set; } = string.Empty;
        
        [Required]
        public string TelephoneNumber { get; set; } = string.Empty;
    }
}