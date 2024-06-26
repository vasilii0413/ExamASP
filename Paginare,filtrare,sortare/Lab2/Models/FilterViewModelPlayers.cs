using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Models
{
    public class FilterViewModelPlayers
    {
        public FilterViewModelPlayers(List<Player> players, string name)
        {
            players.Insert(0, new Player { PlayerName = "Toate", PlayerId = 0 });
            Players = new SelectList(players, "PlayerId", "PlayerName");
            SelectedName = name;
        }


        public SelectList Players { get; private set; }
        public int? SelectedPlayer { get; private set; }
        public string SelectedName { get; private set; }
    }
}
