using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Users
{
    public class UserPhoneViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserPhoneID { get; set; }

        [Required(ErrorMessage = "¡Escoga una opción de tipo de teléfono!")]
        [DisplayName("Tipo Teléfono")]
        public string? PhoneType { get; set; }

        [Required(ErrorMessage = "¡Ingrese el número teléfonico!")]
        [DisplayName("Numero Teléfono")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }


        //Constructor

        public UserPhoneViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }


        //Relaciones con otros modelos 

        public Guid UserId { get; set; }
        public UserViewModel? User { get; set; }

    }
}
