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
            this.Title = info?.LongTitle;
            this.Races = races?.Select(r => new RaceCalendarItemViewModel(r)).ToList() ?? new List<RaceCalendarItemViewModel>();
            this.Sections = info?.Sections?.Select(s => new SeriesSectionViewModel(s)).ToList() ?? new List<SeriesSectionViewModel>();
            this.InternalLinks = info?.InternalLinks;
            this.HideCalendar = info?.HideCalendar ?? true;
            this.IsPublished = info?.IsPublished ?? false;
        }

        public string Title { get; }

        public List<RaceCalendarItemViewModel> Races { get; } 

        public List<SeriesSectionViewModel> Sections { get; }

        public List<Link> InternalLinks { get; }

        public bool HideCalendar { get; }

        public bool IsPublished { get; }

        public bool CalendarIsHidden { get; private set; } = false;

        public Action ToggleCalendar
            => () => this.CalendarIsHidden = !this.CalendarIsHidden;

        public string CalendarClass
            => this.CalendarIsHidden ? "collapsed" : string.Empty;

        public string CalendarCollapseButtonClass
            => this.CalendarIsHidden ? "oi-caret-left" : "oi-caret-bottom";
    }
}
