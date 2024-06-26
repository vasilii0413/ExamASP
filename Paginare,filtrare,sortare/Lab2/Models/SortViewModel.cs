namespace Lab2.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } 
        public SortState CountrySort { get; private set; }
        public SortState Current { get; private set; }    

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            CountrySort = sortOrder == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            Current = sortOrder;
        }
    }
}
