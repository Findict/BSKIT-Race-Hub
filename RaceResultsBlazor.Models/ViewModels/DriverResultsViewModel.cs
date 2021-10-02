using System.Collections.Generic;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class DriverResultsViewModel
    {
        public string BackgroundPath { get; set; }

        public List<string> RaceImagePaths { get; set; } = new List<string>();

        public List<DriverLine> DriverResults { get; set; } = new List<DriverLine>();
    }
}
