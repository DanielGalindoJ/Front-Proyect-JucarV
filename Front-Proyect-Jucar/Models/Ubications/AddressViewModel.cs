using Entities.Models.Factories;
using Entities.Models.Providers;
using Entities.Models.Sales;
using Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Ubications
{
    public class AddressViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressID { get; set; }

        [MaxLength(200)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Información Adicional")]
        public string? AditionalInformation { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor

        public AddressViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos 

        //FactoryAddress

        public ICollection<FactoryAddressViewModel> FactoryAddresses { get; set; }

        //CustomerAddress

        public ICollection<CustomerAddressViewModel> CustomerAddresses { get; set; }

        //UserAddress

        public ICollection<UserAddressViewModel> UserAddresses { get; set; }

        //ProviderAddress

        public ICollection<ProviderAddressViewModel> ProviderAddresses { get; set; }

        //Street

        public Guid StreetId { get; set; }
        public StreetViewModel? Street { get; set; }

        //Addressee

        public Guid AddresseeId { get; set; }
        public AddresseeViewModel? Addressee { get; set; }

        //Building

        public Guid BuildingId { get; set; }
        public BuildingViewModel? Building { get; set; }

        //AddressType

        public Guid AddressTypeId { get; set; }
        public AddressTypeViewModel? AddressType { get; set; }
    }
}
