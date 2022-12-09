/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
 * 12/1/2022
 */

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
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}