using System;
using System.IO;
using RaceResultsBlazor.App.CsvModels;

namespace RaceResultsBlazor.App.Data
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }

        public Team(TeamCsvModel team, Func<string, string> countryConverter)
        {
            this.Name = team.Name;
            this.Color = team.Color;
            this.Country = countryConverter(team.Country);
            this.Points = team.Points;
            this.Position = team.Position;
        }

        public string Name { get; }

        public string Country { get; }

        public string Color { get; }

        public int Position { get; }

        public int Points { get; }

        public string GetClasses()
            => $"{(string.IsNullOrWhiteSpace(this.Color) ? string.Empty : "team")}".Trim();

        public string GetColor()
            => string.IsNullOrWhiteSpace(this.Color) ? "#000000" : this.Color;

        public bool HasValidCountry
            => File.Exists($"wwwroot\\{this.Country}");
    }
}