using System;
using System.Collections.Generic;
using System.Linq;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class SeriesInfoViewModel
    {
        public SeriesInfoViewModel(SeriesInfo info, List<Race> races)
        {
            this.Title = info.LongTitle;
            this.Races = races ?? new List<Race>();
            this.Sections = info.Sections?.Select(s => new SeriesSectionViewModel(s)).ToList() ?? new List<SeriesSectionViewModel>();
            this.InternalLinks = info.InternalLinks;
            this.HideCalendar = info.HideCalendar;
        }

        public string Title { get; private set; }

        public List<Race> Races { get; private set; } 

        public List<SeriesSectionViewModel> Sections { get; private set; }

        public List<Link> InternalLinks { get; private set; }

        public bool HideCalendar { get; private set; }

        public bool CalendarIsHidden { get; private set; } = false;

        public Action ToggleCalendar
            => () => this.CalendarIsHidden = !this.CalendarIsHidden;

        public string CalendarClass
            => this.CalendarIsHidden ? "collapsed" : string.Empty;

        public string CalendarCollapseButtonClass
            => this.CalendarIsHidden ? "oi-caret-left" : "oi-caret-bottom";
    }
}
