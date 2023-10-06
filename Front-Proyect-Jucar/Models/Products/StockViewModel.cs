using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Products
{
    public class StockViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StockID { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad disponible!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "¡Ingrese una cantidad disponible válida!")]
        [DisplayName("Cantidad Disponible")]
        public string? QuantityAvailable { get; set; }

        [Required(ErrorMessage = "¡Ingresa las existencias iniciales!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "¡Ingrese existencias iniciales válidas!")]
        [DisplayName("Existencias Iniciales")]
        public string? InitialStock { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad de punto de reorden!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "¡Ingrese un punto de reorden válido!")]
        [DisplayName("Punto de Reorden")]
        public string? ReorderPoint { get; set; }

        [Required(ErrorMessage = "¡Ingrese el inventario minimo!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "¡Ingrese un inventario mínimo válido!")]
        [DisplayName("Inventario Minimo")]
        public string? MinimumInventory { get; set; }

        [Required(ErrorMessage = "¡Ingrese el inventario máximo!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "¡Ingrese un inventario máximo válido!")]
        [DisplayName("Inventario Máximo")]
        public string? MaximumInventory { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor 

        public StockViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        public Guid RawMaterialId { get; set; }
        public RawMaterialViewModel? RawMaterial { get; set; }
    }
}
