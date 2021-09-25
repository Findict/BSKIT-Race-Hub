using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RaceResultsBlazor.App.Models;
using RaceResultsBlazor.App.ViewModels;

namespace RaceResultsBlazor.App.Services
{
    public class ResultsService
    {
        private readonly List<SeriesRecords> seriesRecords = new();

        public ResultsService()
        {
            this.GetSeriesData();
        }

        private void GetSeriesData()
        {
            var directories = Directory.GetDirectories(@"wwwroot\data")
                            .Select(d => d.Split('\\').Last());

            foreach (var title in directories)
            {
                seriesRecords.Add(new SeriesRecords(title));
            }
        }

        public Task RefreshData()
        {
            seriesRecords.Clear();

            this.GetSeriesData();

            return Task.CompletedTask;
        }

        public Task<DriverResultsViewModel> GetDriverResultsAsync(string title)
        {
            var series = seriesRecords.FirstOrDefault(s => s.Info.Name == title);

            var results = new DriverResultsViewModel
            {
                BackgroundPath = $@"data/{title}/drivers-bg.png",
                DriverResults = series.GetDriverResults(),
                RaceImagePaths = series.GetRaceImages()
            };

            return Task.FromResult(results);
        }

        public Task<TeamResultsViewModel> GetTeamResultsAsync(string title)
        {
            var series = seriesRecords.FirstOrDefault(s => s.Info.Name == title);

            var results = new TeamResultsViewModel
            {
                BackgroundPath = $@"data/{title}/teams-bg.png",
                TeamResults = series.GetTeamResults()
            };

            return Task.FromResult(results);
        }

        public Task<SeriesInfo[]> GetSeriesAsync()
            => Task.FromResult(this.seriesRecords.Select(r => r.Info).ToArray());
    }
}
