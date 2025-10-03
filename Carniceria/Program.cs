using Carniceria.Dto;
using Carniceria.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Carniceria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "";
            var prueba = @"C:\Users\Nico\Documents\GitHub\Carniceria\appsettings.json";

            using (StreamReader r = new StreamReader(prueba))
            {
                string json = r.ReadToEnd();
                var desc = JsonSerializer.Deserialize<jsonFile>(json);
                connectionString = desc.ConnectionString;
            }

            // Crear opciones para DbContext
            var options = new DbContextOptionsBuilder<CarniceriaContext>()
                .UseSqlite(connectionString)
                .Options;

            var dbContext = new CarniceriaContext(options);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(dbContext));
        } 
    }
}