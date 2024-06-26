using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Player
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PlayerId { get; set; }
        [Required]
        [Display(Name = "Echipa la care joacă")]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team? Team { get; set; }
        [Required]
        [Display(Name = "Numele jucătorului")]
        [StringLength(70)]
        public string  PlayerName { get; set; }
        [Required]
        [Display(Name = "Pozitia")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lungimea sirului nu este corecta")]
        public string Position { get; set; }
        [Required]
        [Display(Name = "Data de naștere")]
        public DateOnly BirthDate { get; set; }
    }
}
