using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class Driver
    {
        public Driver(DriverCsvModel driverCsvModel)
        {
            this.Number = driverCsvModel.Id;
            this.Name = driverCsvModel.Name;
            this.Flag = driverCsvModel.Flag;
        }

        public int Number { get; }

        public string Name { get; }

        public string Flag { get; }
    }
}
