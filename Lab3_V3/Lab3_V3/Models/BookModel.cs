using System.ComponentModel.DataAnnotations;

namespace Lab3_V3.Models
{
    public class BookModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BookId { get; set; }
        [Required]
        [Display(Name = "Titlu")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Numele autorului")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Codul ISBN")]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Anul ediției")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Editura")]
        public string Publisher { get; set; }
        [Required]
        [Display(Name = "Numărul de pagini")]
        public int Pages { get; set; }
        [Required]
        [Display(Name = "Numărul de exemplare tipărite")]
        public int CopiesPrinted { get; set; }
        [Required]
        [Display(Name = "Preț")]
        public int Price { get; set; }
    }
}
