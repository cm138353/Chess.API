using System.Text.Json.Serialization;

namespace Chess.API.Entities.Chess
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Color
    {
        White,
        Black
    }
}
