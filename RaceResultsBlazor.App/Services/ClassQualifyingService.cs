using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACCProjects.Utils.Helpers;
using RaceResultsBlazor.Models.DataModels;
using RaceResultsBlazor.Models.Models.DriverModels;
using RaceResultsBlazor.Models.ViewModels;
using RaceResultsBlazor.Utils.Helpers;

namespace RaceResultsBlazor.App.Services
{
    public class ClassQualifyingService
    {
        public Task<ClassQualyDriver[]> GetResults(ClassQualifyingViewModel info)
        {
            var drivers = UpdateDrivers(info);
            UpdateLaps(info, drivers);
            UpdateClass(info, drivers);

            return Task.FromResult(drivers);
        }

        private static ClassQualyDriver[] UpdateDrivers(ClassQualifyingViewModel info)
            => EntryListHelper.GetEntryListFromUrl(info.EntrylistUrl).Entries
                .Select(e => new ClassQualyDriver(e.Drivers.First().PlayerId, e.RaceNumber, e.ForcedCarModel, e.Drivers.First().FullName)).ToArray();

        private static void UpdateLaps(ClassQualifyingViewModel info, ClassQualyDriver[] drivers)
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

        private static void UpdateClass(ClassQualifyingViewModel info, ClassQualyDriver[] drivers)
        {
            if (File.Exists(info.ClassFile))
            {
                var classLists = new DriverClasses(DataFileHelper.GetJsonData<DriverClassesDataModel>(info.ClassFile));

                foreach (var driver in drivers)
                {
                    driver.DriverClass = classLists.GetDriverClass(driver.RaceNumber);
                }
            }
        }
    }
}
