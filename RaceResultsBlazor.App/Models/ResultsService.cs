using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RaceResultsBlazor.App.Data
{
    public class ResultsService
    {
        private readonly List<SeriesRecords> seriesRecords = new();

        public ResultsService()
        {
            var directories = Directory.GetDirectories("data")
                .Select(d => d.Split('\\').Last());

            foreach (var title in directories)
            {
                seriesRecords.Add(new SeriesRecords(title));
            }
        }

        public Task<DriverResultsViewModel> GetDriverResultsAsync(string title)
        {
            var series = seriesRecords.FirstOrDefault(s => s.Info.Title == title);

            var results = new DriverResultsViewModel
            {
                DriverResults = series.GetDriverResults(),
                RaceImagePaths = series.GetRaceImages()
            };

            return Task.FromResult(results);
        }

        public Task<TeamResultsViewModel> GetTeamResultsAsync(string title)
        {
            var series = seriesRecords.FirstOrDefault(s => s.Info.Title == title);

            var results = new TeamResultsViewModel
            {
                TeamResults = series.GetTeamResults()
            };

            return Task.FromResult(results);
        }

        public Task<SeriesInfo[]> GetSeriesAsync()
            => Task.FromResult(this.seriesRecords.Select(r => r.Info).ToArray());
    }
}
