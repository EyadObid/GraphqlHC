using GrpahqlHC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<PlanningContext>(options =>
             options.UseInMemoryDatabase(databaseName: "Planning")
                    .EnableSensitiveDataLogging());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PlanningContext dbContext)
        {
            SeedDatabase(dbContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(Configuration["Logging:LogLevel:Microsoft"]);
                });
            });
        }

        private void SeedDatabase(PlanningContext dbContext)
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
