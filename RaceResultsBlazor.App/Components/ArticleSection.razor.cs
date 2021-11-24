using System;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Components
{
    public partial class ArticleSection
    {
        [Parameter]
        public SeriesSectionViewModel Section { get; set; }

        public bool IsHidden { get; private set; } = false;

        public Action ToggleText
            => () => this.IsHidden = !this.IsHidden;

        public string TextClass
            => this.IsHidden ? "collapsed" : string.Empty;

        public string CollapseButtonClass
            => this.IsHidden ? "oi-caret-left" : "oi-caret-bottom";
    }
}
