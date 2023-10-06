using Entities.Models.Sales;
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
    public class UserViewModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "¡Ingrese el tipo de documento!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Tipo Documento")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "¡Ingrese el número de documento!")]
        [MaxLength(10)]
        [RegularExpression("^\\d{1,10}$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Documento")]
        public string? DocumentNumber { get; set; }

        [Required(ErrorMessage = "¡Ingrese el primer nombre!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Primer Nombre")]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Segundo Nombre")]
        public string? SecondName { get; set; }

        [Required(ErrorMessage = "¡Ingrese el primer apellido!")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Primer Apellido")]
        public string? FirstSurname { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("SegundoApellido")]
        public string? SecondSurname { get; set; }

        [Required(ErrorMessage = "¡Escoga una de las opciones!")]
        [MaxLength(10)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Sexo")]
        public string? Sex { get; set; }

        [Required(ErrorMessage = "¡Seleccione su fecha de cumpleaños!")]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "¡Ingrese el lugar de nacimiento!")]
        [MaxLength(100)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Lugar de Nacimiento")]
        public string? BirthCity { get; set; }

        [Required(ErrorMessage = "¡Ingrese la ciudad de residencia!")]
        [MaxLength(100)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ\\s]+$", ErrorMessage = "¡El campo no permite números (9), símbolos (+) o cáracteres especiales (@)!")]
        [DisplayName("Ciudad de Residencia")]
        public string? CityResidence { get; set; }

        [Required]
        [DisplayName("Estado")]
        public bool State { get; set; }

        [Required]
        [DisplayName("Creación de Registro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación de Registro")]
        public DateTime ModificationDate { get; set; }

        //Constructor
        public UserViewModel()
        {
            State = true;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos

        //UserPhone

        public ICollection<UserPhoneViewModel> UserPhones { get; set; }

        //UserPosition

        public ICollection<UserPositionViewModel> UserPositions { get; set; }

        //UserAddress

        public ICollection<UserAddressViewModel> UserAddresses { get; set; }

        //Bill 

        public ICollection<BillViewModel> Bills { get; set; }
    }
}
