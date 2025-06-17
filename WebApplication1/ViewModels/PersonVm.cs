using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class PersonVm
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        public string phoneNumber { get; set; }

    }
}
