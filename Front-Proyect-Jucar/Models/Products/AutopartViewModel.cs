using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Front_Proyect_Jucar.Models.Products
{
    public class AutopartViewModel
    {
        public Guid AutopartID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el nombre de la autoparte!")]
        [MaxLength(50, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[\\w\\s'\"/.\\u00E1-\\u00FA]+$")]
        [DisplayName("Nombre")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "¡Ingrese una descripción para la autoparte!")]
        [MaxLength(200, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$")]
        [DisplayName("Descripción")]
        public string? Description { get; set; }

        [MaxLength(3, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Peso Kgs")]
        public string? WeightKgs { get; set; }

        [MaxLength(3, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Altura Cm")]
        public string? HeightCm { get; set; }

        [MaxLength(3, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Largo Cm")]
        public string? LengthCm { get; set; }

        [Required(ErrorMessage = "¡Ingrese la zona del vehiculo a la que pertenece!")]
        [MaxLength(50, ErrorMessage = "Ha superado el límite de caracteres permitido")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$")]
        [DisplayName("Zona del Vehículo")]
        public string? VehicleZone { get; set; }

        [Required]
        [DisplayName("Estado")]
        public bool State { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }
    }
}
