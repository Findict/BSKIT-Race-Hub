using System;
using System.Collections.Generic;
using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class ScoringMatrix
    {
        public ScoringMatrix(ScoringMatrixDataModel m)
        {
            this.Id = m.Id;
            this.ExcludeFromCountback = m.ExcludeFromCountback;
            this.Scoring = m.Scoring;
        }

        public int Id { get; }

        public bool ExcludeFromCountback { get; }

        private Dictionary<string, int> Scoring { get; }

        public int GetScore(string position)
        {
            if (this.Scoring != null && !string.IsNullOrWhiteSpace(position))
            {
                return this.Scoring.TryGetValue(position, out int result) ? result : 0;
            }

            return 0;
        }

        internal bool IsPointsFinish(string position)
            => this.GetScore(position) > 0;
    }
}