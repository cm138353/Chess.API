using Chess.API.Services.Chess;
using Chess.API.Services.Dtos.Chess;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Chess.API.Controllers;

[Route("api/[Controller]")]
public class ChessController : AbpController
{
    private IChessAppService _appService;
    public ChessController(IChessAppService appService)
    {
        _appService = appService;
    }

    [HttpGet]
    [Route("GetGame/{Id}")]
    public ActionResult<GameStateDto> GetGame(Guid Id)
    {
        var game = _appService.GetAsync(Id);
        if (game == null)
            return NotFound();

        return Ok(game);
    }

    [HttpPost]
    [Route("CreateGame")]
    public ActionResult<GameStateDto> CreateGame()
    {
        var game = _appService.CreateAsync();
        if (game == null)
            return StatusCode(500, "Could not save Game");

        return Ok(game);
    }

    [HttpPost]
    [Route("UpdateGame")]
    public async Task<ActionResult<GameStateDto>> UpdateGame(MakeMoveDto gameStateDto)
    {
        var game = await _appService.UpdateAsync(gameStateDto);
        if (game == null)
            return StatusCode(500, "Could not save Game");

        return Ok(game);
    }
}
