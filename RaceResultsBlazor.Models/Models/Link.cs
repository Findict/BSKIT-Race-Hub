using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class Link
    {
        public Link(LinkDataModel link)
        {
            this.Title = link.Title;
            this.Href = link.Href;
        }

        public string Title { get; set; }

        public string Href { get; set; }
    }
}
