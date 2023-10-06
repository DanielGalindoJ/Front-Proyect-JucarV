using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Sales
{
    public class LegalCustomerViewModel : CustomerViewModel
    {
        [Required(ErrorMessage = "¡Ingresa la razón social!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Razón Social")]
        public string? BusinessName { get; set; }

        [Required(ErrorMessage = "¡Ingresa el NIT!")]
        [MaxLength(9)]
        [RegularExpression("^[0-9]{1,9}$")]
        [DisplayName("NIT")]
        public string? NIT { get; set; }
    }
}
