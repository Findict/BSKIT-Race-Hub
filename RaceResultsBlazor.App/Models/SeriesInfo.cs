using System.Collections.Generic;

namespace RaceResultsBlazor.App.Models
{
    public class SeriesInfo
    {
        private bool hasDrivers;
        private bool hasTeams;
        private bool hasRaces;
        private bool hasRaceResults;

        public SeriesInfo(string title)
        {
            this.Title = title;
        }

        public void UpdateStatus(bool hasDrivers, bool hasTeams, bool hasRaces, bool hasRaceResults)
        {
            this.hasDrivers = hasDrivers;
            this.hasTeams = hasTeams;
            this.hasRaceResults = hasRaceResults;
            this.hasRaces = hasRaces;
        }

        public string Title { get; }

        public bool ContainsDriverStandings
            => hasDrivers;

        public bool ContainsDriverResults
            => hasDrivers && hasRaceResults && hasRaces;

        public bool ContainsTeamResults
            => hasTeams;

        public string DriversLink
            => $"drivers/{this.Title}";

        public string TeamsLink
            => $"teams/{this.Title}";

        public string DriverLocation
            => @$"wwwroot\data\{this.Title}\drivers.csv";

        public string TeamsLocation
            => @$"wwwroot\data\{this.Title}\teams.csv";

        public string RacesLocation
            => @$"wwwroot\data\{this.Title}\races.csv";

        public string RaceResultsLocation
            => @$"wwwroot\data\{this.Title}\race-results.csv";
    }
}
