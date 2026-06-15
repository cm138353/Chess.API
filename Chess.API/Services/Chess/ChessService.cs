using Chess.API.Entities.Chess;
using ChessDotNetCore;
using Volo.Abp.DependencyInjection;

namespace Chess.API.Services.Chess
{
    public class ChessService : IChessService, ITransientDependency
    {
        public ChessService()
        {

        }

        public MakeMoveResult MakeMove(string fen, string moveUci)
        {
            var game = new ChessGame(fen);

            var move = ParseMove(fen, moveUci);

            if (!game.IsValidMove(move))
            {
                return new MakeMoveResult
                {
                    IsValid = false
                };
            }

            game.MakeMove(move, true);

            return new MakeMoveResult
            {
                IsValid = true,
                FenAfter = game.GetFen(),
                Player = move.Player,
                MoveSan = moveUci, // temporary
                Status = GetGameStatus(game)
            };
        }

        private GameStatus GetGameStatus(ChessGame game)
        {
            if (game.IsCheckmated(Player.White) ||
                game.IsCheckmated(Player.Black))
            {
                return GameStatus.Checkmate;
            }

            if (game.IsStalemated(Player.White) ||
                game.IsStalemated(Player.Black))
            {
                return GameStatus.Stalemate;
            }

            if (game.IsDraw())
            {
                return GameStatus.Draw;
            }

            if (game.IsInCheck(Player.White) ||
                game.IsInCheck(Player.Black))
            {
                return GameStatus.Check;
            }

            return GameStatus.InProgress;
        }

        public Move ParseMove(string fen, string move)
        {
            var game = new ChessGame(fen);
            var original = move[..2];
            var line = original[0].ToString();
            byte rank = (byte)(original[1] - '1'); 
            var newPosition = move[2..];
            var newLine = newPosition[0].ToString();
            byte newRank = (byte)(newPosition[1] - '1');
            return new Move(new Position(Enum.Parse<Line>(line), rank), new Position(Enum.Parse<Line>(newLine), newRank), game.CurrentPlayer);
        }
    }

    public class MakeMoveResult
    {
        public bool IsValid { get; set; }
        public string FenAfter { get; set; }
        public Player Player { get; set; }
        public string MoveSan { get; set; }
        public GameStatus Status { get; set; }
        public Player? Winner { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
