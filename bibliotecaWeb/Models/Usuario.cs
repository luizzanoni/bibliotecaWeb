using System.ComponentModel.DataAnnotations;

namespace BibliotecaMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }

        public bool Admin { get; set; } // True = Admin, False = Usuário comum
    }
}
