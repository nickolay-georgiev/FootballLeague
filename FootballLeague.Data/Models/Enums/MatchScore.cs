using System.Text.Json.Serialization;

namespace FootballLeague.Data.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MatchScore
    {
        Loss = 0,
        Draw = 1,
        Win = 3,
    }
}
