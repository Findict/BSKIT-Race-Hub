namespace RaceResultsBlazor.Models.DataModels
{
    public class RaceResultCsvModel
    {
        public int Driver { get; set; }

        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        public string R4 { get; set; }
        public string R5 { get; set; }
        public string R6 { get; set; }
        public string R7 { get; set; }
        public string R8 { get; set; }
        public string R9 { get; set; }
        public string R10 { get; set; }
        public string R11 { get; set; }
        public string R12 { get; set; }
        public string R13 { get; set; }
        public string R14 { get; set; }
        public string R15 { get; set; }
        public string R16 { get; set; }
        public string R17 { get; set; }
        public string R18 { get; set; }
        public string R19 { get; set; }
        public string R20 { get; set; }
        public string R21 { get; set; }
        public string R22 { get; set; }
        public string R23 { get; set; }
        public string R24 { get; set; }
        public string R25 { get; set; }
        public string R26 { get; set; }
        public string R27 { get; set; }
        public string R28 { get; set; }
        public string R29 { get; set; }
        public string R30 { get; set; }

        public string[] GetRaceArray()
            => new[]
            {
                R1,
                R2,
                R3,
                R4,
                R5,
                R6,
                R7,
                R8,
                R9,
                R10,
                R11,
                R12,
                R13,
                R14,
                R15,
                R16,
                R17,
                R18,
                R19,
                R20,
                R21,
                R22,
                R23,
                R24,
                R25,
                R26,
                R27,
                R28,
                R29,
                R30
            };
    }
}
