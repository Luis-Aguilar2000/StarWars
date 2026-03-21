using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using Microsoft.Extensions.Hosting;
using StarWars.Data;
=======
using StarWars.Data;
using RestLibrary.Interfaces;
using RestLibrary.Services;
using Microsoft.EntityFrameworkCore;
>>>>>>> 262c276b4f196c76bc000a93811b6d09b5424bc4

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
                        opt.UseSqlServer("Server=AGUILAR;Database=MNT_USERS;Trusted_Connection=true;MultipleActiveResultsets=true;TrustServerCertificate=true")
                    );


                    services.AddTransient<Form1>();
                })
                .Build();

            var mainform = AppHost.Services.GetRequiredService<Form1>();
            Application.Run(mainform);
        }
    }
}