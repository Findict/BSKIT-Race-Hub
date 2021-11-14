using System;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class RaceCalendarItemViewModel
    {
        public RaceCalendarItemViewModel(Race race)
        {
            this.TrackName = race.TrackName;
            this.StartingTime = race.StartingTime;
            this.RaceLength = race.RaceLength;
            this.Number = race.Number;
            this.Title = race.Title;
            this.Flag = race.Flag;
        }

        public int Number { get; }

        public string Title { get; }

        public string TrackName { get; }

        public string Flag { get; }

        public DateTimeOffset StartingTime { get; }

        public string RaceLength { get; }
    }
}
