using System.Collections.Generic;

namespace RaceResultsBlazor.Models.DataModels
{
    public class SeriesInfoDataModel
    {
        public string Title { get; set; }

        public int Index { get; set; }

        public bool CalculateTeamResults { get; set; }

        public PageOptionsDataModel PageOptions { get; set; }

        public ScoringMatrixDataModel[] ScoringMatrices { get; set; }

        public int? MaxRacesToCount { get; set; }
    }
}
