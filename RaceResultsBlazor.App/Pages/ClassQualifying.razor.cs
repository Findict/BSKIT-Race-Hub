using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.Models.DriverModels;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Pages
{
    public partial class ClassQualifying
    {
        private SeriesInfoViewModel infoVM;
        private ClassQualyDriver[] drivers;
        private bool hasLoaded;

        [Parameter]
        public string Title { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            this.infoVM = await this.ResultsService.GetSeriesInfoAsync(this.Title);

            if (this.infoVM == null || !this.infoVM.IsPublished || infoVM.ClassQualifyingData == null)
            {
                this.NavManager.NavigateTo(string.Empty);
                return;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await this.UpdateData();

                this.hasLoaded = true;

                this.StateHasChanged();
            }
        }

        private async Task UpdateData()
        {
            drivers = (await ClassQualifyingService.GetResults(this.infoVM.ClassQualifyingData))
                .OrderByDescending(d => d.ValidLaps)
                .ThenByDescending(d => d.TotalLaps)
                .ThenBy(d => d.RaceNumber).ToArray();

            if (this.infoVM.ClassQualifyingData.RevealLapTimes)
            {
                drivers = drivers.OrderByDescending(d => d.HasTimeSet).ThenBy(d => d.BestLapTime).ToArray();

                var bestTime = drivers.Where(d => d.ValidLaps > 0).Min(d => d.BestLapTime);

                foreach (var driver in drivers)
                {
                    driver.Position = drivers.Count(d => (driver.HasTimeSet ? (d.HasTimeSet && d.BestLapTime < driver.BestLapTime) : d.HasTimeSet)) + 1;
                    driver.Gap = driver.HasTimeSet ? driver.BestLapTime - bestTime : TimeSpan.Zero;
                }
            }

            this.StateHasChanged();
        }
    }
}

