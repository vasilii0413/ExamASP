using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Models
{
    public class FilterViewModelTeams
    {
        public FilterViewModelTeams(List<Team> teams, string name)
        {
            teams.Insert(0, new Team { TeamName = "Toate", TeamId = 0 });
            Teams = new SelectList(teams, "TeamId", "TeamName");
            SelectedName = name;
        }


        public SelectList Teams { get; private set; }
        public int? SelectedTeam { get; private set; }
        public string SelectedName { get; private set; }
    }
}
