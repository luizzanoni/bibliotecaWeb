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

        // Adicionados:
        public bool Reservado { get; set; } = false;
        public int? IdUsuarioReserva { get; set; } = null;
    }
}
