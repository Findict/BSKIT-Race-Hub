using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.Models.DataModels;
using RaceResultsBlazor.Utils.Helpers;

namespace RaceResultsBlazor.Models.Models
{
    public class SeriesRecords
    {

        private readonly List<DriverCsvModel> driverRecords;
        private readonly List<Race> racesRecords;
        private readonly List<TeamCsvModel> teamsRecords;

        public SeriesRecords(string title)
        {
            this.Info = new SeriesInfo(title);

            this.driverRecords = DataFileHelper.GetCsvData<DriverCsvModel>(this.Info.DriverLocation);
            this.teamsRecords = DataFileHelper.GetCsvData<TeamCsvModel>(this.Info.TeamsLocation);
            var raceResultsRecords = DataFileHelper.GetCsvData<RaceResultCsvModel>(this.Info.RaceResultsLocation);
            this.racesRecords = DataFileHelper.GetCsvData<RaceCsvModel>(this.Info.RacesLocation)?.Select(r => new Race(r, raceResultsRecords, driverRecords, this.Info)).ToList();

            this.Info.UpdateStatus(this.driverRecords != null, this.racesRecords != null);
        }

        public SeriesInfo Info { get; private set; }

        public List<DriverLine> GetDriverResults()
        {
            var teams = this.teamsRecords?.Select(t => new Team(t)).ToList();

            var drivers =  this.driverRecords.Select(record => new DriverLine
            {
                Id = record.Id,
                Name = record.Name,
                Team = teams?.FirstOrDefault(t => t.Name == record.Team) ?? new Team(record.Team),
                Flag = record.Flag,
                TotalPoints = this.racesRecords.Select(race => race.GetDriverScore(record.Id))
                    .OrderByDescending(s => s)
                    .Take(this.Info.MaxRacesToCount).Sum(),
                Results = this.racesRecords.Select(race => race.Results.FirstOrDefault(result => result.Driver.Number == record.Id)).ToList()
            }).ToList();

            foreach (var driver in drivers)
            {
                var ptsPos = drivers.Count(d => d.TotalPoints > driver.TotalPoints) + 1;

                var cbAdjust = drivers.Where(d => d.TotalPoints == driver.TotalPoints)
                    .Count(d => new CountBackEqualityComparer().Compare(driver, d) < 0);

                driver.Position = ptsPos + cbAdjust;
            }

            return drivers.Where(d => !string.IsNullOrWhiteSpace(d.Name) || d.Position == 1)
                .OrderBy(d => d.Position)
                .ThenByDescending(d => d.Results.Count(r => !string.IsNullOrEmpty(r.Position)))
                .ToList();
        }

        public List<Race> GetRaces()
        {
            return this.racesRecords;
        }

        public List<Team> GetTeamResults()
        {
            var teams = this.teamsRecords.Where(t => !t.ForceHide)
                .Select(t => new Team(t)).ToList();

            if (this.Info.CalculateTeamResults && this.Info.ContainsDriverResults)
            {
                var driverResults = this.GetDriverResults();

                foreach (var team in teams)
                {
                    var relevantDrivers = driverResults.Where(d => d.Team.Name == team.Name).ToList();

                    if (relevantDrivers.Count > 0)
                    {
                        team.Points = relevantDrivers.Sum(d => d.TotalPoints);
                        team.BestDriver = relevantDrivers.Min(d => d.Position);
                    }
                    else
                    {
                        team.Points = 0;
                        team.BestDriver = 999;
                    }
                }

                foreach (var team in teams)
                {
                    var ptsPos = teams.Count(t => t.Points > team.Points) + 1;

                    var cbAdjust = teams.Where(t => t.Points == team.Points)
                        .Count(t => t.BestDriver < team.BestDriver);

                    team.Position = ptsPos + cbAdjust;
                }
            }

            return teams.OrderBy(t => t.Position).ToList();
        }

        public List<string> GetRaceImages()
            => this.racesRecords.Select(r => r.Flag).ToList();
    }
}
