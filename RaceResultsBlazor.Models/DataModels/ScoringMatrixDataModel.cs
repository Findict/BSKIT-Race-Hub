using System.Collections.Generic;

namespace RaceResultsBlazor.Models.DataModels
{
    public class ScoringMatrixDataModel
    {
        public int Id { get; set; }

        public bool ExcludeFromCountback { get; set; }

        public Dictionary<string, int> Scoring { get; set; }
    }
}