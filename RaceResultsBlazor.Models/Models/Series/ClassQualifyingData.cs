using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models
{
    public class ClassQualifyingData
    {
        public ClassQualifyingData(ClassQualifyingDataModel classQualifyingData)
        {
            this.EntrylistUrl = classQualifyingData.EntryListUrl;
            this.ResultsFilesLocation = classQualifyingData.ResultsFilesLocation;
            this.Track = classQualifyingData.Track;
            this.BackgroundImagePath = classQualifyingData.BackgroundImagePath;
        }

        public string EntrylistUrl { get; }

        public string ResultsFilesLocation { get; }

        public string Track { get; }

        public string BackgroundImagePath { get; }
    }
}
