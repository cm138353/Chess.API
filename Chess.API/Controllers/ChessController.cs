using Chess.API.Services.Dtos.Chess;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Chess.API.Controllers;

[Route("api/[Controller]")]
public class ChessController : AbpController
{

    [HttpGet]
    
    public ActionResult<GameStateDto> GetGame()
    {

        return Redirect("~/swagger");
    }
}
