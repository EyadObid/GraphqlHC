using GrpahqlHC.Models;
using GrpahqlHC.Mutations;
using GrpahqlHC.Queries;
using GrpahqlHC.Subscriptions;
using GrpahqlHC.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution.Configuration;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace GrpahqlHC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PlanningDbContext>(options =>
             options.UseInMemoryDatabase(databaseName: "Planning")
                    .EnableSensitiveDataLogging());

            services.AddGraphQL(SchemaBuilder.New()
                .AddQueryType<PlanningQueries>()
                .AddMutationType<PlanningMutations>()
                .AddSubscriptionType<PlanningSubscription>()
                .AddType<ProjectType>()
                .Create(),
                new QueryExecutionOptions
                {
                    ForceSerialExecution = true,
                    IncludeExceptionDetails = true
                });

            //services.AddInMemorySubscriptionProvider();

            var configuration = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                DefaultDatabase = 2
            };

            configuration.EndPoints.Add("xxxxxx.com.au:6379");

            services.AddRedisSubscriptions(configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PlanningDbContext dbContext)
        {
            SeedDatabase(dbContext);

            app.UseWebSockets();
            app.UseGraphQL("/graphql");
            app.UsePlayground("/graphql", "/ui/playground");
            app.UseVoyager("/graphql", "/ui/voyager");
        }

        private void SeedDatabase(PlanningDbContext dbContext)
        {
            dbContext.Projects.AddRange(new[]
            {
                new Project { Id = 1, Name = "Project1" },
                new Project { Id = 2, Name = "Project2" },
                new Project { Id = 3, Name = "Project3" }
            });

            dbContext.Lots.AddRange(new[]
            {
                new Lot { Id = 1, Number = 1, Address = "Address1", ProjectId = 1 },
                new Lot { Id = 2, Number = 2, Address = "Address2", ProjectId = 1 },
                new Lot { Id = 3, Number = 3, Address = "Address3", ProjectId = 2 },
                new Lot { Id = 4, Number = 4, Address = "Address4", ProjectId = 2 },
                new Lot { Id = 5, Number = 5, Address = "Address5", ProjectId = 3 }
            });

            dbContext.Notes.AddRange(new[]
            {
                new Note { Id = 1, Comment = "Note1", LotId = 1 },
                new Note { Id = 2, Comment = "Note2", LotId = 1 },
                new Note { Id = 3, Comment = "Note3", LotId = 2 },
                new Note { Id = 4, Comment = "Note4", LotId = 3 },
                new Note { Id = 5, Comment = "Note5", LotId = 4 }
            });

            dbContext.SaveChanges();
        }
    }
}
