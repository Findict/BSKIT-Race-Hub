using RaceResultsBlazor.App.DataModels;
using RaceResultsBlazor.App.Helpers;

namespace RaceResultsBlazor.App.Models
{
    public class SeriesInfo
    {
        private bool hasDrivers;
        private bool hasTeams;
        private bool hasRaces;
        private bool hasRaceResults;

        public SeriesInfo(string name)
        {
            this.Name = name;

            var info = DataFileHelper.GetJsonData<SeriesInfoDataModel>(this.SeriesInfoLocation);

            this.PopulateInfo(info);
        }

        private void PopulateInfo(SeriesInfoDataModel info)
        {
            this.Title = info.Title;
            this.Index = info.Index;

            this.PageOptions = new PageOptions(info.PageOptions);
        }

        public void UpdateStatus(bool hasDrivers, bool hasTeams, bool hasRaces, bool hasRaceResults)
        {
            this.hasDrivers = hasDrivers;
            this.hasTeams = hasTeams;
            this.hasRaceResults = hasRaceResults;
            this.hasRaces = hasRaces;
        }

        public string Name { get; }

        public string Title { get; private set; }

        public int Index { get; private set; }

        public PageOptions PageOptions { get; private set; }

        public bool ContainsDriverStandings
            => hasDrivers;

        public bool ContainsDriverResults
            => !this.PageOptions.HideDriverResults && hasDrivers && hasRaceResults && hasRaces;

        public bool ContainsTeamResults
            => !this.PageOptions.HideTeamsStandings && hasTeams;

        public bool ContainsTeamInfo
            => !this.PageOptions.HideTeamsInfo && hasTeams && hasDrivers;

        public string DriversResultsLink
            => $"series/{this.Name}/drivers/results";

        public string TeamsResultsLink
            => $"series/{this.Name}/teams/results";

        public string TeamsInfoLink
            => $"series/{this.Name}/teams";

        public string DriverLocation
            => @$"wwwroot\data\{this.Name}\drivers.csv";

        public string TeamsLocation
            => @$"wwwroot\data\{this.Name}\teams.csv";

        public string RacesLocation
            => @$"wwwroot\data\{this.Name}\races.csv";

        public string RaceResultsLocation
            => @$"wwwroot\data\{this.Name}\race-results.csv";

        public string SeriesInfoLocation
            => @$"wwwroot\data\{this.Name}\info.json";
    }
}
