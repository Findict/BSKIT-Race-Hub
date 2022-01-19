using System;
using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.Models.DataModels;
using RaceResultsBlazor.Utils.Helpers;

namespace RaceResultsBlazor.Models.Models
{
    public class SeriesInfo
    {
        private bool hasDrivers;
        private bool hasRaces;

        public SeriesInfo(string name)
        {
            this.Name = name;

            var info = DataFileHelper.GetJsonData<SeriesInfoDataModel>(this.SeriesInfoLocation);

            this.PopulateInfo(info);
        }

        private void PopulateInfo(SeriesInfoDataModel info)
        {
            this.Title = info.Title;
            this.LongTitle = info.LongTitle;
            this.Index = info.Index;
            this.MaxRacesToCount = info.MaxRacesToCount ?? 999;
            this.Sections = info.Sections?.Select(s => new SeriesSection(s)).ToList();
            this.HideCalendar = info.HideCalendar;
            this.InternalLinks = info.InternalLinks?.Select(l => new Link(l)).ToList() ?? new List<Link>();
            this.IsPublished = info.IsPublished;
            this.ClassQualifyingData = info.ClassQualifyingData != null ? new ClassQualifyingData(info.ClassQualifyingData) : null;

            this.ScoringMatrices = info.ScoringMatrices?.Select(m => new ScoringMatrix(m)).ToList() ?? new List<ScoringMatrix>();
            this.CalculateTeamResults = info.CalculateTeamResults;
        }

        public void UpdateStatus(bool hasDrivers, bool hasRaces)
        {
            this.hasDrivers = hasDrivers;
            this.hasRaces = hasRaces;
        }

        public string Name { get; }

        public string Title { get; private set; }

        public string LongTitle { get; private set; }

        public int Index { get; private set; }

        internal List<ScoringMatrix> ScoringMatrices { get; private set; }

        public List<SeriesSection> Sections { get; private set; }

        public bool HideCalendar { get; private set; }
        
        public int MaxRacesToCount { get; internal set; }

        public bool CalculateTeamResults { get; private set; }

        public bool IsPublished { get; internal set; }

        public ClassQualifyingData ClassQualifyingData { get; private set; }

        public DateTime QualyLastUpdated { get; private set; }

        public string BaseLink
            => $@"series/{this.Name}";

        public List<Link> InternalLinks { get; private set; }

        public bool ContainsDriverResults
            => hasDrivers && hasRaces;

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

        public void QualyDataUpdated()
            => this.QualyLastUpdated = DateTime.Now;
    }
}
