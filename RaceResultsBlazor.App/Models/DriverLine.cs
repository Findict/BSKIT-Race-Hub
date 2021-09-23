using System.Collections.Generic;

namespace RaceResultsBlazor.App.Data
{
    public class DriverLine
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public string CountryFlag { get; set; }

        public Team Team { get; set; }

        public List<DriverResult> Results { get; set; }

        public int TotalPoints { get; set; }
    }
}
