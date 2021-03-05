using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Librarian.Dto
{
    public class AddBookDto
    {
        [Required]
        [DisplayName("Book title")]
        public string BookTitle { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [DisplayName("Publish year")]
        public int PublishYear { get; set; }
        [Required]
        [DisplayName("Cover price")]
        public decimal CoverPrice { get; set; }
        [Required]
        public string Status { get; set; }
    }
}