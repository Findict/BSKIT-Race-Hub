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

        }

        public void UpdateStatus(bool hasDrivers, bool hasTeams, bool hasRaces, bool hasRaceResults)
        {
            this.hasDrivers = hasDrivers;
            this.hasTeams = hasTeams;
            this.hasRaceResults = hasRaceResults;
            this.hasRaces = hasRaces;
        }

        public string Name { get; }

        public string Title { get; }

        public int Index { get; }

        public bool ContainsDriverStandings
            => hasDrivers;

        public bool ContainsDriverResults
            => hasDrivers && hasRaceResults && hasRaces;

        public bool ContainsTeamResults
            => hasTeams;

        public string DriversLink
            => $"drivers/{this.Name}";

        public string TeamsLink
            => $"teams/{this.Name}";

        public string DriverLocation
            => @$"wwwroot\data\{this.Name}\drivers.csv";

        public string TeamsLocation
            => @$"wwwroot\data\{this.Name}\teams.csv";

        public string RacesLocation
            => @$"wwwroot\data\{this.Name}\races.csv";

        public string RaceResultsLocation
            => @$"wwwroot\data\{this.Name}\race-results.csv";
    }
}
