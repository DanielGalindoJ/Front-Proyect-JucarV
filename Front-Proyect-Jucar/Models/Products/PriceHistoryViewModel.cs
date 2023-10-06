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
    public class PriceHistoryViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PriceHistoryID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el valor de la autoparte!")]
        [RegularExpression("^[0-9]+$")]
        [DisplayName("Valor")]
        public double Value { get; set; }

        [Required]
        [DisplayName("Estado")]
        public bool State { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public PriceHistoryViewModel()
        {
            State = true;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos 

        //Autopart 

        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }

        //DiscountHistory

        public ICollection<DiscountHistoryViewModel>? DiscountHistories { get; set; }
    }
}
