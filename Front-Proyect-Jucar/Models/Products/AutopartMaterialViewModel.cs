using Front_Proyect_Jucar.Models.Products;
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
    public class AutopartMaterialViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AutopartMaterialID { get; set; }

        [Required]
        [DisplayName("Creación del Regístro")]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayName("Modificación del Regístro")]
        public DateTime ModificationDate { get; set; }

        //Constructor 

        public AutopartMaterialViewModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        //Relaciones con otros modelos 

        //Autopart 

        public Guid AutopartId { get; set; }
        public AutopartViewModel? Autopart { get; set; }

        //RawMaterial

        public Guid RawMaterialId { get; set; }
        public RawMaterialViewModel? RawMaterial { get; set; }
    }
}
