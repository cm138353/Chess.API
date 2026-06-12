using Chess.API.Entities.Books;
using Chess.API.Entities.Chess;
using Chess.API.Services.Dtos.Books;
using Chess.API.Services.Dtos.Chess;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Chess.API.Services.Chess
{
    public class ChessAppService : ApplicationService, IChessAppService
    {
        private readonly IRepository<GameState, Guid> _repository;

        public ChessAppService(IRepository<GameState, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<GameStateDto> GetAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);
            return ObjectMapper.Map<GameState, GameStateDto>(book);
        }


    }
}
