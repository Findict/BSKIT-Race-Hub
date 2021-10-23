using System.Threading.Tasks;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.App.Shared
{
    public partial class NavMenu
    {
        private SeriesInfo[] series;

        private bool collapseNavMenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override async Task OnInitializedAsync()
        {
            series = await ResultsService.GetSeriesAsync();
        }

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void NavigateHome()
        {
            NavManager.NavigateTo("");
        }
    }
}
