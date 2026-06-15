using ChessDotNetCore;
using Volo.Abp.DependencyInjection;

namespace Chess.API.Services.Chess
{
    public interface IChessService 
    {
        MakeMoveResult MakeMove(string fen, string move);
        Move ParseMove(string fen, string move);
    }
}
