using Shared.helpers;
using Locato.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Interfaces;
using Services.Implementations;
using Microsoft.OpenApi.Models;
using InfraStructure.Services.Interfaces;
using Locato.Infrastructure.Services.Implementations;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Locato.Data.EntityFramework.Seed;
using Swashbuckle.AspNetCore.Swagger;

namespace Locato.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Args = new ConfigurationArgs();
            var argsSection = Configuration.GetSection("Args");
            argsSection.Bind(Args);
        }

        public IConfiguration Configuration
        {
            get;
        }
        public ConfigurationArgs Args
        {
            get;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            appSettingsSection.Bind(appSettings);
            services.AddScoped<IIdGenerator<long>, IdGenerator>();
            services.AddSingleton(appSettings);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Args);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "locato API",
                    Version = "v1"
                });

            });

            services.AddSingleton<IJwtHandler, JwtHandler>();
            var connectionString = Configuration.GetConnectionString("Locato");
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(connectionString)
                  .UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IApplicationDbContextSeed, ApplicationDbContextSeed>();
            services.AddMvcCore()
                    .AddApiExplorer();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IApplicationDbContext>(pr => pr.GetService<ApplicationDbContext>()!);
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                var key = appSettings.Secret;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = t    rue,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))

                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = exception => {
                        if (exception.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            exception.Response.Headers.Add("Token-Expired", "true");
                        }

                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context => {
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Args.EnableApi)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();

                app.UseCors("AllowCors");
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });

            }
        }
    }

}