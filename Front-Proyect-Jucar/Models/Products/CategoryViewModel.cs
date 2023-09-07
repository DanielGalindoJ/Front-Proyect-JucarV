using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_Proyect_Jucar.Models.Products
{
    public class CategoryViewModel
    {
        public Guid CategoryID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el nombre de la categoría!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Nombre")]
        public string? Name { get; set; }

        [Required]
        [DisplayName("Estado")]
        public bool State { get; set; }

        [Required]
        [DisplayName("Creación del Registro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Registro")]
        public DateTime ModificationDate { get; set; }
    }
}
