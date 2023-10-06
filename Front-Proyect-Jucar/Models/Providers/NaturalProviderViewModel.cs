using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Providers
{
    public class NaturalProviderViewModel : ProviderViewModel
    {
        [Required(ErrorMessage = "¡Escoga el tipo de documento!")]
        [DisplayName("Tipo de Documento")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "¡Ingrese el número de documento!")]
        [MaxLength(10)]
        [RegularExpression("^\\d{1,10}$")]
        [DisplayName("Numero de Documento")]
        public string? DocumentNumber { get; set; }

        [Required(ErrorMessage = "¡Ingrese el primer nombre!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Primer Nombre")]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Segundo Nombre")]
        public string? SecondName { get; set; }

        [Required(ErrorMessage = "¡Ingrese el primer apellido!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Primer Apellido")]
        public string? FirstSurname { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[A-Za-z\\s]+$")]
        [DisplayName("Segundo Apellido")]
        public string? SecondSurname { get; set; }
    }
}
