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
            services.AddDbContext<Context<Character>>();

            services.AddSingleton<CharactersSchema>();

            // Graph QL - Relay
            services.AddTransient(typeof(ConnectionType<>));
            services.AddTransient(typeof(EdgeType<>));
            services.AddTransient<NodeInterface>();
            services.AddTransient<PageInfoType>();
            
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>();
            builder.RegisterType<DocumentWriter>().As<IDocumentWriter>();

            // Register Services
            builder.RegisterGeneric(typeof(Context<>)).AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(CRUDService<,>)).As(typeof(ICRUDService<,>));

            // Mappers
            builder.RegisterType<CharacterSummaryToCharacterMapper>().As<IMapper<Character, CharacterSummary>>();
            builder.RegisterType<CreateCharacterToCharacterSummaryMapper>().As<IMapper<CharacterSummary, CreateCharacter>>();
            builder.RegisterType<UpdateCharacterToCharacterSummaryMapper>().As<IMapper<CharacterSummary, UpdateCharacter>>();

            // Builders
            builder.RegisterType<_RuleSets.MalifaxTtB.StatBuilder>().Keyed<IStatBuilder>(RuleSet.MalifauxTTB);
            builder.RegisterType<_RuleSets.MalifaxTtB.MetaDataBuilder>().Keyed<IMetaDataBuilder>(RuleSet.MalifauxTTB);
            builder.RegisterType<_RuleSets.DungeonsAndDragons.StatBuilder>().Keyed<IStatBuilder>(RuleSet.DungeonsandDragons);
            builder.RegisterType<_RuleSets.DungeonsAndDragons.MetaDataBuilder>().Keyed<IMetaDataBuilder>(RuleSet.DungeonsandDragons);

            // Factories
            builder.RegisterType<StatBuilderFactory>().As<IStatBuilderFactory>();
            builder.RegisterType<MetaDataBuilderFactory>().As<IMetaDataBuilderFactory>();

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
