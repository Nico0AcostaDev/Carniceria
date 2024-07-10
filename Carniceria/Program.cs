using Carniceria.Models;

namespace Carniceria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CarniceriaContext dbContext = CarniceriaContext.CreateDbContext();


            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(dbContext));
        }
    }
}