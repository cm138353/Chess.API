using Chess.API.Entities.Books;
using Chess.API.Entities.Chess;
using Chess.API.Services.Dtos.Books;
using Chess.API.Services.Dtos.Chess;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Chess.API.Services.Chess
{
    public class ChessAppService : ApplicationService, IChessAppService
    {
        private readonly IRepository<GameResult, Guid> _repository;

        public ChessAppService(IRepository<GameResult, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<GameResultDto> CreateAsync(GameResultDto input)
        {
            var game = ObjectMapper.Map<GameResultDto, GameResult>(input);
            await _repository.InsertAsync(game);
            return ObjectMapper.Map<GameResult, GameResultDto>(game);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameResultDto> GetAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);
            return ObjectMapper.Map<GameResult, GameResultDto>(book);
        }

        public Task<PagedResultDto<GameResultDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<GameResultDto> UpdateAsync(Guid id, GameResultDto input)
        {
            throw new NotImplementedException();
        }
    }
}
