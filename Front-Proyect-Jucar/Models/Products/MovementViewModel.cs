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
    public class MovementViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MovementID { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad del movimiento!")]
        [MaxLength(3)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Cantidad")]
        public string? Quantity { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Tipo de Movimiento")]
        public string? MovementType { get; set; }

        [Required(ErrorMessage = "¡Ingrese la fecha del movimiento!")]
        [DisplayName("Fecha del Movimiento")]
        public DateTime MovementDate { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor 

        public MovementViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        public Guid RawMaterialId { get; set; }
        public RawMaterialViewModel? RawMaterial { get; set; }

    }
}
