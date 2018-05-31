using GraphQL.Types;
using Newtonsoft.Json;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.InputTypes;
using PPG.CharacterSheets.GraphQL.Types;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.GraphQL
{
    public class CharactersMutation : ObjectGraphType<CharacterSummary>
    {
        public CharactersMutation(
            ICRUDService<Character, CharacterSummary> crudService,
            IMapper<CharacterSummary, CreateCharacter> createMapper,
            IMapper<CharacterSummary, UpdateCharacter> updateMapper
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
                        var createdEntity = await crudService.Create(modelToCreate).ConfigureAwait(false);
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
                        var updatedCharacter = await crudService.Update(modelToUpdate).ConfigureAwait(false);
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
                        await crudService.Delete(id);
                        return true;
                    });
                }
            );
        }
    }
}
