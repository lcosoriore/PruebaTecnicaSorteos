using System.ComponentModel.DataAnnotations;

namespace Sorteo.Front.Data
{
    public class ProductModel
    {
        public int Id { get; set; }       
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
