namespace Lab2.Models
{
    public class SortViewModelPlayers
    {
        public SortState NameSort { get; private set; }
        public SortState TeamSort { get; private set; }
        public SortState Position { get; private set; }
        public SortState BirthDate { get;private set; }
        public SortState Current { get;private set; }

        public SortViewModelPlayers(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            TeamSort = sortOrder == SortState.TeamAsc ? SortState.TeamDesc : SortState.TeamAsc;
            Position = sortOrder == SortState.PositionAsc ? SortState.PositionDesc : SortState.PositionAsc;
            BirthDate = sortOrder == SortState.BirthDateAsc ? SortState.BirthDateDesc : SortState.BirthDateAsc;
            Current = sortOrder;
        }

    }
}
