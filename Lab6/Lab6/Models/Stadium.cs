namespace Lab6.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public List<Team> Teams { get; set; }

    }
}
