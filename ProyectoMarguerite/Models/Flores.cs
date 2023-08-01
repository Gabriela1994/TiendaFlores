namespace ProyectoMarguerite.Models
{
    public class Flores
    {
        public string descripcion;
        public decimal precio;
        public int id_especie;
        public int id_color;
        public string especie;
        public string color;

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public int Id_especie { get; set; }
        public int Id_color { get; set; }

        public string Especie { get; set; }
        public string Color { get; set; }

    }
}
