using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BibliotecaMVC.Models;
using BibliotecaMVC.Data;

namespace BibliotecaMVC.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult Index()
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            // Mostra livros disponíveis ou que o próprio usuário reservou
            var livrosDisponiveis = FakeDatabase.Livros
                .Where(l => !l.Reservado || l.IdUsuarioReserva == usuarioId)
                .ToList();

            return View(livrosDisponiveis);
        }

        [HttpPost]
        public IActionResult Reservar(int livroId)
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            var livro = FakeDatabase.Livros.FirstOrDefault(l => l.Id == livroId);

            if (livro != null && !livro.Reservado)
            {
                livro.Reservado = true;
                livro.IdUsuarioReserva = usuarioId;

                FakeDatabase.Reservas.Add(new Reserva
                {
                    Id = FakeDatabase.Reservas.Count + 1,
                    IdLivro = livroId,
                    IdUsuario = usuarioId
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelarReserva(int livroId)
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            var livro = FakeDatabase.Livros.FirstOrDefault(l => l.Id == livroId);
            var reserva = FakeDatabase.Reservas.FirstOrDefault(r => r.IdLivro == livroId && r.IdUsuario == usuarioId);

            if (livro != null && reserva != null)
            {
                livro.Reservado = false;
                livro.IdUsuarioReserva = null;
                FakeDatabase.Reservas.Remove(reserva);
            }

            return RedirectToAction("Index");
        }
    }
}
