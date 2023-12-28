
using Locato.Data.EntityFramework.Seed;
using Locato.Data.EntityFramework;
using Locato.Web;
using Microsoft.EntityFrameworkCore;
using Shared.helpers;

namespace Locato.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var switchMappings = new Dictionary<string, string>()
            {
               { "--api", "Args:EnableApi" },
               { "--worker", "Args:EnableWorker" },
               { "--createdb", "Args:CreateDb" },
               { "--deletedb", "Args:DeleteDb" },
               { "--seeddb", "Args:SeedDb" },
            };
            // Add services to the container.




            var app = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((host, config) =>
            {
                config.AddCommandLine(args, switchMappings);

            }).ConfigureWebHostDefaults((webbuilder) =>
            {
                webbuilder.UseStartup<Startup>();
            }).Build();

            var config = app.Services.GetService<ConfigurationArgs>();

            CancellationToken cancellationToken = default;

            System.Console.WriteLine(config.EnableApi);

            if (config.DeleteDb)
            {
                await DeleteDatabase(app, cancellationToken);
            }
            if (config.CreateDb)
            {
                await CreateDatabase(app, cancellationToken);
            }
            if (config.SeedDb)
            {
                await SeedDatabase(app, cancellationToken);
            }
            await app.RunAsync(cancellationToken);
        }

        private static async Task DeleteDatabase(IHost app, CancellationToken cancellationToken)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<IApplicationDbContext>();

                await (context as DbContext).Database.EnsureDeletedAsync(cancellationToken);
            }
        }

        private async static Task CreateDatabase(IHost app, CancellationToken cancellationToken)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<IApplicationDbContext>();

                await (context as DbContext).Database.EnsureCreatedAsync(cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }
        }
        private async static Task SeedDatabase(IHost app, CancellationToken cancellationToken)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetService<IApplicationDbContextSeed>()!;
                await seeder.Seed(cancellationToken);
            }
        }
    }
}
