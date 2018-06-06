using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Http;
using GraphQL.Relay.Types;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types.Relay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Characters.Services.Builders;
using PPG.CharacterSheets.Characters.Services.Mappers;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL;
using PPG.CharacterSheets.Store;

namespace PPG.CharacterSheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Set DB Contexts
            services.AddDbContext<MigrationContext>();

            services.AddSingleton<CharactersSchema>();

            // Graph QL - Relay
            services.AddTransient(typeof(ConnectionType<>));
            services.AddTransient(typeof(EdgeType<>));
            services.AddTransient<NodeInterface>();
            services.AddTransient<PageInfoType>();

            // General Services
            services.AddScoped(typeof(Context<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICRUDService<,>), typeof(CRUDService<,>));
            services.AddScoped(typeof(ICRUDService<>), typeof(PassThroughCRUDService<>));

            // Mappers
            services.AddScoped(typeof(IMapper<>), typeof(PassThroughMapper<>));
            services.AddScoped<IMapper<Character, CharacterSummary>, CharacterSummaryToCharacterMapper>();
            services.AddScoped<IMapper<CharacterSummary, CreateCharacter>, CreateCharacterToCharacterSummaryMapper>();
            services.AddScoped<IMapper<CharacterSummary, UpdateCharacter>, UpdateCharacterToCharacterSummaryMapper>();

            // GraphQL
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            // Factories
            services.AddScoped<IStatBuilderFactory, StatBuilderFactory>();
            services.AddScoped<IMetaDataBuilderFactory, MetaDataBuilderFactory>();
            services.AddScoped<ICreateCharacterInfoBuilderFactory, CreateCharacterInfoBuilderFactory>();
                        
            var builder = new ContainerBuilder();
            builder.Populate(services);
            
            // Builders - Autofac because .Keyed<>()
            builder.RegisterType<_RuleSets.MalifaxTtB.Builders.StatBuilder>().Keyed<IStatBuilder>(RuleSet.MalifauxTTB);
            builder.RegisterType<_RuleSets.MalifaxTtB.Builders.MetaDataBuilder>().Keyed<IMetaDataBuilder>(RuleSet.MalifauxTTB);
            builder.RegisterType<_RuleSets.MalifaxTtB.Builders.CreateCharacterInfoBuilder>().Keyed<ICreateCharacterInfoBuilder>(RuleSet.MalifauxTTB);

            builder.RegisterType<_RuleSets.DungeonsAndDragons.Builders.StatBuilder>().Keyed<IStatBuilder>(RuleSet.DungeonsandDragons);
            builder.RegisterType<_RuleSets.DungeonsAndDragons.Builders.MetaDataBuilder>().Keyed<IMetaDataBuilder>(RuleSet.DungeonsandDragons);

            return new AutofacServiceProvider(builder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            app.UseGraphQLHttp<CharactersSchema>(new GraphQLHttpOptions());
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
