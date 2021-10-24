using System;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class SeriesSectionViewModel
    {
        public SeriesSectionViewModel(SeriesSection section)
        {
            this.Title = section.Title;
            this.Content = section.Content;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public bool IsHidden { get; private set; } = false;

        public Action ToggleText
            => () => this.IsHidden = !this.IsHidden;

        public string TextClass
            => this.IsHidden ? "collapsed" : string.Empty;

        public string CollapseButtonClass
            => this.IsHidden ? "oi-caret-left" : "oi-caret-bottom";

    }
}
