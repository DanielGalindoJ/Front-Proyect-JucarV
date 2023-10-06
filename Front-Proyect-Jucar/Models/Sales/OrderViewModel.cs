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
    public class OrderViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el lugar del pedido!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Lugar")]
        public string? Place { get; set; }

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

        public OrderViewModel()
        {
            State = true;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //Customer

        public Guid CustomerId { get; set; }
        public CustomerViewModel? Customer { get; set; }

        //OrderDetail

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }

        //Contribution

        public ICollection<ContributionViewModel> Contributions { get; set; }

        //Bill

        public BillViewModel? Bill { get; set; }
    }
}
