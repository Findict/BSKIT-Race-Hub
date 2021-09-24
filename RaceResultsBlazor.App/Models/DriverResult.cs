namespace RaceResultsBlazor.App.Models
{
    public class DriverResult
    {
        public string Position { get; set; }

        public bool IsFastestLap { get; set; }

        public int HighestPointsFinish { get; set; } = 3;

        public string GetClasses()
        {
            var classes = "result";

            if (int.TryParse(Position, out int pos))
            {
                if (pos > this.HighestPointsFinish)
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