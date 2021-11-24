using System;
using System.IO;
using RaceResultsBlazor.Models.DataModels;
using RaceResultsBlazor.Utils.Helpers;

namespace RaceResultsBlazor.Models.Models
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }

        public Team(TeamCsvModel team)
        {
            this.Name = team.Name;
            this.Color = team.Color;
            this.Country = FlagHelper.ImageFromString(team.Country);
            this.Points = team.Points;
            this.Position = team.Position;
        }

        public string Name { get; }

        public string Country { get; }

        public string Color { get; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int BestDriver { get; set; }

        public string GetClasses()
            => $"{(string.IsNullOrWhiteSpace(this.Color) ? string.Empty : "team")}".Trim();

        public string GetColor()
            => string.IsNullOrWhiteSpace(this.Color) ? "#000000" : this.Color;

        public bool HasValidCountry
            => File.Exists($"wwwroot\\{this.Country}");
    }
}