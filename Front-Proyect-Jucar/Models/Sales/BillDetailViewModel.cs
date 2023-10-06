using Entities.Models.Products;
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
    public class BillDetailViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BillDetailID { get; set; }

        [Required(ErrorMessage = "¡Ingresa el número del item!")]
        [MaxLength(2)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Item")]
        public string? ItemNumber { get; set; }

        [Required(ErrorMessage = "¡Ingresa la cantidad del item!")]
        [MaxLength(5)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Cantidad")]
        public string? Quantity { get; set; }

        [Required(ErrorMessage = "¡Ingresa el valor unitario del item!")]
        [MaxLength(10)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Valor Unitario")]
        public double UnitValue { get; set; }

        [Required(ErrorMessage = "¡Ingresa la tarifa de IVA!")]
        [MaxLength(2)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Tarifa IVA")]
        public double IVA { get; set; }

        [Required(ErrorMessage = "¡Ingresa el valor subtotal!")]
        [MaxLength(10)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Subtotal")]
        public double SubtotalValue { get; set; }

        [Required(ErrorMessage = "¡Ingresa el valor total!")]
        [MaxLength(10)]
        [RegularExpression("^\\d+$")]
        [DisplayName("Total")]
        public double TotalValue { get; set; }
        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public BillDetailViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //Autopart
        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }

        //Bill

        public Guid BillId { get; set; }
        public BillViewModel? Bill { get; set; }
    }
}
