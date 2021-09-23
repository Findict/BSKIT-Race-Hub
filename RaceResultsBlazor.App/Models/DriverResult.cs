namespace RaceResultsBlazor.App.Data
{
    public class DriverResult
    {
        public string Position { get; set; }

        public bool IsFastestLap { get; set; }

        public string GetClasses()
        {
            var classes = "result";

            if (int.TryParse(Position, out int pos))
            {
                classes = pos switch
                {
                    1 => string.Join(' ', classes, "first"),
                    2 => string.Join(' ', classes, "second"),
                    3 => string.Join(' ', classes, "third"),
                    4 or 5 or 6 or 7 or 8 or 9 or 10 => string.Join(' ', classes, "points"),
                    _ => string.Join(' ', classes, "no-points"),
                };
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