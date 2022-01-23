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
            this.RevealLapTimes = classQualifyingData.RevealLapTimes;
            this.ClassFile = classQualifyingData.ClassFile;
        }

        public string EntrylistUrl { get; }

        public string ResultsFilesLocation { get; }

        public string Track { get; }

        public string BackgroundImagePath { get; }

        public bool RevealLapTimes { get; }

        public string ClassFile { get; }
    }
}
