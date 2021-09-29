using System.Collections.Generic;
using System.IO;
using ServiceStack.Text;

namespace RaceResultsBlazor.App.Helpers
{
    public static class DataFileHelper
    {

        public static List<T> GetCsvData<T>(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }

            using var stream = File.OpenRead(file);

            return CsvSerializer.DeserializeFromStream<List<T>>(stream);
        }

        public static T GetJsonData<T>(string file)
        {
            if (!File.Exists(file))
            {
                return default;
            }

            using var stream = File.OpenRead(file);

            return JsonSerializer.DeserializeFromStream<T>(stream);
        }
    }
}
