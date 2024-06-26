using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Stadium
    {
        [Key]
        [ScaffoldColumn(false)]
        public int StadiumId { get; set; }
        [Required]
        [Display(Name = "Denumirea stadionului")]
        public string StadiumName { get; set; }
        [Required]
        [Display(Name = "Orașul și țara")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Nr de locuri")]
        public int Capacity { get; set; }
    }
}
