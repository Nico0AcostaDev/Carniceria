using Carniceria.Dto;
using Carniceria.Models;
using System.Text.Json;

namespace Carniceria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "";
            var prueba = @"C:\Users\vamoooooo\Desktop\Carniceria\appsettings.json";

            using (StreamReader r = new StreamReader(prueba))
            {
                    string json = r.ReadToEnd();
                    var desc = JsonSerializer.Deserialize<jsonFile>(json);
                    connectionString = desc.ConnectionString;
            } 
            CarniceriaContext dbContext = CarniceriaContext.CreateDbContext(connectionString);

            ApplicationConfiguration.Initialize(); 
            Application.Run(new MainForm(dbContext));
        } 
    }
}