using System.Collections.Generic;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class TeamResultsViewModel
    {
        public string BackgroundPath { get; set; }

        public List<Team> TeamResults { get; set; }
    }
}