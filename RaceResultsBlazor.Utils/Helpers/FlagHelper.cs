namespace RaceResultsBlazor.Utils.Helpers
{
    public static class FlagHelper
    {
        public static string ImageFromString(string country)
            => $"assets/flags/{country?.ToLower().Trim().Replace(' ', '-') ?? string.Empty}.png";
    }
}
