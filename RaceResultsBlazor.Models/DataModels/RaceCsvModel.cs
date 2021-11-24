using System;

namespace RaceResultsBlazor.Models.DataModels
{
    public class RaceCsvModel
    {
        public int Number { get; init; }

        public string Title { get; init; }

        public string TrackName { get; init; }

        public string Country { get; init; }

        public string Background { get; init; }

        public string TrackMap { get; init; }

        public string RaceLength { get; init; }

        public DateTimeOffset StartTime { get; init; }

        public int Fastest { get; init; }

        public int FastestTime { get; init; }

        public int Pole { get; init; }

        public int PoleTime { get; init; }

        public int ScoringId { get; init; }
    }
}
