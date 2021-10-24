using System;
using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class Race
    {
        public Race(RaceCsvModel raceCsvModel, List<RaceResultCsvModel> raceResultCsvModels, SeriesInfo info)
        {
            this.Number = raceCsvModel.Number;
            this.TrackName = raceCsvModel.TrackName;
            this.Country = raceCsvModel.Country;
            this.RaceLength = raceCsvModel.RaceLength;
            this.StartingTime = raceCsvModel.StartTime;
            this.Scoring = info.ScoringMatrices.FirstOrDefault(s => s.Id == raceCsvModel.ScoringId);
            this.Results = raceResultCsvModels?.Select(r => new DriverResult
            {
                DriverId = r.Driver,
                Position = r.GetRaceArray()[this.Number - 1],
                IsPointsFinish = this.Scoring?.IsPointsFinish(r.GetRaceArray()[this.Number - 1]) ?? false,
                ExcludeFromCountback = this.Scoring?.ExcludeFromCountback ?? false,
                IsFastestLap = r.Driver == raceCsvModel.Fastest
            }).ToList();
        }

        public int Number { get; }

        public string TrackName { get; }

        public string Country { get; }

        public string RaceLength { get; }

        public DateTimeOffset StartingTime { get; }

        public ScoringMatrix Scoring { get; }

        public List<DriverResult> Results { get; set; }

        public int GetDriverScore(int driverId)
        {
            if (this.Scoring != null)
            {
                var result = this.Results.FirstOrDefault(r => r.DriverId == driverId);

                if (result != null)
                {
                    var bonus = result.IsFastestLap ? Scoring.GetScore("FL") : 0;

                    return Scoring.GetScore(result.Position) + bonus;
                }
            }

            return 0;
        }
    }
}
