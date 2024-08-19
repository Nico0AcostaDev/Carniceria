using Carniceria.Dto;
using Carniceria.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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