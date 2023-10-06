using Entities.Models.Products;
using Front_Proyect_Jucar.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Sales
{
    public class OrderDetailViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderDetailID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el producto solicitado!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Producto")]
        public string? Product { get; set; }

        [Required(ErrorMessage = "¡Ingrese la cantidad solicitada!")]
        [MaxLength(5)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Cantidad")]
        public string? Quantity { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public OrderDetailViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //Autopart

        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }

        //OrderDetail

        public Guid OrderId { get; set; }
        public OrderViewModel? Order { get; set; }
    }
}
