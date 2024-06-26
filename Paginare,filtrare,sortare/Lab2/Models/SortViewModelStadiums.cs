namespace Lab2.Models
{
    public class SortViewModelStadiums
    {
        public SortState StadiumNameSort { get; set; }
        public SortState LocationSort { get; set; }
        public SortState CapacitySort { get; set; }
        public SortState Current { get; private set; }

        public SortViewModelStadiums(SortState sortOrder)
        {
            StadiumNameSort = sortOrder == SortState.StadiumNameAsc ? SortState.StadiumNameDesc : SortState.StadiumNameAsc;
            LocationSort = sortOrder == SortState.LocationAsc ? SortState.LocationDesc : SortState.LocationAsc;
            CapacitySort = sortOrder == SortState.CapacityAsc ? SortState.CapacityDesc : SortState.CapacityAsc;
            Current = sortOrder;
        }
    }
}
