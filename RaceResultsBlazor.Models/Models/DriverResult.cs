namespace RaceResultsBlazor.Models.Models
{
    public class DriverResult
    {
        public int DriverId { get; set; }

        public string Position { get; set; }

        public bool IsFastestLap { get; set; }

        public bool IsPointsFinish { get; set; }

        public bool ExcludeFromCountback { get; set; }

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
            else if (!string.IsNullOrEmpty(Position))
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