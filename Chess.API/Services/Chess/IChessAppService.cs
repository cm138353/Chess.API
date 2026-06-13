using Chess.API.Services.Dtos.Books;
using Chess.API.Services.Dtos.Chess;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Chess.API.Services.Chess
{
    public interface IChessAppService :
            ICrudAppService< //Defines CRUD methods
            GameResultDto, //Used to show game
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            GameResultDto> //Used to create/update a book
    {
    }
}
