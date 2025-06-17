using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class BookVm
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        public bool Status { get; set; }
    }
}
