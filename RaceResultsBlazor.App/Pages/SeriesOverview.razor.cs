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

        public SeriesInfoViewModel InfoViewModel { get; private set; }

        public bool CalendarIsLoading { get; private set; }

        public SeriesOverview()
        {
            this.CalendarIsLoading = true;
        }

        protected override async Task OnParametersSetAsync()
        {
            var infoVM = await this.ResultsService.GetSeriesInfoAsync(this.Title);

            if (infoVM == null || !infoVM.IsPublished)
            {
                this.NavManager.NavigateTo(string.Empty);
                this.InfoViewModel = new SeriesInfoViewModel(null, null);
                return;
            }

            this.InfoViewModel = infoVM;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                this.userOffset = await this.TimeZoneService.GetUserDateTimeOffset();

                this.CalendarIsLoading = false;

                this.StateHasChanged();
            }
        }
    }
}

