using System;
using System.Collections.Generic;
using System.Linq;
using ACCProjects.Models.Entities;
using ACCProjects.Utils.Helpers;

namespace RaceResultsBlazor.Models.Models.DriverModels
{
    public class ClassQualyDriver
    {

        public ClassQualyDriver(string playerId, long? raceNumber, int? carModel, string driver)
        {
            this.Id = playerId;
            this.RaceNumber = raceNumber;
            this.CarModelId = carModel;
            this.DriverName = driver;
        }

        public string Id { get; }

        public int Position { get; set; }

        public long? RaceNumber { get; }

        public int? CarModelId { get; }

        public string DriverName { get; }

        public int? DriverClass { get; set; }

        public List<Lap> Laps { get; private set; } = new();

        public string CarModel
            => CarModelsHelper.GetCarModel(this.CarModelId);

        public bool HasTimeSet
            => this.Laps.Any(l => l.IsValidForBest);

        public TimeSpan BestLapTime
            => TimeSpan.FromMilliseconds(this.HasTimeSet ? this.Laps.Where(l => l.IsValidForBest).Min(l => l.Laptime) : 0);

        public int ValidLaps
            => this.Laps.Count(l => l.IsValidForBest);

        public int TotalLaps
            => this.Laps.Count;

        public void AddLaps(List<Lap> laps)
            => this.Laps.AddRange(laps);

        public string DisplayClass
            => !this.HasTimeSet ? "no-laps" :
                this.ValidLaps < 5 ? "in-progress" :
                "laps-done";

        public string ClassString
        {
            get
            {
                return this.DriverClass switch
                {
                    0 => "am-class",
                    1 => "silver-class",
                    3 => "pro-class",
                    _ => "silver-class",
                };
            }
        }
    }
}
