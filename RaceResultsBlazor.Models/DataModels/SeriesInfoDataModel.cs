namespace RaceResultsBlazor.Models.DataModels
{
    public class SeriesInfoDataModel
    {
        public string Title { get; set; }

        public string LongTitle { get; set; }

        public int Index { get; set; }

        public bool CalculateTeamResults { get; set; }

        public bool HideCalendar { get; set; }

        public ScoringMatrixDataModel[] ScoringMatrices { get; set; }

        public int? MaxRacesToCount { get; set; }

        public SeriesSectionDataModel[] Sections { get; set; }

        public LinkDataModel[] InternalLinks { get; internal set; }
    }
}
