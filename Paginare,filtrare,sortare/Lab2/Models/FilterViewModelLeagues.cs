using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Models
{
    public class FilterViewModelLeagues
    {
        public FilterViewModelLeagues(List<League> leagues, int? league, string name)
        {
            leagues.Insert(0, new League { LeagueName= "Toate", LeagueId = 0 });
            Leagues = new SelectList(leagues, "LeagueId", "LeagueName", league);
            SelectedLeague = league;
            SelectedName = name;
        }
        public SelectList Leagues { get; private set; } 
        public int? SelectedLeague { get; private set; }
        public string SelectedName { get; private set; }
    }
}
