using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationContext _ctx;

        public PlayersController(ApplicationContext ctx)
        {
            _ctx = ctx;

            if(_ctx.Players.Count() == 0)
            {
                League LaLiga = new League { LeagueName = "LaLiga", Country = "Spain", StartDate = new DateTime(2023, 08, 20), EndDate = new DateTime(2024, 05, 20) };
                League premierLeague = new League { LeagueName = "Premier League", Country = "England", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 22) };
                League bundesliga = new League { LeagueName = "Bundesliga", Country = "Germany", StartDate = new DateTime(2023, 08, 18), EndDate = new DateTime(2024, 05, 25) };
                League seriaA = new League { LeagueName = "Serie A", Country = "Italy", StartDate = new DateTime(2023, 08, 26), EndDate = new DateTime(2024, 05, 19) };
                League ligue1 = new League { LeagueName = "Ligue 1", Country = "France", StartDate = new DateTime(2023, 08, 11), EndDate = new DateTime(2024, 05, 26) };
                
                Team barcelona = new Team { TeamName = "Barcelona", League = LaLiga, CoachName = "Xavi", FoundedYear = 1889 };
                Team manchesterUnited = new Team { TeamName = "Manchester United", League = premierLeague, CoachName = "Erik Ten Hag", FoundedYear = 1900 };
                Team liverpool = new Team { TeamName = "Liverpool", League = premierLeague, CoachName = "Klopp", FoundedYear = 1876 };
                Team manchesterCity = new Team { TeamName = "Manchester City", League = premierLeague, CoachName = "Guardiola", FoundedYear = 1895 };

                Player gavi = new Player { PlayerName = "Pablo Gavi", Position = "CM", Team = barcelona, BirthDate = new DateOnly(2004, 08, 05) };
                Player frenkie = new Player { PlayerName = "Frenkie de Jong", Position = "CM", Team = barcelona, BirthDate = new DateOnly(1997, 05, 12) };
                Player pedri = new Player { PlayerName = "Pedri", Position = "AM", Team = barcelona, BirthDate = new DateOnly(2002, 11, 25) };
                Player bruno = new Player { PlayerName = "Bruno Fernandes", Position = "AM", Team = manchesterUnited, BirthDate = new DateOnly(1994, 09, 08) };
                Player salah = new Player { PlayerName = "Mohamed Salah", Position = "FW", Team = liverpool, BirthDate = new DateOnly(1992, 06, 15) };
                Player deBruyne = new Player { PlayerName = "Kevin De Bruyne", Position = "CM", Team = manchesterCity, BirthDate = new DateOnly(1991, 06, 28) };
                Player grealish = new Player { PlayerName = "Jack Grealish", Position = "AM", Team = manchesterCity, BirthDate = new DateOnly(1995, 09, 10) };
                
                _ctx.Leagues.AddRange(LaLiga, premierLeague, bundesliga, seriaA, ligue1);
                _ctx.Teams.AddRange(barcelona, manchesterCity, manchesterUnited, liverpool);
                _ctx.Players.AddRange(gavi, frenkie, pedri, bruno, salah, deBruyne, grealish);
                _ctx.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ShowPlayers(int? team,string name,int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 5;


            IQueryable<Player> players = _ctx.Players.Include(p=>p.Team).Include(p => p.Team.League);

            if (team != null && team != 0)
            {
                players = players.Where(p=>p.TeamId == team);
            }
            if (!String.IsNullOrEmpty(name))
            {
                players = players.Where(p => p.PlayerName.Contains(name));
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    players = players.OrderByDescending(s => s.PlayerName);
                    break;
                case SortState.TeamAsc:
                    players = players.OrderBy(s => s.Team.TeamName);
                    break;
                case SortState.TeamDesc:
                    players = players.OrderByDescending(s => s.Team.TeamName);
                    break;
                case SortState.PositionAsc:
                    players = players.OrderBy(s => s.Position);
                    break;
                case SortState.PositionDesc:
                    players = players.OrderByDescending(s => s.Position);
                    break;
                case SortState.BirthDateAsc:
                    players = players.OrderBy(s => s.BirthDate);
                    break;
                case SortState.BirthDateDesc:
                    players = players.OrderByDescending(s => s.BirthDate);
                    break;
                default:
                    players = players.OrderBy(s => s.PlayerName);
                    break;
            }

            var count = await players.CountAsync();
            var items = await players.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel ivm = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModelPlayers = new SortViewModelPlayers(sortOrder),
                FilterViewModelPlayers = new FilterViewModelPlayers(_ctx.Players.ToList(), name),
                FilterViewModelTeams = new FilterViewModelTeams(_ctx.Teams.ToList(), name),
                Players = items
            };
            return View(ivm);
        }
        [HttpGet]
        public IActionResult AddPlayer()
        {
            ViewBag.TeamId = new SelectList(_ctx.Teams,"TeamId", "TeamName");
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayer(Player player)
        {
            _ctx.Players.Add(player);
            _ctx.SaveChanges();
            return RedirectToAction("ShowPlayers");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            ViewBag.TeamId = new SelectList(_ctx.Teams, "TeamId", "TeamName");

            Player player = _ctx.Players.Find(id);
            return View(player);
        }
        [HttpPost]
        public IActionResult EditPlayer(Player player)
        {
            _ctx.Players.Update(player);
            _ctx.SaveChanges();
            return RedirectToAction("ShowPlayers");
        }

        public IActionResult DeletePlayer(int id)
        {
            Player player= _ctx.Players.Find(id);
            _ctx.Players.Remove(player);
            _ctx.SaveChanges();
            return RedirectToAction("ShowPlayers");
        }
    }
}
