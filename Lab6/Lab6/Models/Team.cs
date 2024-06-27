namespace Lab6.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string CoachName { get; set; }
        public int FoundedYear { get; set; }
        public int LeagueId { get; set; }
        public League? League { get; set; }
        public int StadiumId { get; set; }
        public Stadium? Stadium { get; set; }
        public List<Player> Players { get; set; }
    }
}
