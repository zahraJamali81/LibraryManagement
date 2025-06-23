using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class PersonCreateVm
    {

        [Required(ErrorMessage = "نام ضروری است")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی ضروری است")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "کد ملی ضروری است")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید 10 رقم باشد")]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [Phone(ErrorMessage = "شماره تلفن نامعتبر است")]
        [MaxLength(11)]
        public string phoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "ایمیل نامعتبر است")]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }
    }
}
