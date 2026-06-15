using Chess.API.Entities.Chess;
using ChessDotNetCore;

namespace Chess.API.Services.Dtos.Chess
{
    public class GameStateDto
    {
        public string CurrentFen { get; set; }
        public GameStatus Status { get; set; }
        public Player? Winner { get; set; }

        public DateTime? EndTime { get; set; }

        public List<GameMove> Moves { get; set; }
    }
}
