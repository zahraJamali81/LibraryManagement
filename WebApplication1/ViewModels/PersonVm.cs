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

        [Required(ErrorMessage = "کد ملی ضروری است")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید 10 رقم باشد")]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [Phone(ErrorMessage = "شماره تلفن نامعتبر است")]
        [MaxLength(11)]
        public string phoneNumber { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

    }
}
