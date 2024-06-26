using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Team
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TeamId { get; set; }
       
        [Display(Name = "Denumirea echipei")]
        public string TeamName { get; set; }
       
        [Display(Name = "Numele antrenorului")]
        public string CoachName { get; set; }
       
        [Display(Name = "Anul în care s-a fondat")]
        public int FoundedYear { get; set; }
       
        [Display(Name = "Liga cărei aparține")]
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public List<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }
}
 