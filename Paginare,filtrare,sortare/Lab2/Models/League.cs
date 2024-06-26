using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class League
    {
        [Key]
        [ScaffoldColumn(false)]
        public int LeagueId { get; set; }
        [Required]
        [Display(Name = "Denumirea ligii")]
        public string LeagueName { get; set; }
        [Required]
        [Display(Name = "Țara")]
        public string Country { get; set;}
        [Required]
        [Display(Name = "Data de start")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Data de sfârșit")]
        public DateTime EndDate { get; set; }
    }
}
