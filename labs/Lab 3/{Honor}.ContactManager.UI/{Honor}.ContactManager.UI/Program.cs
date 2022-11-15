using System.Configuration;

namespace _Honor_.ContactManager.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            //var host = Host.CreateDefaultBuilder().Build();
            //s_configuration = host.Services.GetRequiredService<IConfiguration>();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        /*
        public static string GetConnectionString ( string connectionStringName )
        {
            var connString = s_configuration.GetConnectionString(connectionStringName);
            if (!String.IsNullOrEmpty(connString))
                return connString;

            throw new Exception($"Connection string '{connectionStringName}' not found. Ensure you are using the correct name and appsettings.json is available.");
        }

        private static IConfiguration s_configuration;
        */
    }
}