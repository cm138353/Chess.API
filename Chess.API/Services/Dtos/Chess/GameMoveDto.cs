using Chess.API.Entities.Chess;
using ChessDotNetCore;

namespace Chess.API.Services.Dtos.Chess
{
    public class GameMoveDto
    {
        public int MoveNumber { get; set; }
        public Player Player { get; set; }

        public string MoveUci { get; set; }
        public string MoveSan { get; set; }

        public string FenBefore { get; set; }
        public string FenAfter { get; set; }
    }
}
