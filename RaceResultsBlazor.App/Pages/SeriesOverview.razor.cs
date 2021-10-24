using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Pages
{
    public partial class SeriesOverview
    {
        [Parameter]
        public string Title { get; set; }

        public SeriesInfoViewModel InfoViewModel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.InfoViewModel = await this.ResultsService.GetSeriesInfoAsync(this.Title);
        }

        protected string GetRaceDateString(DateTimeOffset dateTime)
        {
            var localDateTime = dateTime.ToLocalTime();

            return $"{localDateTime:t} (UTC{localDateTime:zzz}), {localDateTime:D}";
        }
    }
}

