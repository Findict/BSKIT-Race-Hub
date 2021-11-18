using System;
using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class RaceCalendarItemViewModel
    {
        public RaceCalendarItemViewModel(Race race)
        {
            this.Number = race.Number;
            this.TrackName = race.TrackName;
            this.Title = race.Title;
            this.RaceLength = race.RaceLength;
            this.StartingTime = race.StartingTime;
            this.Flag = race.Flag;
            this.Background = race.Background;
            this.TrackMap = race.TrackMap;
            this.Results = race.Results.Where(r => (new[] { "1", "2", "3" }).Contains(r.Position)).OrderBy(r => r.Position).ToList();
            this.Fastest = race.Results.FirstOrDefault(r => r.IsFastestLap);
            this.FastestLapTime = race.FastestLapTime;
            this.Pole = race.Results.FirstOrDefault(r => r.IsPolePosition);
            this.PoleLapTime = race.PoleLapTime;
        }

        public int Number { get; }

        public string TrackName { get; }

        public string Title { get; }

        public string RaceLength { get; }

        public DateTimeOffset StartingTime { get; }

        public string Flag { get; }

        public string Background { get; }

        public string TrackMap { get; }

        public List<DriverResult> Results { get; }

        public DriverResult Fastest { get; }

        public TimeSpan FastestLapTime { get; }

        public DriverResult Pole { get; }

        public TimeSpan PoleLapTime { get; }
    }
}
