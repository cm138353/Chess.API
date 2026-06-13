using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Chess.API.Entities.Books;
using Chess.API.Services.Dtos.Books;
using Chess.API.Entities.Chess;
using Chess.API.Services.Dtos.Chess;

namespace Chess.API.ObjectMapping;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APICreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIBookDtoToCreateUpdateBookDtoMapper : MapperBase<BookDto, CreateUpdateBookDto>
{
    public override partial CreateUpdateBookDto Map(BookDto source);

    public override partial void Map(BookDto source, CreateUpdateBookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIGameStateToGameStateDtoMapper : MapperBase<GameResult, GameResultDto>
{
    public override partial GameResultDto Map(GameResult source);

    public override partial void Map(GameResult source, GameResultDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class APIGameStateDtoToGameStateMapper : MapperBase<GameResultDto, GameResult>
{
    public override partial GameResult Map(GameResultDto source);

    public override partial void Map(GameResultDto source, GameResult destination);
}

