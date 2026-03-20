using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace StarWars
{
    internal static class Program
    {
        public static IHost? AppHost { get; private set; } 
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(context, Services =>
            {

                Services.AddHttpClient();
                Services.Addtransient<Form1>();

            })
                .Build();

            var mainform = AppHost.Services.GetRequiredService<Form1>();
            Application.Run(new Form1());
        }
    }
}