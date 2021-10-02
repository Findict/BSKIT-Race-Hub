using System;

namespace RaceResultsBlazor.Models.DataModels
{
    public class RaceCsvModel
    {
        public int Number { get; set; }

        public string Country { get; set; }

        public long StartTime { get; set; }

        public int Fastest { get; set; }

        public int ScoringId { get; set; }
    }
}
