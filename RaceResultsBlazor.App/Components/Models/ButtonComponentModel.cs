using System;

namespace RaceResultsBlazor.App.Components.Models
{
    public class ButtonComponentModel
    {
        public string Title { get; set; }

        public Action ButtonAction { get; set; }

        public string Classes { get; set; }
    }
}
