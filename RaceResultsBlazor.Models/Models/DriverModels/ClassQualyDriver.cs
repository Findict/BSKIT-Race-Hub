using System;
using System.Collections.Generic;
using System.Linq;
using ACCProjects.Models.Entities;
using ACCProjects.Utils.Helpers;

namespace RaceResultsBlazor.Models.Models.DriverModels
{
    public class ClassQualyDriver
    {

        public ClassQualyDriver(string playerId, long? raceNumber, long? carModel, string driver)
        {
            this.Id = playerId;
            this.RaceNumber = raceNumber;
            this.CarModelId = carModel;
            this.DriverName = driver;
        }

        public string Id { get; }

        public long? RaceNumber { get; }

        public long? CarModelId { get; }

        public string DriverName { get; }

        public List<Lap> Laps { get; private set; } = new();

        public string CarModel
            => CarModelsHelper.GetCarModel(this.CarModelId);

        public bool HasTimeSet
            => this.Laps.Any(l => l.IsValidForBest);

        public int ValidLaps
            => this.Laps.Count(l => l.IsValidForBest);

        public int TotalLaps
            => this.Laps.Count();

        public void AddLaps(List<Lap> laps)
            => this.Laps.AddRange(laps);

        public string DisplayClass
            => !this.HasTimeSet ? "no-laps" :
                this.ValidLaps < 5 ? "in-progress" :
                "laps-done";
    }
}
