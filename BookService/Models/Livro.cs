using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public string Genero { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}