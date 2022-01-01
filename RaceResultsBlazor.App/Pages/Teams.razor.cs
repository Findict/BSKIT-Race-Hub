﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Pages
{
    public partial class Teams
    {
        private TeamResultsViewModel results;
        private DriverResultsViewModel drivers;

        [Parameter]
        public string Title { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var infoVM = await this.ResultsService.GetSeriesInfoAsync(this.Title);

            if (infoVM == null || !infoVM.IsPublished)
            {
                this.NavManager.NavigateTo(string.Empty);
                return;
            }

            await this.UpdateData();
        }

        private async Task UpdateData()
        {
            results = await ResultsService.GetTeamResultsAsync(Title);
            drivers = await ResultsService.GetDriverResultsAsync(Title);
            this.StateHasChanged();
        }
    }
}

