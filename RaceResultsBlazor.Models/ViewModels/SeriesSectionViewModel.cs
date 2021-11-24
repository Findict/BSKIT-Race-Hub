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
    }
}
