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
            ApplicationConfiguration.Initialize();

            string filePath = Properties.Settings.Default.JsonConfigPath;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                using OpenFileDialog dialog = new OpenFileDialog
                {
                    Title = "Seleccionar appsettings.json",
                    Filter = "JSON files (*.json)|*.json",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Debe seleccionar el archivo de configuración.");
                    return;
                }

                filePath = dialog.FileName;

                Properties.Settings.Default.JsonConfigPath = filePath;
                Properties.Settings.Default.Save();
            }

            var json = File.ReadAllText(filePath);

            var config = JsonSerializer.Deserialize<jsonFile>(json);

            if (config == null || string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                MessageBox.Show("Configuración inválida.");
                return;
            }

            var dbContext = CarniceriaContext.CreateDbContext(config.ConnectionString);
            Application.Run(new MainForm(dbContext));

        }
    }
}