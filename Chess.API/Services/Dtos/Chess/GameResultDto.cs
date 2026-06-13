using Chess.API.Entities.Chess;

namespace Chess.API.Services.Dtos.Chess
{
    public class GameResultDto
    {
        public Guid Id { get; set; }
        public Color Winner { get; set; }
        public IEnumerable<string> MoveHistory { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
