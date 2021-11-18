using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class DriverResult
    {
        public DriverResult(RaceResultCsvModel raceResult, string position, ScoringMatrix scoring, bool isFastest, bool isPole, Driver driver)
        {
            this.Driver = driver;
            this.Position = position;
            this.IsPointsFinish = scoring?.IsPointsFinish(position) ?? false;
            this.ExcludeFromCountback = scoring?.ExcludeFromCountback ?? false;
            this.IsFastestLap = isFastest;
            this.IsPolePosition = isPole;
        }

        public Driver Driver { get; }

        public string Position { get; }

        public bool IsFastestLap { get; }

        public bool IsPolePosition { get; }

        public bool IsPointsFinish { get; }

        public bool ExcludeFromCountback { get; }

        public string GetClasses()
        {
            var classes = "result";

            if (int.TryParse(Position, out int pos))
            {
                if (!this.IsPointsFinish)
                {
                    classes = string.Join(' ', classes, "no-points");
                }
                else
                {
                    classes = pos switch
                    {
                        1 => string.Join(' ', classes, "first"),
                        2 => string.Join(' ', classes, "second"),
                        3 => string.Join(' ', classes, "third"),
                        _ => string.Join(' ', classes, "points"),
                    };
                }
            }
            else if (!string.IsNullOrWhiteSpace(Position))
            {
                classes = string.Join(' ', classes, "other-result");
            }

            if (IsFastestLap)
            {
                classes = string.Join(' ', classes, "fastest");
            }

            return classes.Trim();
        }
    }
}