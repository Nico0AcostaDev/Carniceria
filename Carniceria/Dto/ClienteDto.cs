 
namespace Carniceria.Dto
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string InfoRelevante { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

}
