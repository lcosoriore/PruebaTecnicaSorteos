using System.ComponentModel.DataAnnotations;

namespace Sorteo.Domain.Models
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        [Required(ErrorMessage = "El ClienteId es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ClienteId debe ser mayor que cero.")]
        public int ClienteId { get; set; }
    }
}
