using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Publication Date is required.")]
        public DateTime PublicationDate { get; set; }
    
    }
}
