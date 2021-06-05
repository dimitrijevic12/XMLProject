using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Services;
using PostMicroservice.DataAccess.Implementation;
using System.Text;

namespace PostMicroservice.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "core_ms-sql-server_1";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "1Secure*Password1";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PostMicroservice.Api", Version = "v1" });
            });

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IHashTagRepository, HashTagRepository>();
            services.AddScoped<PostService>();
            services.AddScoped<HashTagFactory>();
            services.AddScoped<LocationFactory>();
            services.AddScoped<PostSingleFactory>();
            services.AddScoped<PostAlbumFactory>();
            services.AddScoped<RegisteredUserFactory>();
            services.AddScoped<CommentFactory>();
            services.AddScoped<HashTagFactory>();
            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<LocationService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<CollectionFactory>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = Configuration["Jwt:Issuer"],
                  ValidAudience = Configuration["Jwt:Issuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
              };
          });
            services.AddControllersWithViews()
             .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PostMicroservice.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}