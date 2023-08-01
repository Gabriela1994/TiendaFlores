using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMarguerite.Models.ViewModels
{
    public class FloresViewModel
    {

        public int? Id{ get; set; }

        [StringLength(400)]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        [DisplayName("Especie")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public int Id_especie { get; set; }

        [DisplayName("Color")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public int Id_color { get; set; }


        public string? Especie { get; set; }
        public string? Color { get; set; }
    }
}
