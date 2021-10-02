using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class PageOptions
    {
        public PageOptions(PageOptionsDataModel pageOptions)
        {
            this.HideDriverResults = pageOptions?.HideDriverResults ?? false;
            this.HideTeamsStandings = pageOptions?.HideTeamsStandings ?? false;
            this.HideTeamsInfo = pageOptions?.HideTeamsInfo ?? false;
        }

        public bool HideDriverResults { get; }

        public bool HideTeamsStandings { get; }

        public bool HideTeamsInfo { get; }
    }
}