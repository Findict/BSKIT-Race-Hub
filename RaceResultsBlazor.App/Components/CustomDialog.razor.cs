using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.App.Components.Models;

namespace RaceResultsBlazor.App.Components
{
    public partial class CustomDialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<ButtonComponentModel> Buttons { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
