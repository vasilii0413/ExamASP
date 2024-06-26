namespace Lab2.Models
{
    public class SortViewModelTeams
    {
        public SortState TeamNameSort { get; set; }
        public SortState CoachNameSort { get; set; }
        public SortState YearFoundationSort { get; set; }
        public SortState LeagueSort { get; set; }
        public SortState Current { get; private set; }

        public SortViewModelTeams(SortState sortOrder)
        {
            TeamNameSort = sortOrder == SortState.TeamNameAsc ? SortState.TeamNameDesc : SortState.TeamNameAsc;
            CoachNameSort = sortOrder == SortState.CoachNameAsc ? SortState.CoachNameDesc : SortState.CoachNameAsc;
            YearFoundationSort = sortOrder == SortState.YearFoundationAsc ? SortState.YearFoundationDesc : SortState.YearFoundationAsc;
            LeagueSort = sortOrder == SortState.LeagueAsc ? SortState.LeagueDesc : SortState.LeagueAsc;
            Current = sortOrder;
        }
    }
}
