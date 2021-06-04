using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StoryMicroservice.DataAccess.Implementation;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Services;
using StoryMicroservice.DataAccess.Factories;

namespace StoryMicroservice.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoryMicroservice.Api", Version = "v1" });
            });
            services.AddScoped<UserService>();
            services.AddScoped<StoryService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<RegisteredUserFactory>();
            services.AddScoped<LocationFactory>();
            services.AddScoped<HashTagFactory>();
            services.AddScoped<StoryFactory>();
            services.Configure<StoryDatabaseSettings>(
            Configuration.GetSection(nameof(StoryDatabaseSettings)));

            services.AddSingleton<IStoryDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<StoryDatabaseSettings>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoryMicroservice.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}