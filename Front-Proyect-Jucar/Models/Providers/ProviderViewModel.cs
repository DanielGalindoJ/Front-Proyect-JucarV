using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Providers
{
    public class ProviderViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProviderID { get; set; }

        [Required(ErrorMessage = "¡Ingrese un correo electrónico!")]
        [EmailAddress(ErrorMessage = "¡Ingrese una cuenta de correo electrónico válida!")]
        [DisplayName("Correo Electrónicos")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "¡Ingrese el tipo de producto!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Tipo de Producto")]
        public string? ProductType { get; set; }

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

        public ProviderViewModel()
        {
            State = true;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos 

        //ProviderAddress

        public ICollection<ProviderAddressViewModel> ProviderAddresses { get; set; }

        //ProviderPhone

        public ICollection<ProviderPhoneViewModel> ProviderPhones { get; set; }
    }
}
