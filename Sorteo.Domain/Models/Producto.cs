using System.ComponentModel.DataAnnotations;

namespace Sorteo.Domain.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del producto debe tener entre 3 y 50 caracteres.")]
        [NoStringKeyword(ErrorMessage = "El nombre del producto no puede contener la palabra 'string'.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La descripción del producto no puede tener más de 100 caracteres.")]
        [NoStringKeyword(ErrorMessage = "La descripción del producto no puede contener la palabra 'string'.")]
        public string Descripcion { get; set; }
    }
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
