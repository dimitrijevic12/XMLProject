using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using UserMicroservice.Api.Consumers;
using UserMicroservice.Api.Factories;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Services;
using UserMicroservice.DataAccess.Implementation;

namespace UserMicroservice.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserMicroservice.Api", Version = "v1" });
            });

            var bus = RabbitHutch.CreateBus(Configuration["RabbitMQ:ConnectionString"]);
            services.AddSingleton<IBus>(bus);
            services.AddSingleton<MessageDispatcher>();

            services.AddSingleton<AutoSubscriber>(_ =>
            {
                return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly.GetExecutingAssembly().GetName().Name)
                {
                    AutoSubscriberMessageDispatcher = _.GetRequiredService<MessageDispatcher>()
                };
            });

            services.AddScoped<UserService>();
            services.AddScoped<VerificationRequestService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IVerificationRequestRepository, VerificationRequestRepository>();
            services.AddScoped<RegisterUserFactory>();
            services.AddScoped<RegisteredUserFactory>();
            services.AddScoped<FollowRequestFactory>();
            services.AddScoped<VerificationRequestFactory>();
            services.AddScoped<VerificationRequestViewFactory>();

            services.AddScoped<UnsuccessfulStoryUserRegistrationEventConsumer>();
            services.AddScoped<UserRegistrationCompletedEventConsumer>();

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
            services.AddHostedService<Worker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserMicroservice.Api v1"));
            }

            app.UseStaticFiles();

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