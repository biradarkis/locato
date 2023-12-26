using Shared.helpers;
using Microsoft.Extensions.DependencyInjection;
using Locato.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Locato.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
          Configuration =configuration;
          var args  = new ConfigurationArgs();
          var argsSection = Configuration.GetSection("Args");
          argsSection.Bind(args);
        }

        public IConfiguration Configuration { get; }
        public ConfigurationArgs Args { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            appSettingsSection.Bind(appSettings);
            services.AddSingleton(appSettings);
            services.AddSingleton(Args);
            var connectionString = Configuration.GetConnectionString("Locato");
            services.AddDbContext <ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IApplicationContext>(pr => pr.GetService<ApplicationContext>()!);
        }
    }


}
