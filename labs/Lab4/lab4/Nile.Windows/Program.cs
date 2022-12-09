/*
 * ITSE 1430
 */
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nile.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder().Build();
            s_configuration = host.Services.GetRequiredService<IConfiguration>();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        /// <summary>Gets a connection string given its name.</summary>
        /// <param name="connectionStringName">The connection string name.</param>
        /// <returns>The connection string.</returns>
        /// <exception cref="Exception">Connection string not found.</exception>
        public static string GetConnectionString ( string connectionStringName )
        {
            var connString = s_configuration.GetConnectionString(connectionStringName);
            if (!String.IsNullOrEmpty(connString))
                return connString;

            throw new Exception($"Connection string '{connectionStringName}' not found. Ensure you are using the correct name and appsettings.json is available.");
        }

        private static IConfiguration s_configuration;
    }
}
