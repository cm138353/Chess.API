using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Chess.API.Entities.Chess;
using Chess.API.Services.Dtos.Chess;

namespace Chess.API.ObjectMapping;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIGameStateToGameStateDtoMapper : MapperBase<GameState, GameStateDto>
{
    public override partial GameStateDto Map(GameState source);

    public override partial void Map(GameState source, GameStateDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIGameStateDtoToGameStateMapper : MapperBase<GameStateDto, GameState>
{
    public override partial GameState Map(GameStateDto source);

    public override partial void Map(GameStateDto source, GameState destination);
}

