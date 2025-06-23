using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BorrowModel
    {
        [Required]
        public int? PersonId { get; set; }
        public PersonModel? Person { get; set; }

        [Required]
        public int? BookId { get; set; }
        public BookModel? Book { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReternDate { get; set; }
    }
}



