using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationContext _ctx;

        public TeamsController(ApplicationContext context)
        {
            _ctx = context;

            if (_ctx.Teams.Count() == 0)
            {
                League LaLiga = new League { LeagueName = "LaLiga", Country = "Spain", StartDate = new DateTime(2023, 08, 20), EndDate = new DateTime(2024, 05, 20) };League premierLeague = new League { LeagueName = "Premier League", Country = "England", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 22) };
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
        public async Task<IActionResult> ShowTeams(int? league,string name, int page = 1, SortState sortOrder = SortState.TeamNameAsc)
        {
            int pageSize = 5;

            IQueryable<Team> teams = _ctx.Teams.Include(t => t.League);

            if (league != null && league != 0)
            {
                teams = teams.Where(t=>t.LeagueId == league);
            }

            if (!String.IsNullOrEmpty(name))
            {
                teams = teams.Where(t => t.TeamName.Contains(name));
            }

            switch(sortOrder)
            {   
                case SortState.TeamNameDesc:
                    teams = teams.OrderByDescending(t => t.TeamName);
                    break;
                case SortState.CoachNameAsc:
                    teams = teams.OrderBy(t=>t.CoachName);
                    break;
                case SortState.CoachNameDesc:
                    teams = teams.OrderByDescending(t => t.CoachName);
                    break;
                case SortState.YearFoundationAsc:
                    teams = teams.OrderBy(t=> t.FoundedYear);
                    break;
                case SortState.YearFoundationDesc:
                    teams = teams.OrderByDescending(t => t.FoundedYear);
                    break;
                case SortState.LeagueAsc:
                    teams = teams.OrderBy(t => t.League.LeagueName);
                    break;
                case SortState.LeagueDesc:
                    teams = teams.OrderByDescending(t=>t.League.LeagueName);
                    break;
                default:
                    teams = teams.OrderBy(t => t.TeamName);
                    break;
            }

            var count = await teams.CountAsync();
            var items = await teams.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

            IndexViewModel ivm = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModelTeams = new SortViewModelTeams(sortOrder),
                FilterViewModelTeams = new FilterViewModelTeams(_ctx.Teams.ToList(),name),
                FilterViewModelLeagues = new FilterViewModelLeagues(_ctx.Leagues.ToList(),league, name),
                Teams = items
            };
            return View(ivm);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            ViewBag.LeagueId = new SelectList(_ctx.Leagues,"LeagueId", "LeagueName");
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _ctx.Teams.Add(team);
            _ctx.SaveChanges();
            return RedirectToAction("ShowTeams");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            ViewBag.LeagueId = new SelectList(_ctx.Leagues, "LeagueId", "LeagueName");

            Team team = _ctx.Teams.Find(id);
            return View(team);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            _ctx.Teams.Update(team);
            _ctx.SaveChanges();
            return RedirectToAction("ShowTeams");
        }
        public IActionResult DeleteTeam(int id)
        {
            Team team = _ctx.Teams.Find(id);
            _ctx.Teams.Remove(team);
            _ctx.SaveChanges();
            return RedirectToAction("ShowTeams");
        }
    }
}
