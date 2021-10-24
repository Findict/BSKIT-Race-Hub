using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RaceResultsBlazor.Models.Models;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Services
{
    public class ResultsService
    {
        private readonly List<SeriesRecords> seriesRecords = new();
        private DateTime lastRefreshed;


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

            this.lastRefreshed = DateTime.Now;

            return Task.CompletedTask;
        }

        public Task<SeriesInfoViewModel> GetSeriesInfoAsync(string title)
        {
            var series = seriesRecords.FirstOrDefault(s => s.Info.Name == title);

            if (series == null)
            {
                return null;
            }

            var info = new SeriesInfoViewModel(series.Info, series.GetRaces());

            return Task.FromResult(info);
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

        public Task<SeriesInfo[]> GetSeriesAsync(bool forceRefresh = false)
        {
            if (forceRefresh || this.lastRefreshed.AddMinutes(5) < DateTime.Now)
            {
                this.RefreshData();
            }

            return Task.FromResult(this.seriesRecords.Select(r => r.Info).OrderBy(r => r.Index).ToArray());
        }
    }
}
