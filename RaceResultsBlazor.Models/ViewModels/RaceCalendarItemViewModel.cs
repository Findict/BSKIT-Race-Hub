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
        }

        public string TrackName { get; }

        public DateTimeOffset StartingTime { get; }

        public string RaceLength { get; }
    }
}
