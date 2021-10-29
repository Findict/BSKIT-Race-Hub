using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Components
{
    public partial class ArticleSection
    {
        [Parameter]
        public SeriesSectionViewModel Section { get; set; }
    }
}
