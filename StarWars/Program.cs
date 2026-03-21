using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWars.Data;

namespace StarWars
{
    internal static class Program
    {
        public static IHost? AppHost { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient();
                    services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer("Server=HM-2518;Database=HM202401;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;"))
                    services.AddTransient<Form1>();
                })
                .Build();

            var mainform = AppHost.Services.GetRequiredService<Form1>();
            Application.Run(mainform);
        }
    }
}