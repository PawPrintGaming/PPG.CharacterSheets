using GraphQL.Types;
using Newtonsoft.Json;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.InputTypes;
using PPG.CharacterSheets.GraphQL.Types;
using PPG.CharacterSheets.RuleSets.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.GraphQL
{
    public class Mutations : ObjectGraphType<CharacterSummary>
    {
        public Mutations(
            ICRUDService<Character, CharacterSummary> characterCRUDService,
            ICRUDService<RuleSetInfo> ruleSetInfoCRUDService,
            IMapper<CharacterSummary, CreateCharacter> createMapper,
            IMapper<CharacterSummary, UpdateCharacter> updateMapper,
            ICharacterPolymorphService characterPolymorphService
        )
        {
            Name = "Mutation";

            Field<CharacterSummaryType>(
                "createCharacter",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateCharacterType>> { Name = "createCharacter" }),
                resolve: context => {
                    return Task.Run(async () =>
                    {
                        //var step1 = context.Arguments["createCharacter"];
                        //var step2 = (step1 as Dictionary<string, object>)["stats"];
                        //var step3 = (step2 as object[])[0];
                        //var step4 = (step3 as Dictionary<string, object>);
                        //var keyValues = new List<KeyValuePair<string, int>>();
                        //keyValues.Add(new KeyValuePair<string, int>(step4["key"].ToString(), int.Parse(step4["value"].ToString())));
                        //var create = new CreateCharacter { Stats =  keyValues };

                        //var fromGraphQL = context.GetArgument<CreateCharacter>("createCharacter");

                        var createCharacter = JsonConvert.DeserializeObject<CreateCharacter>(JsonConvert.SerializeObject(context.Arguments["createCharacter"]));
                        var modelToCreate = await createMapper.MapTo(createCharacter).ConfigureAwait(false);
                        var createdEntity = await characterCRUDService.Create(modelToCreate).ConfigureAwait(false);
                        return createdEntity;
                    });
                }
            );
            Field<CharacterSummaryType>(
                "updateCharacter",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UpdateCharacterType>> { Name = "updateCharacter" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var updateCharacter = JsonConvert.DeserializeObject<UpdateCharacter>(JsonConvert.SerializeObject(context.Arguments["updateCharacter"]));
                        var modelToUpdate = await updateMapper.MapTo(updateCharacter).ConfigureAwait(false);
                        var updatedCharacter = await characterCRUDService.Update(modelToUpdate).ConfigureAwait(false);
                        return updatedCharacter;
                    });
                }
            );
            Field<BooleanGraphType>(
                "deleteCharacter",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var id = context.GetArgument<int>("id");
                        await characterCRUDService.Delete(id);
                        return true;
                    });
                }
            );

            Field<CharacterSummaryType>(
                "updateCharacterProperty",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }, new QueryArgument<NonNullGraphType<InputMapType<StringGraphType>>> { Name = "update" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var id = context.GetArgument<int>("id");
                        var update = context.GetArgument<Dictionary<string, object>>("update");
                        var character = await characterCRUDService.Read(id).ConfigureAwait(false);
                        var morphedCharacter =  await characterPolymorphService.UpdatePropertyByName(character, update["key"] as string, update["value"]).ConfigureAwait(false);
                        var updatedCharacter = await characterCRUDService.Update(morphedCharacter).ConfigureAwait(false);
                        return updatedCharacter;
                    });
                }
            );
            Field<CharacterSummaryType>(
                "updateCharacterStat",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }, new QueryArgument<NonNullGraphType<InputMapType<StringGraphType>>> { Name = "update" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var id = context.GetArgument<int>("id");
                        var update = context.GetArgument<Dictionary<string, object>>("update");
                        var character = await characterCRUDService.Read(id).ConfigureAwait(false);
                        var morphedCharacter = await characterPolymorphService.UpdateStatByName(character, update["key"] as string, update["value"]).ConfigureAwait(false);
                        var updatedCharacter = await characterCRUDService.Update(morphedCharacter).ConfigureAwait(false);
                        return updatedCharacter;
                    });
                }
            );

            Field<CharacterSummaryType>(
                "updateCharacterMetaData",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }, new QueryArgument<NonNullGraphType<InputMapType<StringGraphType>>> { Name = "update" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var id = context.GetArgument<int>("id");
                        var update = context.GetArgument<Dictionary<string, object>>("update");
                        var character = await characterCRUDService.Read(id).ConfigureAwait(false);
                        var morphedCharacter = await characterPolymorphService.UpdateMetaData(character, update["key"] as string, update["value"] as string).ConfigureAwait(false);
                        var updatedCharacter = await characterCRUDService.Update(morphedCharacter).ConfigureAwait(false);
                        return updatedCharacter;
                    });
                }
            );

            Field<RuleSetInfoType>(
                "createRuleSetInfo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateRuleSetInfoType>> { Name = "createRuleSetInfo" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var ruleSetInfo = context.GetArgument<RuleSetInfo>("createRuleSetInfo");
                        var updatedRuleSetInfo = await ruleSetInfoCRUDService.Create(ruleSetInfo);
                        return updatedRuleSetInfo;
                    });
                }
            );
            Field<RuleSetInfoType>(
                "updateRuleSetInfo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UpdateRuleSetInfoType>> { Name = "updateRuleSetInfo" }),
                resolve: context =>
                {
                    return Task.Run(async () =>
                    {
                        var ruleSetInfo = context.GetArgument<RuleSetInfo>("updateRuleSetInfo");
                        var updatedRuleSetInfo = await ruleSetInfoCRUDService.Update(ruleSetInfo);
                        return updatedRuleSetInfo;
                    });
                }
            );
            Field<BooleanGraphType>(
                "deleteRuleSetInfo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve : context =>
                {
                    return Task.Run(async () =>
                    {
                        var id = context.GetArgument<int>("id");
                        await ruleSetInfoCRUDService.Delete(id);
                        return true;
                    });
                }
            );
        }
    }
}
