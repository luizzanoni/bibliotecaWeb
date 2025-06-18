using System.Collections.Generic;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Data
{
    public static class FakeDatabase
    {
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "admin", Senha = "admin", Admin = true },
            new Usuario { Id = 2, Nome = "user", Senha = "123", Admin = false }
        };

        public static List<Livro> Livros { get; set; } = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", Ano = 1937 },
            new Livro { Id = 2, Titulo = "Dom Casmurro", Autor = "Machado de Assis", Ano = 1899 },
            new Livro { Id = 3, Titulo = "1984", Autor = "George Orwell", Ano = 1949 }
        };

        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
