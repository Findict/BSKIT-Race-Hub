using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RaceResultsBlazor.Models.Models
{
    public class DriverLine
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public string Flag { get; set; }

        public Team Team { get; set; }

        public List<DriverResult> Results { get; set; }

        public int TotalPoints { get; set; }

        public bool HasValidCountry
            => File.Exists($"wwwroot\\{this.Flag}");
    }

    public class CountBackEqualityComparer : IComparer<DriverLine>
    {
        public int Compare(DriverLine x, DriverLine y)
        {
            var xResults = x.Results.Where(r => !r?.ExcludeFromCountback ?? false)
                .Select(r => int.TryParse(r.Position, out int result) ? result : 0)
                .Where(r => r > 0)
                .OrderBy(r => r).ToList();
            var yResults = y.Results.Where(r => !r?.ExcludeFromCountback ?? false)
                .Select(r => int.TryParse(r.Position, out int result) ? result : 0)
                .Where(r => r > 0)
                .OrderBy(r => r).ToList();

            for (int i = 0; i < Math.Min(xResults.Count, yResults.Count); i++)
            {
                var xVal = xResults[i];
                var yVal = yResults[i];
                var diff = yVal - xVal;

                if (diff != 0)
                {
                    return diff;
                }
            }

            return xResults.Count - yResults.Count;
        }
    }
}
