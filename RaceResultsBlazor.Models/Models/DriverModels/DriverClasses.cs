using System;
using System.Linq;
using RaceResultsBlazor.Models.DataModels;

namespace RaceResultsBlazor.Models.Models.DriverModels
{
    public class DriverClasses
    {
        public DriverClasses(DriverClassesDataModel dataModel)
        {
            this.Pro = dataModel?.Pro;
            this.Am = dataModel?.Am;
        }

        public int[] Pro { get; }

        public int[] Am { get; }

        public int? GetDriverClass(long? raceNumber)
        {
            if (raceNumber == null)
            {
                return null;
            }

            var number = (int)raceNumber;

            return this.Am?.Contains(number) ?? false ? 0 :
                this.Pro?.Contains(number) ?? false ? 3 : 1;
        }
    }
}