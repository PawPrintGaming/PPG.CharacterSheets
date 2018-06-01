using GraphQL.Relay.Types;
using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Helpers;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.Types;
using PPG.CharacterSheets.RuleSets.Entities;
using System;

namespace PPG.CharacterSheets.GraphQL
{
    public class CharactersQuery : QueryGraphType
    {
        public CharactersQuery(ICRUDService<Character, CharacterSummary> characterCRUDService, ICRUDService<RuleSetInfo> ruleSetInfoCRUDService)
        {
            Name = "Query";

            Field<ListGraphType<CharacterSummaryType>>(
                "characters",
                resolve: context => characterCRUDService.Read()
            );
            Field<CharacterSummaryType>(
                "character",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => characterCRUDService.Read(context.GetArgument<int>("id"))
            );

            Field<ListGraphType<EnumerationGraphType<RuleSet>>>(
                "ruleSets",
                resolve: content => EnumHelper.GetAllValues<RuleSet>()
            );
            Field<ListGraphType<RuleSetInfoType>>(
                "ruleSetInfos",
                resolve: context => ruleSetInfoCRUDService.Read()
            );
        }
    }
}
