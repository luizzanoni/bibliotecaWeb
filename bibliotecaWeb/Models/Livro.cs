using System.ComponentModel.DataAnnotations;

namespace BibliotecaMVC.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public int Ano { get; set; }

        public bool Reservado { get; set; } = false; // novo
        public int? IdUsuarioReservado { get; set; } // novo (pode ser id, nome, etc.)
    }
}
