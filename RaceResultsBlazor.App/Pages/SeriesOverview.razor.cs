using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Pages
{
    public partial class SeriesOverview
    {
        private TimeSpan userOffset;

        [Parameter]
        public string Title { get; set; }

        public SeriesInfoViewModel InfoViewModel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.InfoViewModel = await this.ResultsService.GetSeriesInfoAsync(this.Title);

            this.userOffset = TimeSpan.FromMinutes(-await this.JsRuntime.InvokeAsync<int>("blazorGetTimezoneOffset", null));
        }

        protected string GetRaceDateString(DateTimeOffset dateTime)
        {
            var localDateTime = dateTime.ToOffset(this.userOffset);

            return $"{localDateTime:t} (UTC{localDateTime:zzz}), {localDateTime:D}";
        }
    }
}

