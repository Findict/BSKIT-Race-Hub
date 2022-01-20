using System;
using RaceResultsBlazor.Models.Models;

namespace RaceResultsBlazor.Models.ViewModels
{
    public class ClassQualifyingViewModel
    {
        public ClassQualifyingViewModel(ClassQualifyingData classQualifyingData)
        {
            this.EntrylistUrl = classQualifyingData.EntrylistUrl;
            this.ResultsFilesLocation = classQualifyingData.ResultsFilesLocation;
            this.Track = classQualifyingData.Track;
            this.BackgroundImagePath = classQualifyingData.BackgroundImagePath;
            this.RevealLapTimes = classQualifyingData.RevealLapTimes;
        }

        public string EntrylistUrl { get; }

        public string ResultsFilesLocation { get; }

        public string Track { get; }

        public string BackgroundImagePath { get; }

        public bool RevealLapTimes { get; }
    }
}