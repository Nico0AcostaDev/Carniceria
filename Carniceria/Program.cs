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
            string filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar appsettings.json";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("Necesitas seleccionar un archivo para continuar.");
                    return;
                }
            } 
         
            string connectionString = "";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                var desc = JsonSerializer.Deserialize<jsonFile>(json);
                connectionString = desc.ConnectionString;
            } 
            CarniceriaContext dbContext = CarniceriaContext.CreateDbContext(connectionString); 
            Application.Run(new MainForm(dbContext));
        } 
    }
}