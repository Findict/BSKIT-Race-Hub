﻿using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.App.DataModels;
using RaceResultsBlazor.App.Helpers;

namespace RaceResultsBlazor.App.Models
{
    public class SeriesRecords
    {

        private readonly List<DriverCsvModel> driverRecords;
        private readonly List<RaceCsvModel> racesRecords;
        private readonly List<RaceResultCsvModel> raceResultsRecords;
        private readonly List<TeamCsvModel> teamsRecords;

        public SeriesRecords(string title)
        {
            this.Info = new SeriesInfo(title);

            this.driverRecords = DataFileHelper.GetCsvData<DriverCsvModel>(this.Info.DriverLocation);
            this.teamsRecords = DataFileHelper.GetCsvData<TeamCsvModel>(this.Info.TeamsLocation);
            this.racesRecords = DataFileHelper.GetCsvData<RaceCsvModel>(this.Info.RacesLocation);
            this.raceResultsRecords = DataFileHelper.GetCsvData<RaceResultCsvModel>(this.Info.RaceResultsLocation);

            this.Info.UpdateStatus(this.driverRecords != null, this.teamsRecords != null, this.racesRecords != null, this.raceResultsRecords != null);
        }

        public SeriesInfo Info { get; private set; }

        public List<DriverLine> GetDriverResults()
        {
            var teams = this.teamsRecords?.Select(t => new Team(t, CountryToAssetUrl)).ToList();

            return this.driverRecords.Select(r => new DriverLine
            {
                Id = r.Id,
                Name = r.Name,
                Team = teams?.FirstOrDefault(t => t.Name == r.Team) ?? new Team(r.Team),
                CountryFlag = CountryToAssetUrl(r.Country),
                Position = r.Position,
                TotalPoints = r.Points,
                Results = this.raceResultsRecords.First(res => res.Driver == r.Id)
                    .GetRaceArray()
                    .Take(this.racesRecords.Count)
                    .Select((result, index) => new DriverResult
                    {
                        Position = result,
                        HighestPointsFinish = this.racesRecords.First(race => race.Number - 1 == index).Hpv,
                        IsFastestLap = r.Id == this.racesRecords.First(race => race.Number - 1 == index).Fastest
                    }).ToList()
            }).Where(d => d.Results.Any(r => !string.IsNullOrEmpty(r.Position)) || d.Position == 1)
            .OrderBy(d => d.Position)
            .ThenByDescending(d => d.Results.Count(r => !string.IsNullOrEmpty(r.Position)))
            .ToList();
        }

        internal List<Team> GetTeamResults()
            => this.teamsRecords.Where(t => !t.ForceHide).Select(t => new Team(t, CountryToAssetUrl)).OrderBy(t => t.Position).ToList();

        public List<string> GetRaceImages()
            => this.racesRecords.Select(r => CountryToAssetUrl(r.Country)).ToList();

        

        private static string CountryToAssetUrl(string country)
            => $"assets/{country?.ToLower().Trim().Replace(' ', '-') ?? string.Empty}.png";
    }
}
