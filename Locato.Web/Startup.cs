using Shared.helpers;
using Microsoft.Extensions.DependencyInjection;
using Locato.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Locato.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
          Configuration =configuration;
          Args  = new ConfigurationArgs();
          var argsSection = Configuration.GetSection("Args");
          argsSection.Bind(Args);
        }

        public IConfiguration Configuration { get; }
        public ConfigurationArgs Args { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            appSettingsSection.Bind(appSettings);
            services.AddScoped<IIdGenerator<long>, IdGenerator>();
            services.AddSingleton(appSettings);
            services.TryAddSingleton<IHttpContextAccessor , HttpContextAccessor>();
            services.AddSingleton(Args);
            var connectionString = Configuration.GetConnectionString("Locato");
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
            });
            services.AddScoped<ICurrentUserService, CurrentUserServices>();
            
            services.AddScoped<IApplicationContext>(pr => pr.GetService<ApplicationContext>()!);
        }

        public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
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
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            }
        }
    }


}
