using GraphQL.Relay.Types;
using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL
{
    public class CharactersQuery : QueryGraphType
    {
        public CharactersQuery(ICRUDService<Character, CharacterSummary> crudService)
        {
            Name = "Query";
            Field<ListGraphType<CharacterSummaryType>>(
                "characters",
                resolve: context => crudService.Read()
            );
            Field<CharacterSummaryType>(
                "character",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => crudService.Read(context.GetArgument<int>("id"))
            );
        }
    }
}
