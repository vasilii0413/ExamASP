namespace Lab6.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
