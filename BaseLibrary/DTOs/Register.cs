using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string? SecondName { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
