using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACCProjects.Utils.Helpers;
using RaceResultsBlazor.Models.Models.DriverModels;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Services
{
    public class ClassQualifyingService
    {
        public Task<ClassQualyDriver[]> GetResults(ClassQualifyingViewModel info)
        {
            var drivers = this.UpdateDrivers(info);
            this.UpdateLaps(info, drivers);

            return Task.FromResult(drivers);
        }

        private ClassQualyDriver[] UpdateDrivers(ClassQualifyingViewModel info)
            => EntryListHelper.GetEntryListFromUrl(info.EntrylistUrl).Entries
                .Select(e => new ClassQualyDriver(e.Drivers.First().PlayerId, e.RaceNumber, e.ForcedCarModel, e.Drivers.First().FullName)).ToArray();

        private void UpdateLaps(ClassQualifyingViewModel info, ClassQualyDriver[] drivers)
        {
            var files = Directory.GetFiles(info.ResultsFilesLocation);

            foreach (var file in files)
            {
                var result = ResultsFileHelper.GetResultsFromJson(file);

                if (string.IsNullOrWhiteSpace(info.Track) || info.Track == result.TrackName)
                {
                    foreach (var driver in drivers)
                    {
                        var laps = result.LapsByPlayerIdAndCarModel(driver.Id, driver.CarModelId);

                        if (laps != null)
                        {
                            driver.AddLaps(laps);
                        }
                    }
                }
            }
        }
    }
}
