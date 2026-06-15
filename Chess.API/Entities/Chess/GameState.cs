using ChessDotNetCore;
using Volo.Abp.Domain.Entities.Auditing;

namespace Chess.API.Entities.Chess
{
    public class GameState : AuditedAggregateRoot<Guid>
    {
        public string CurrentFen { get; set; }
        public GameStatus Status { get; set; }
        public Player? Winner { get; set; }

        public DateTime? EndTime { get; set; }

        public ICollection<GameMove> Moves { get; set; } = new List<GameMove>();
    }
}
