using Entities.Models.Products;
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
    public class ShelvingViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShelvingID { get; set; }

        [Required(ErrorMessage = "¡Ingresa el número de la estanteria!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Número de Estanteria")]
        public string? ShelvingNumber { get; set; }

        [Required(ErrorMessage = "¡Ingrese el tipo de producto!")]
        [MaxLength(20)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Tipo de Producto")]
        public string? ProductType { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public ShelvingViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //Inventory 

        public Guid InventoryId { get; set; }
        public InventoryViewModel? Inventory { get; set; }

        //Shelf

        public Guid ShelfId { get; set; }
        public ShelfViewModel? Shelf { get; set; }

    }
}
