using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMarguerite.Models.ViewModels
{
    public class FloresViewModel
    {

        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [StringLength(400)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        [DisplayName("Especie")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public int Id_especie { get; set; }

        [DisplayName("Color")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public int Id_color { get; set; }
    }
}
