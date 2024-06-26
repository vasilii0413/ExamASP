using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Models
{
    public class FilterViewModelStadiums
    {
        public FilterViewModelStadiums(List<Stadium> stadiums,int? stadium,string name)
        {
            stadiums.Insert(0, new Stadium { StadiumName = "Toate", StadiumId = 0 });
            Stadiums = new SelectList(stadiums, "StadiumId", "StadiumName");
            SelectedStadium = stadium;
            SelectedName = name;
        }
        public SelectList Stadiums { get; private set; }
        public int? SelectedStadium { get; private set; }
        public string SelectedName { get; set; }
    }
}
