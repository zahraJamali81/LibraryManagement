using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class PersonVm
    {
        public int PersonId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [MaxLength(11)]
        public string phoneNumber { get; set; }

    }
}
