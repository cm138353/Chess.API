namespace Chess.API.Services.Dtos.Chess
{
    public class MakeMoveDto
    {
        public Guid GameId { get; set; }
        public string MoveUci { get; set; }
    }
}
