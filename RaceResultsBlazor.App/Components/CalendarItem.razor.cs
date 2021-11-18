using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Components
{
    public partial class CalendarItem
    {
        [Parameter]
        public RaceCalendarItemViewModel Race { get; set; }

        [Parameter]
        public TimeSpan UserTimeOffset { get; set; }

        public bool IsHidden { get; private set; } = true;

        public Action ToggleText
            => () => this.IsHidden = !this.IsHidden;

        public string DetailsClass
            => this.IsHidden ? "collapsed" : string.Empty;

        public string CollapseButtonClass
            => this.IsHidden ? "oi-caret-left" : "oi-caret-bottom";

        protected override Task OnParametersSetAsync()
        {
            if (this.Race.StartingTime < DateTimeOffset.UtcNow.AddDays(7) &&
                this.Race.StartingTime > DateTimeOffset.UtcNow.AddDays(-2))
            {
                this.IsHidden = false;
            }

            return base.OnParametersSetAsync();
        }

        protected string GetRaceDateString(DateTimeOffset dateTime)
        {
            var localDateTime = dateTime.ToOffset(this.UserTimeOffset);

            return $"{localDateTime:f} (UTC{localDateTime:zzz})";
        }

        protected string GetLapTimeString(TimeSpan lapTime)
            => $"{lapTime:mm\\:ss}";
    }
}
