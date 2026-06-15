using ChessDotNetCore;
using NUglify.Css;
using Volo.Abp.Domain.Entities.Auditing;

namespace Chess.API.Entities.Chess
{
    public class GameMove : AuditedEntity<int>
    {
        public Guid GameStateId { get; set; }

        public int MoveNumber { get; set; }
        public Player Player { get; set; }

        public string MoveUci { get; set; }
        public string MoveSan { get; set; }

        public string FenBefore { get; set; }
        public string FenAfter { get; set; }

    }
}
