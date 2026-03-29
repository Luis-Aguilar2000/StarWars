using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWars.Data;
using RestLibrary.Interfaces;
using RestLibrary.Services;
using Microsoft.EntityFrameworkCore;
using PersistenceLibrary.Interfaces;
using PersistenceLibrary.Repositories;

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
                    services.AddTransient<IRestApi, RestApiService>();
                    services.AddHttpClient();

                    services.AddDbContext<ApplicationDbContext>(opt =>
                    opt.UseSqlServer("Server=HM-2518;Database=StarWars;Trusted_Connection=true;MultipleActiveResultsets=true;TrustServerCertificate=true")
                    );
                    services.AddScoped<DbContext, ApplicationDbContext>();
                    services.AddScoped<IRepository, Repository>();

                    services.AddTransient<Form1>();
                })
                .Build();

            var mainform = AppHost.Services.GetRequiredService<Form1>();
            Application.Run(mainform);
        }
    }
}