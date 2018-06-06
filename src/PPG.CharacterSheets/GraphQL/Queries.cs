using GraphQL.Relay.Types;
using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Core.Helpers;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.Types;
using PPG.CharacterSheets.RuleSets.Entities;
using System;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.GraphQL
{
    public class Queries : QueryGraphType
    {
        public Queries(
            ICRUDService<Character, CharacterSummary> characterCRUDService, ICRUDService<RuleSetInfo> ruleSetInfoCRUDService,
            ICreateCharacterInfoBuilderFactory createCharacterInfoBuilderFactory
        )
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

            Field<CreateCharacterInfoType>(
                "createCharacterInfo",
                arguments: new QueryArguments(new QueryArgument<EnumerationGraphType<RuleSet>> { Name = "ruleSet" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var ruleSet = context.GetArgument<RuleSet>("ruleSet");
                        var createCharacterInfo = await createCharacterInfoBuilderFactory.Resolve(ruleSet).Build(null).ConfigureAwait(false);
                        return createCharacterInfo;
                    });
                }
            );
        }
    }
}
