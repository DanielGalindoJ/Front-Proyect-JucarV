using Entities.Models.Factories;
using Front_Proyect_Jucar.Models.Products;
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
    public class InventoryViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InventoryID { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad disponible del producto!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Cantidad Disponible")]
        public string? QuantityAvailable { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Última Actualización")]
        public DateTime UltimateModificationDate { get; set; }

        //Constructor

        public InventoryViewModel()
        {
            CreationDate = DateTime.Now;
            UltimateModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //Autopart

        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }

        //Shelving

        public ICollection<ShelvingViewModel>? Shelvings { get; set; }
    }
}
