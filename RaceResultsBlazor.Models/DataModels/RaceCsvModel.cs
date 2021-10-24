using System;

namespace RaceResultsBlazor.Models.DataModels
{
    public class RaceCsvModel
    {
        public int Number { get; set; }

        public string TrackName { get; set; }

        public string Country { get; set; }

        public string RaceLength { get; internal set; }

        public DateTimeOffset StartTime { get; set; }

        public int Fastest { get; set; }

        public int ScoringId { get; set; }
    }
}
