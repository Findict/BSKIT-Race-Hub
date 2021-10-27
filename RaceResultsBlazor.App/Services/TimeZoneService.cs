using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace RaceResultsBlazor.App.Services
{
    public class TimeZoneService
    {
        private readonly IJSRuntime _jsRuntime;

        private TimeSpan? _userOffset;

        public TimeZoneService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task<TimeSpan> GetUserDateTimeOffset()
        {
            if (_userOffset == null)
            {
                int offsetInMinutes = await _jsRuntime.InvokeAsync<int>("blazorGetTimezoneOffset");
                _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
            }

            return _userOffset ?? TimeSpan.Zero;
        }
    }
}
