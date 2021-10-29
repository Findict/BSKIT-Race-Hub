using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaceResultsBlazor.Models.Models;
using RaceResultsBlazor.Models.ViewModels;

namespace RaceResultsBlazor.App.Components
{
    public partial class CalendarItem
    {
        [Parameter]
        public RaceCalendarItemViewModel Race { get; set; }

        [Parameter]
        public TimeSpan UserTimeOffset { get; set; }

        protected string GetRaceDateString(DateTimeOffset dateTime)
        {
            var localDateTime = dateTime.ToOffset(this.UserTimeOffset);

            return $"{localDateTime:t} (UTC{localDateTime:zzz}), {localDateTime:D}";
        }
    }
}
