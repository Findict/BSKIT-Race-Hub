using System.Collections.Generic;
using RaceResultsBlazor.App.Models;

namespace RaceResultsBlazor.App.ViewModels
{
    public class TeamResultsViewModel
    {
        public string BackgroundPath { get; set; }

        public List<Team> TeamResults { get; set; }
    }
}