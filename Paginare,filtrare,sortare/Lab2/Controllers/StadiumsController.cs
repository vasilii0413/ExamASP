using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly ApplicationContext _ctx;

        public StadiumsController(ApplicationContext context)
        {
            _ctx = context;

            if(_ctx.Stadiums.Count() == 0)
            {
                Stadium allianz = new Stadium
                {
                    StadiumName = "Allianz Arena",
                    Location = "Munich, Germany",
                    Capacity = 75000
                };
                Stadium campNou = new Stadium
                {
                    StadiumName = "Camp Nou",
                    Location = "Barcelona, Spain",
                    Capacity = 99354
                };
                _ctx.Stadiums.AddRange(allianz,campNou);
                _ctx.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ShowStadiums(int? stadium,string name,int page =1,SortState sortOrder = SortState.StadiumNameAsc)
        {
            int pageSize = 5;

            IQueryable<Stadium> stadiums = _ctx.Stadiums;

            if(stadium !=null && stadium != 0)
            {
                stadiums = stadiums.Where(s => s.StadiumId == stadium);
            }
            if (!String.IsNullOrEmpty(name))
            {
                stadiums = stadiums.Where(s => s.Location.Contains(name));
            }

            switch (sortOrder)
            {
                case SortState.StadiumNameDesc:
                    stadiums = stadiums.OrderByDescending(s => s.StadiumName);
                    break;
                case SortState.LocationAsc:
                    stadiums = stadiums.OrderBy(s => s.Location);
                    break;
                case SortState.LocationDesc:
                    stadiums = stadiums.OrderByDescending(s => s.Location);
                    break;
                case SortState.CapacityAsc:
                    stadiums = stadiums.OrderBy(s => s.Capacity);
                    break;
                case SortState.CapacityDesc:
                    stadiums = stadiums.OrderByDescending(s => s.Capacity);
                    break;
                default:
                    stadiums = stadiums.OrderBy(s => s.StadiumName);
                    break;
            }
            
            var count = await stadiums.CountAsync();
            var items = await stadiums.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModelStadiums = new SortViewModelStadiums(sortOrder),
                FilterViewModelStadiums = new FilterViewModelStadiums(_ctx.Stadiums.ToList(), stadium, name),
                Stadiums = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult AddStadium()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStadium(Stadium stadium)
        {
            _ctx.Stadiums.Add(stadium);
            _ctx.SaveChanges();
            return RedirectToAction("ShowStadiums");
        }
        [HttpGet]
        public IActionResult EditStadium(int id)
        {
            Stadium stadium= _ctx.Stadiums.Find(id);
            return View(stadium);
        }
        [HttpPost]
        public IActionResult EditStadium(Stadium stadium)
        {
            _ctx.Stadiums.Update(stadium);
            _ctx.SaveChanges();
            return RedirectToAction("ShowStadiums");
        }

        public IActionResult DeleteStadium(int id)
        {
            Stadium stadium = _ctx.Stadiums.Find(id);
            _ctx.Stadiums.Remove(stadium);
            _ctx.SaveChanges();
            return RedirectToAction("ShowStadiums");
        }
    }
}
