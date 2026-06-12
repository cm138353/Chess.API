using System.Drawing;
using Volo.Abp.Domain.Entities.Auditing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chess.API.Entities.Chess
{
    public class GameState : AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public Color Winner { get; set; }
        public IEnumerable<string> MoveHistory { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
