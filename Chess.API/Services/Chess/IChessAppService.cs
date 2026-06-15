using Chess.API.Services.Dtos.Chess;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Chess.API.Services.Chess
{
    public interface IChessAppService 
    {
        Task<GameStateDto> CreateAsync();
        Task<GameStateDto> GetAsync(Guid id);
        Task<PagedResultDto<GameStateDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<GameStateDto> UpdateAsync(MakeMoveDto input);
        Task DeleteAsync(Guid id);

    }
}
