using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.Core.Services;
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

            var builder = new ContainerBuilder();
            builder.Populate(services);
            // Register Services

            builder.RegisterGeneric(typeof(Context<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(CRUDService<,>)).As(typeof(ICRUDService<,>));

            // Mappers
            builder.RegisterType<CreateCharacterMapper>().As<IMapper<CharacterSummary, CreateCharacter>>();
            builder.RegisterType<CharacterModelToEntityMapper>().As<IMapper<Character, CharacterSummary>>();

            // Builders
            builder.RegisterType<_RuleSets.MalifaxTtB.StatBuilder>().Keyed<IStatBuilder>(RuleSet.MalifauxTtB);
            builder.RegisterType<_RuleSets.MalifaxTtB.MetaDataBuilder>().Keyed<IMetaDataBuilder>(RuleSet.MalifauxTtB);

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
        }
    }
}
