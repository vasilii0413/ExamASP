using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab3_V3.Models
{
    public class ReaderModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ReaderId { get; set; }
        [Required]
        [Display(Name = "Numele cititorului")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Prenumele cititorului")]
        public string Surname { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual BookModel book { get; set; }
        [Required]
        [Display(Name = "Data împrumut")]
        public DateOnly LoanDate { get; set; }
        [Required]
        [Display(Name = "Data întors")]
        public DateOnly ReturnDate { get; set; }
    }
}
