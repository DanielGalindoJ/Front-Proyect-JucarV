using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Factories
{
    public class ShelfViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShelfID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el número!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Número de Estante")]
        public string? ShelfNumber { get; set; }

        [Required(ErrorMessage = "¡Ingresa el material!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Material")]
        public string? Material { get; set; }

        [Required(ErrorMessage = "¡Ingresa el color!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Color")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "¡Ingresa la altura!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Altura Cm")]
        public string? HeightCm { get; set; }

        [Required(ErrorMessage = "¡Ingresa el largo!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Largo Cm")]
        public string? LengthCm { get; set; }

        [Required(ErrorMessage = "¡Ingresa la capacidad máxima!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Capacidad Máxima Kgs")]
        public string? MaxCapacityKgs { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public ShelfViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos 

        //Shelving

        public ICollection<ShelvingViewModel> Shelvings { get; set; }

        //Warehouse

        public Guid WarehouseId { get; set; }
        public WarehouseViewModel? Warehouse { get; set; }
    }
}
