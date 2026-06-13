using Volo.Abp.Domain.Entities.Auditing;

namespace Chess.API.Entities.Chess;

public class GameResult : AuditedAggregateRoot<Guid>
{
    public Color Winner { get; set; }

    public List<string> MoveHistory { get; set; } = new();

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}