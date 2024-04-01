using System.ComponentModel.DataAnnotations;

namespace Sorteo.Domain.Models
{
    /// <summary>
    /// Representa un producto en el sistema de sorteos.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Obtiene o establece el identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del producto debe tener entre 3 y 50 caracteres.")]
        [NoStringKeyword(ErrorMessage = "El nombre del producto no puede contener la palabra 'string'.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La descripción del producto no puede tener más de 100 caracteres.")]
        [NoStringKeyword(ErrorMessage = "La descripción del producto no puede contener la palabra 'string'.")]
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// Atributo de validación personalizado que valida si una cadena contiene la palabra 'string'.
    /// </summary>
    public class NoStringKeywordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.ToString().ToLower().Contains("string"))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
