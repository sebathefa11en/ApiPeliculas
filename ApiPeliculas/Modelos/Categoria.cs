using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Fecha { get; set; }
    }
}
