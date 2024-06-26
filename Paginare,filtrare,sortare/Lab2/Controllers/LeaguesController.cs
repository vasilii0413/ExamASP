using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ApplicationContext _ctx;

        public LeaguesController(ApplicationContext context)
        {
            _ctx= context;

            if(_ctx.Leagues.Count() == 0)
            {
                League laLiga = new League { LeagueName = "La Liga Santander", Country = "Spain", StartDate = new DateTime(2023, 08, 12),EndDate = new DateTime (2024,05,20) };
                League apl = new League { LeagueName = "Premier League",Country = "England", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 20) };
                League seriaA = new League { LeagueName = "Serie A",Country = "Italy", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 20) };
                League ligue1 = new League { LeagueName = "Ligue 1",Country = "France", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 20) };
                League bundesliga = new League { LeagueName = "Bundesliga",Country = "Germany", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 20) };
                League eredivisie = new League { LeagueName = "Eredivisie" ,Country = "Netherlands", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 20) };
                _ctx.Leagues.AddRange(laLiga,apl,seriaA,ligue1,bundesliga,eredivisie);
                _ctx.SaveChanges();
            }
        }
        
        public async Task<IActionResult> ShowLeagues(int? league, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 5;

            //filter
            IQueryable<League> leagues = _ctx.Leagues;
            
            if(league != null && league != 0)
            {
                leagues = leagues.Where(p => p.LeagueId == league);
            }
            if (!String.IsNullOrEmpty(name))
            {
                leagues = leagues.Where(p => p.LeagueName.Contains(name));
            }

            //sort
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    leagues = leagues.OrderByDescending(s => s.LeagueName);
                    break;
                case SortState.CountryAsc:
                    leagues = leagues.OrderBy(s => s.Country);
                    break;
                case SortState.CountryDesc:
                    leagues = leagues.OrderByDescending(s => s.Country);
                    break;
                default:
                    leagues = leagues.OrderBy(s => s.LeagueName);
                    break;
            }

            //pagination
            var count = await leagues.CountAsync();
            var items = await leagues.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModelLeagues = new FilterViewModelLeagues(_ctx.Leagues.ToList(), league, name),
                Leagues = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult AddLeague()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLeague(League league)
        {
            _ctx.Leagues.Add(league);
            _ctx.SaveChanges();
            return RedirectToAction("ShowLeagues");
        }
        [HttpGet]
        public IActionResult EditLeague(int id)
        {
            League league = _ctx.Leagues.Find(id);
            return View(league);
        }
        [HttpPost]
        public IActionResult EditLeague(League league)
        {
            _ctx.Leagues.Update(league);
            _ctx.SaveChanges();
            return RedirectToAction("ShowLeagues");
        }
        
        public IActionResult DeleteLeague(int id)
        {
            League league = _ctx.Leagues.Find(id);
            _ctx.Leagues.Remove(league);
            _ctx.SaveChanges();
            return RedirectToAction("ShowLeagues");
        }
    }
}
