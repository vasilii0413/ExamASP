namespace Lab2.Models
{
    public class IndexViewModel
    {
        public IEnumerable<League> Leagues { get; set; }
        public IEnumerable<Player> Players{ get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Stadium> Stadiums { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModelStadiums FilterViewModelStadiums { get; set; }
        public FilterViewModelLeagues FilterViewModelLeagues { get; set; }
        public FilterViewModelPlayers FilterViewModelPlayers { get; set; }
        public FilterViewModelTeams FilterViewModelTeams{ get; set; }
        public SortViewModel SortViewModel { get; set; }
        public SortViewModelPlayers SortViewModelPlayers { get; set; }
        public SortViewModelTeams SortViewModelTeams { get; set; }
        public SortViewModelStadiums SortViewModelStadiums { get; set; } 
    }
}
