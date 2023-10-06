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
    public class LossViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LossID { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad perdida!")]
        [MaxLength(5)]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Cantidad Perdida")]
        public string? AmountLoss { get; set; }

        [Required(ErrorMessage = "¡Ingrese el responsable!")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        [DisplayName("Responsable")]
        public string? Responsible { get; set; }

        [Required(ErrorMessage = "¡Ingrese el lugar de la perdida!")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        [DisplayName("Lugar")]
        public string? Place { get; set; }

        [Required(ErrorMessage = "¡Ingrese el motivo de perdida!")]
        [MaxLength(150)]
        [RegularExpression("^[a-zA-Z]+$")]
        [DisplayName("Motivo")]
        public string? Reason { get; set; }

        [Required(ErrorMessage = "¡Ingrese la fecha de la perdida!")]
        [DisplayName("Fecha de Perdida")]
        public DateTime LossDate { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public LossViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }
    }
}
