using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class SeriesSection
    {
        public SeriesSection(SeriesSectionDataModel section)
        {
            this.Title = section.Title;
            this.Content = section.Content;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
