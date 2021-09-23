using System.Collections.Generic;

namespace RaceResultsBlazor.App.Data
{
    public class DriverResultsViewModel
    {
        public string BackgroundPath { get; set; }

        public List<string> RaceImagePaths { get; set; } = new List<string>();

        public List<DriverLine> DriverResults { get; set; } = new List<DriverLine>();
    }
}
