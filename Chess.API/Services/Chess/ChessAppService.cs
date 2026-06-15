using Chess.API.Entities.Chess;
using Chess.API.Services.Dtos.Chess;
using ChessDotNetCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Chess.API.Services.Chess
{
    public class ChessAppService : ApplicationService, IChessAppService
    {
        private readonly IRepository<GameState, Guid> _repository;
        private readonly IChessService _chessService;
        public const string StartingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        public ChessAppService(IRepository<GameState, Guid> repository, IChessService chessService)
        {
            _repository = repository;
            this._chessService = chessService;
        }

        public async Task<GameStateDto> CreateAsync()
        {
            var newGameState = new GameState
            {
                CurrentFen = StartingFen,
                Status = GameStatus.InProgress,
                Winner = null,
                EndTime = null,
                Moves = new List<GameMove>()
            };
            
            await _repository.InsertAsync(newGameState, true);
              
            return ObjectMapper.Map<GameState, GameStateDto>(newGameState);
        }

        public async Task<GameStateDto> GetAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);
            return ObjectMapper.Map<GameState, GameStateDto>(book);
        }

        public Task<PagedResultDto<GameStateDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<GameStateDto> UpdateAsync(MakeMoveDto input)
        {
            var gameState = await _repository.GetAsync(input.GameId);

            var fenBefore = gameState.CurrentFen;

            var result = _chessService.MakeMove(fenBefore, input.MoveUci);

            if (!result.IsValid)
            {
                throw new UserFriendlyException("Move is invalid.");
            }

            gameState.CurrentFen = result.FenAfter;
            gameState.Status = result.Status;
            gameState.Winner = result.Winner;
            gameState.EndTime = result.EndTime;

            gameState.Moves.Add(new GameMove
            {
                GameStateId = gameState.Id,
                MoveNumber = gameState.Moves.Count + 1,
                Player = result.Player,
                MoveUci = input.MoveUci,
                MoveSan = result.MoveSan,
                FenBefore = fenBefore,
                FenAfter = result.FenAfter
            });

            await _repository.UpdateAsync(gameState, autoSave: true);

            return ObjectMapper.Map<GameState, GameStateDto>(gameState);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
