namespace RaceResultsBlazor.Models.DataModels
{
    public class TeamCsvModel
    {
        public string Name { get; set; }
        
        public string Country { get; set; }

        public string Color { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public bool ForceHide { get; set; }
    }
}
